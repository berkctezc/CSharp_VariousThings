namespace WorkingWithSqs.Publisher;

public class SqsPublisher(IAmazonSQS sqs)
{
	public async Task PublishAsync<TMessage>(string queueName, TMessage message)
		where TMessage : IMessage
	{
		var queueUrl = await sqs.GetQueueUrlAsync(queueName);
		var request = new SendMessageRequest
		{
			QueueUrl = queueUrl.QueueUrl,
			MessageBody = JsonSerializer.Serialize(message),
			MessageAttributes = new Dictionary<string, MessageAttributeValue>
			{
				{
					nameof(IMessage.MessageTypeName), new MessageAttributeValue
					{
						StringValue = message.MessageTypeName,
						DataType = "String"
					}
				}
			}
		};

		await sqs.SendMessageAsync(request);
	}
}