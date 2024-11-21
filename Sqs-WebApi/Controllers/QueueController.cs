namespace Sqs_WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QueueController : ControllerBase
{
	private readonly ISqsService _sqsService;

	public QueueController(ISqsService sqsService)
	{
		_sqsService = sqsService;
	}

	[HttpPost("SendMessage")]
	public async Task<IActionResult> SendMessage(TicketRequest request)
	{
		var response = await _sqsService.SendMessageToSqsQueue(request);

		return Ok(response);
	}
}