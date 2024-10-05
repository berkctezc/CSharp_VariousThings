namespace WorkingWithSqs.Consumer.Handlers;

public class CustomerCreatedHandler(ILogger<CustomerCreatedHandler> logger) : IMessageHandler
{
    public Task HandleAsync(IMessage message)
    {
        var customerCreated = (CustomerCreated)message;
        logger.LogInformation("Customer created with name: {FullName}", customerCreated.FullName);
        return Task.CompletedTask;
    }

    public Type MessageType { get; } = typeof(CustomerCreated);
}
