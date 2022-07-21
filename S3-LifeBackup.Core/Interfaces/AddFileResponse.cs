namespace S3_LifeBackup.Core.Interfaces;

public class AddFileResponse
{
    public IList<string> PreSignedUrl { get; set; }
}