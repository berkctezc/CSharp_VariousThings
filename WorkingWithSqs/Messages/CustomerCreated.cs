using System.Text.Json.Serialization;

namespace WorkingWithSqs.Messages;

public class CustomerCreated
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("fullName")] public string FullName { get; set; } = default!;
}