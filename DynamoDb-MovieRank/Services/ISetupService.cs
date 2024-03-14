namespace DynamoDb_MovieRank.Services;

public interface ISetupService
{
	Task CreateDynamoDbTable(string dynamoDbTableName);

	Task DeleteDynamoDbTable(string dynamoDbTableName);
}
