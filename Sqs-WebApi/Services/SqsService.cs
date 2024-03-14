namespace Sqs_WebApi.Services;

public class SqsService : ISqsService
{
	private readonly IAmazonSQS _sqsClient;

	public SqsService(IAmazonSQS sqsClient)
	{
		_sqsClient = sqsClient;
	}

	public async Task<SendMessageResponse> SendMessageToSqsQueue(TicketRequest request)
	{
		var sendMessageRequest = new SendMessageRequest
		{
			QueueUrl = "https://sqs.eu-central-1.amazonaws.com/788698617979/TicketRequest",
			MessageBody = request.Serialize(request)
		};

		return await _sqsClient.SendMessageAsync(sendMessageRequest);
	}
}
