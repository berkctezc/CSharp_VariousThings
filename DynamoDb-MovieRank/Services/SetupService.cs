namespace DynamoDb_MovieRank.Services;

public class SetupService : ISetupService
{
    private readonly IMovieRankRepository _movieRankRepository;

    public SetupService(IMovieRankRepository movieRankRepository)
    {
        _movieRankRepository = movieRankRepository;
    }

    public async Task CreateDynamoDbTable(string dynamoDbTableName)
    {
        await _movieRankRepository.CreateDynamoTable(dynamoDbTableName);
    }

    public async Task DeleteDynamoDbTable(string dynamoDbTableName)
    {
        await _movieRankRepository.DeleteDynamoTable(dynamoDbTableName);
    }
}