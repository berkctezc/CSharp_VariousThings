namespace WorkingWithSqs.Consumer.Messages;

public interface IMessage
{
    public string MessageTypeName { get; }
}
