namespace S3_LifeBackup.Core.Interfaces;

public class GetJsonObjectResponse
{
    public Guid Id { get; set; }
    public DateTime TimeSent { get; set; }
    public string Data { get; set; }
}