namespace WorkingWithSqs.Consumer.Handlers;

public class CustomerDeletedHandler : IMessageHandler
{
    private readonly ILogger<CustomerDeletedHandler> _logger;

    public CustomerDeletedHandler(ILogger<CustomerDeletedHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(IMessage message)
    {
        var customerDeleted = (CustomerDeleted) message;
        _logger.LogInformation("Customer deleted with Id: {Id}", customerDeleted.Id);
        return Task.CompletedTask;
    }

    public Type MessageType { get; } = typeof(CustomerDeleted);
}