namespace Sqs_WebApi.Models;

public class TicketRequest
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public string EmailAddress { get; set; }

	public string Serialize(TicketRequest value)
	{
		var options = new JsonSerializerOptions { WriteIndented = true };

		return JsonSerializer.Serialize(value, options);
	}
}
