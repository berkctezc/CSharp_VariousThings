namespace S3_LifeBackup.Infrastructure.Repositories;

public class BucketRepository(IAmazonS3 s3Client) : IBucketRepository
{
	public async Task<bool> DoesS3BucketExists(string bucketName)
		=> await AmazonS3Util.DoesS3BucketExistV2Async(s3Client, bucketName);

	public async Task<CreateBucketResponse?> CreateBucket(string bucketName)
	{
		var putBucketRequest = new PutBucketRequest
		{
			BucketName = bucketName,
			UseClientRegion = true
		};

		var response = await s3Client.PutBucketAsync(putBucketRequest);

		return new CreateBucketResponse
		{
			BucketName = bucketName,
			RequestId = response.ResponseMetadata.RequestId
		};
	}

	public async Task<IEnumerable<ListS3BucketResponse>?> ListBuckets()
	{
		var response = await s3Client.ListBucketsAsync();

		return response.Buckets.Select(b => new ListS3BucketResponse
		{
			BucketName = b.BucketName,
			CreationDate = b.CreationDate
		});
	}

	public async Task DeleteBucket(string bucketName)
		=> await s3Client.DeleteBucketAsync(bucketName);
}
