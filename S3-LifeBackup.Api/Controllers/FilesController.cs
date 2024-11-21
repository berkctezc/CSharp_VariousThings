using S3_LifeBackup.Core.Files;

namespace S3_LifeBackup.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController(IFilesRepository filesRepository) : ControllerBase
{
	[HttpPost("{bucketName}/add")]
	public async Task<ActionResult<AddFileResponse>> AddFiles(
		string bucketName,
		IList<IFormFile>? formFiles
	)
	{
		if (formFiles is null)
			return BadRequest("The request doesn't contain any files to be uploaded.");

		var response = await filesRepository.UploadFiles(bucketName, formFiles);

		if (response is null)
			return BadRequest();

		return Ok(response);
	}

	[HttpGet("{bucketName}/list")]
	public async Task<ActionResult<IEnumerable<ListFilesResponse>>> ListFiles(string bucketName)
	{
		var response = await filesRepository.ListFiles(bucketName);

		return Ok(response);
	}

	[HttpGet("{bucketName}/download/{fileName}")]
	public async Task<IActionResult> DownloadFile(string bucketName, string fileName)
	{
		await filesRepository.DownloadFile(bucketName, fileName);

		return Ok();
	}

	[HttpDelete("{bucketName}/delete/{fileName}")]
	public async Task<ActionResult<DeleteFileResponse>> DeleteFile(
		string bucketName,
		string fileName
	)
	{
		var response = await filesRepository.DeleteFile(bucketName, fileName);

		return Ok(response);
	}

	[HttpPost("{bucketName}/addjsonobject")]
	public async Task<IActionResult> AddJsonObject(string bucketName, AddJsonObjectRequest request)
	{
		await filesRepository.AddJsonObject(bucketName, request);

		return Ok();
	}

	[HttpPost("{bucketName}/getjsonobject")]
	public async Task<ActionResult<GetJsonObjectResponse>> GetJsonObject(
		string bucketName,
		string fileName
	)
	{
		var jsonObject = await filesRepository.GetJsonObject(bucketName, fileName);

		return Ok(jsonObject);
	}
}