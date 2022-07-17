namespace WorkingWithSqs.Consumer.Handlers;

public interface IMessageHandler
{
    public static abstract Type MessageType { get; }
    public Task HandleAsync(IMessage message);
}