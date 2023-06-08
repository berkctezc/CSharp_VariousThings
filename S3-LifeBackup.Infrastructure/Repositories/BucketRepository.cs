namespace S3_LifeBackup.Infrastructure.Repositories;

public class BucketRepository : IBucketRepository
{
    private readonly IAmazonS3 _s3Client;

    public BucketRepository(IAmazonS3 s3Client)
        => _s3Client = s3Client;

    public async Task<bool> DoesS3BucketExists(string bucketName)
        => await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);

    public async Task<CreateBucketResponse?> CreateBucket(string bucketName)
    {
        var putBucketRequest = new PutBucketRequest
        {
            BucketName = bucketName,
            UseClientRegion = true
        };

        var response = await _s3Client.PutBucketAsync(putBucketRequest);

        return new CreateBucketResponse
        {
            BucketName = bucketName,
            RequestId = response.ResponseMetadata.RequestId
        };
    }

    public async Task<IEnumerable<ListS3BucketResponse>?> ListBuckets()
    {
        var response = await _s3Client.ListBucketsAsync();

        return response.Buckets.Select(b => new ListS3BucketResponse
        {
            BucketName = b.BucketName,
            CreationDate = b.CreationDate
        });
    }

    public async Task DeleteBucket(string bucketName)
        => await _s3Client.DeleteBucketAsync(bucketName);
}