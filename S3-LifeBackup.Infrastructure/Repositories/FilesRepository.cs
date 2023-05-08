using Newtonsoft.Json;
using S3_LifeBackup.Core.Files;
using S3_LifeBackup.Core.Interfaces;

namespace S3_LifeBackup.Infrastructure.Repositories;

public class FilesRepository : IFilesRepository
{
    private readonly IAmazonS3 _s3Client;

    public FilesRepository(IAmazonS3 s3Client)
        => _s3Client = s3Client;

    public async Task<AddFileResponse?> UploadFiles(string bucketName, IList<IFormFile> formFiles)
    {
        var response = new List<string>();

        foreach (var f in formFiles)
        {
            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = f.OpenReadStream(),
                Key = f.FileName,
                BucketName = bucketName,
                CannedACL = S3CannedACL.NoACL
            };

            using var fileTransferUtility = new TransferUtility(_s3Client);
            await fileTransferUtility.UploadAsync(uploadRequest);

            var expiryUrlRequest = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = f.FileName,
                Expires = DateTime.Now.AddDays(5)
            };

            var url = _s3Client.GetPreSignedURL(expiryUrlRequest);

            response.Add(url);
        }

        return new AddFileResponse
        {
            PreSignedUrl = response
        };
    }

    public async Task<IEnumerable<ListFilesResponse>> ListFiles(string bucketName)
    {
        var responses = await _s3Client.ListObjectsAsync(bucketName);

        return responses.S3Objects.Select(b => new ListFilesResponse
        {
            BucketName = b.BucketName,
            Key = b.Key,
            Owner = b.Owner.DisplayName,
            Size = b.Size
        });
    }

    public async Task DownloadFile(string bucketName, string fileName)
    {
        var downloadRequest = new TransferUtilityDownloadRequest
        {
            BucketName = bucketName,
            Key = fileName,
            FilePath = OperatingSystem.IsLinux() ? $"~/temp/{fileName}" : @$"C:\temp\{fileName}"
        };

        using var transferUtility = new TransferUtility(_s3Client);
        await transferUtility.DownloadAsync(downloadRequest);
    }

    public async Task<DeleteFileResponse> DeleteFile(string bucketName, string fileName)
    {
        var multiObjectDeleteRequest = new DeleteObjectsRequest
        {
            BucketName = bucketName
        };

        multiObjectDeleteRequest.AddKey(fileName);

        var response = await _s3Client.DeleteObjectsAsync(multiObjectDeleteRequest);

        return new DeleteFileResponse
        {
            NumberOfDeletedObjects = response.DeletedObjects.Count
        };
    }

    public async Task AddJsonObject(string bucketName, AddJsonObjectRequest request)
    {
        var createdOnUtc = DateTime.UtcNow;

        var s3Key = $"{createdOnUtc:yyyy}/{createdOnUtc:MM}/{createdOnUtc:dd}/{request.Id}";

        var putObjectRequest = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = s3Key,
            ContentBody = JsonConvert.SerializeObject(request)
        };

        await _s3Client.PutObjectAsync(putObjectRequest);
    }

    public async Task<GetJsonObjectResponse> GetJsonObject(string bucketName, string fileName)
    {
        var request = new GetObjectRequest
        {
            BucketName = bucketName,
            Key = fileName
        };

        var response = await _s3Client.GetObjectAsync(request);

        using var reader = new StreamReader(response.ResponseStream);
        var contents = await reader.ReadToEndAsync();

        return JsonConvert.DeserializeObject<GetJsonObjectResponse>(contents) ?? new GetJsonObjectResponse();
    }
}