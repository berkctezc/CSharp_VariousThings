namespace S3_LifeBackup.Core.Files;

public class ListFilesResponse
{
	public string BucketName { get; set; }
	public string Key { get; set; }
	public string Owner { get; set; }
	public long Size { get; set; }
}
