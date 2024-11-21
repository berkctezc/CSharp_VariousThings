namespace Sqs_WebApi.Services;

public interface ISqsService
{
	Task<SendMessageResponse> SendMessageToSqsQueue(TicketRequest request);
}