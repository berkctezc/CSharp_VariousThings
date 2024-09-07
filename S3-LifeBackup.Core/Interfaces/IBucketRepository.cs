namespace S3_LifeBackup.Core.Interfaces;

public interface IBucketRepository
{
	Task<bool> DoesS3BucketExists(string bucketName);
	Task<CreateBucketResponse?> CreateBucket(string bucketName);
	Task<IEnumerable<ListS3BucketResponse>?> ListBuckets();
	Task DeleteBucket(string bucketName);
}
