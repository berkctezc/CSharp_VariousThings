namespace WorkingWithSqs.Consumer.Handlers;

public interface IMessageHandler
{
	Type MessageType { get; }
	Task HandleAsync(IMessage message);
}