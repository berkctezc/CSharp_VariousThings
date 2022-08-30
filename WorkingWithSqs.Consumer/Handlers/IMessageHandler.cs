namespace WorkingWithSqs.Consumer.Handlers;

public interface IMessageHandler
{
    public Type MessageType { get; }
    public Task HandleAsync(IMessage message);
}