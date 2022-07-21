namespace DynamoDb_MovieRank.Controllers;

[Route("setup")]
public class SetupController : Controller
{
    private readonly ISetupService _setupService;

    public SetupController(ISetupService setupService)
    {
        _setupService = setupService;
    }

    [HttpPost("createTable/{dynamoDbTableName}")]
    public async Task<IActionResult> CreateDynamoDbTable(string dynamoDbTableName)
    {
        await _setupService.CreateDynamoDbTable(dynamoDbTableName);

        return Ok();
    }

    [HttpDelete("deleteTable/{dynamoDbTableName}")]
    public async Task<IActionResult> DeleteTable(string dynamoDbTableName)
    {
        await _setupService.DeleteDynamoDbTable(dynamoDbTableName);

        return Ok();
    }
}