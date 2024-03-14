namespace WorkingWithSqs.Consumer;

public class SqsConsumerService(IAmazonSQS sqs, MessageDispatcher dispatcher) : BackgroundService
{
	private const string QueueName = "customers";
	private static readonly List<string> MessageAttributeNames = new() {"All"};

	protected override async Task ExecuteAsync(CancellationToken ct)
	{
		var queueUrl = await sqs.GetQueueUrlAsync(QueueName, ct);
		var receiveRequest = new ReceiveMessageRequest
		{
			QueueUrl = queueUrl.QueueUrl,
			MessageAttributeNames = MessageAttributeNames,
			AttributeNames = MessageAttributeNames
		};

		while (!ct.IsCancellationRequested)
		{
			var messageResponse = await sqs.ReceiveMessageAsync(receiveRequest, ct);
			if (messageResponse.HttpStatusCode != HttpStatusCode.OK)
				// logic
				continue;

			foreach (var msg in messageResponse.Messages)
			{
				var messageTypeName = msg.MessageAttributes
					.GetValueOrDefault(nameof(IMessage.MessageTypeName))?.StringValue;

				if (messageTypeName is null) continue;

				if (!dispatcher.CanHandleMessageType(messageTypeName)) continue;

				var messageType = dispatcher.GetMessageTypeByName(messageTypeName)!;

				var messageAsType = (IMessage) JsonSerializer.Deserialize(msg.Body, messageType)!;


				await dispatcher.DispatchAsync(messageAsType);
				await sqs.DeleteMessageAsync(queueUrl.QueueUrl, msg.ReceiptHandle, ct);
			}
		}
	}
}
