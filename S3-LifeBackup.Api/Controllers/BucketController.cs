namespace S3_LifeBackup.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BucketController(IBucketRepository bucketRepository) : ControllerBase
{
    [HttpPost("create/{bucketName}")]
    public async Task<ActionResult<CreateBucketResponse>> CreateS3Bucket(
        [FromRoute] string bucketName
    )
    {
        var bucketExists = await bucketRepository.DoesS3BucketExists(bucketName);

        if (bucketExists)
            return BadRequest("S3 bucket already exists");

        var result = await bucketRepository.CreateBucket(bucketName);

        if (result is null)
            return BadRequest();

        return Ok(result);
    }

    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<ListS3BucketResponse>?>> ListS3Buckets()
    {
        var result = await bucketRepository.ListBuckets();

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("delete/{bucketName}")]
    public async Task<IActionResult> DeleteS3Bucket(string bucketName)
    {
        await bucketRepository.DeleteBucket(bucketName);

        return Ok();
    }
}
