namespace WorkingWithSqs.Publisher.Messages;

public interface IMessage
{
	public string MessageTypeName { get; }
}