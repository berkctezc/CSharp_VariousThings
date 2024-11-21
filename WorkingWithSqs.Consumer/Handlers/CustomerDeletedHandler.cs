namespace WorkingWithSqs.Consumer.Handlers;

public class CustomerDeletedHandler(ILogger<CustomerDeletedHandler> logger) : IMessageHandler
{
	public Task HandleAsync(IMessage message)
	{
		var customerDeleted = (CustomerDeleted) message;
		logger.LogInformation("Customer deleted with Id: {Id}", customerDeleted.Id);
		return Task.CompletedTask;
	}

	public Type MessageType { get; } = typeof(CustomerDeleted);
}