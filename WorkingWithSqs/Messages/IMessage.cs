namespace WorkingWithSqs.Publisher.Messages;

public interface IMessage
{
	string MessageTypeName { get; }
}