using System.Text.Json.Serialization;

namespace WorkingWithSqs.Messages;

public class CustomerDeleted
{
    [JsonPropertyName("id")] public int Id { get; set; }
}