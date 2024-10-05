namespace WorkingWithSqs.Publisher.Messages;

public class CustomerCreated : IMessage
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; } = default!;

    [JsonIgnore]
    public string MessageTypeName => nameof(CustomerCreated);
}
