namespace WorkingWithSqs.Publisher.Messages;

public class CustomerDeleted : IMessage
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonIgnore] public string MessageTypeName => nameof(CustomerDeleted);
}