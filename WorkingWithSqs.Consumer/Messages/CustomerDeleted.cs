using System.Text.Json.Serialization;

namespace WorkingWithSqs.Consumer.Messages;

public class CustomerDeleted : IMessage
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonIgnore] public string MessageTypeName => nameof(CustomerDeleted);
}