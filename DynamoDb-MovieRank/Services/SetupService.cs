namespace DynamoDb_MovieRank.Services;

public class SetupService(IMovieRankRepository movieRankRepository) : ISetupService
{
    public async Task CreateDynamoDbTable(string dynamoDbTableName)
    {
        await movieRankRepository.CreateDynamoTable(dynamoDbTableName);
    }

    public async Task DeleteDynamoDbTable(string dynamoDbTableName)
    {
        await movieRankRepository.DeleteDynamoTable(dynamoDbTableName);
    }
}