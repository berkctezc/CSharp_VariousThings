using System.Text.Json.Serialization;

namespace S3_LifeBackup.Core.Interfaces;

public class AddJsonObjectRequest
{
    [JsonPropertyName("id")] public Guid Id { get; set; }
    [JsonPropertyName("timesent")] public DateTime TimeSent { get; set; }
    [JsonPropertyName("data")] public string Data { get; set; }
}