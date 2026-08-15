namespace WorkingWithSqs.Consumer.Messages;

public interface IMessage
{
	string MessageTypeName { get; }
}