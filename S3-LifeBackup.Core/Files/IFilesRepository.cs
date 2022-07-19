namespace S3_LifeBackup.Core.Files;

public interface IFilesRepository
{
    Task<AddFileResponse?> UploadFiles(string bucketName, IList<IFormFile> formFiles);
    Task<IEnumerable<ListFilesResponse>> ListFiles(string bucketName);
    Task DownloadFile(string bucketName, string fileName);
    Task<DeleteFileResponse> DeleteFile(string bucketName, string fileName);
    Task AddJsonObject(string bucketName, AddJsonObjectRequest request);
    Task<GetJsonObjectResponse> GetJsonObject(string bucketName, string fileName);
}