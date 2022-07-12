using WorkingWithSqs.Consumer.Messages;

namespace WorkingWithSqs.Consumer.Handlers;

public interface IMessageHandler
{
    public Task HandleAsync(IMessage message);

    public static abstract Type MessageType { get; }
}