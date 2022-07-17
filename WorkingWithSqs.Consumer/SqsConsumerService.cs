namespace WorkingWithSqs.Consumer;

public class SqsConsumerService : BackgroundService
{
    private const string QueueName = "customers";
    private static readonly List<string> MessageAttributeNames = new() {"All"};
    private readonly MessageDispatcher _dispatcher;
    private readonly IAmazonSQS _sqs;

    public SqsConsumerService(IAmazonSQS sqs, MessageDispatcher dispatcher)
    {
        _sqs = sqs;
        _dispatcher = dispatcher;
    }

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        var queueUrl = await _sqs.GetQueueUrlAsync(QueueName, ct);
        var receiveRequest = new ReceiveMessageRequest
        {
            QueueUrl = queueUrl.QueueUrl,
            MessageAttributeNames = MessageAttributeNames,
            AttributeNames = MessageAttributeNames
        };

        while (!ct.IsCancellationRequested)
        {
            var messageResponse = await _sqs.ReceiveMessageAsync(receiveRequest, ct);
            if (messageResponse.HttpStatusCode != HttpStatusCode.OK)
                // logic
                continue;

            foreach (var msg in messageResponse.Messages)
            {
                var messageTypeName = msg.MessageAttributes
                    .GetValueOrDefault(nameof(IMessage.MessageTypeName))?.StringValue;

                if (messageTypeName is null) continue;

                if (!_dispatcher.CanHandleMessageType(messageTypeName)) continue;

                var messageType = _dispatcher.GetMessageTypeByName(messageTypeName)!;

                var messageAsType = (IMessage) JsonSerializer.Deserialize(msg.Body, messageType)!;


                await _dispatcher.DispatchAsync(messageAsType);
                await _sqs.DeleteMessageAsync(queueUrl.QueueUrl, msg.ReceiptHandle, ct);
            }
        }
    }
}