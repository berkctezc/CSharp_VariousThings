namespace DynamoDb_MovieRank.Controllers;

[Route("setup")]
public class SetupController(ISetupService setupService) : Controller
{
	[HttpPost("createTable/{dynamoDbTableName}")]
	public async Task<IActionResult> CreateDynamoDbTable(string dynamoDbTableName)
	{
		await setupService.CreateDynamoDbTable(dynamoDbTableName);

		return Ok();
	}

	[HttpDelete("deleteTable/{dynamoDbTableName}")]
	public async Task<IActionResult> DeleteTable(string dynamoDbTableName)
	{
		await setupService.DeleteDynamoDbTable(dynamoDbTableName);

		return Ok();
	}
}
