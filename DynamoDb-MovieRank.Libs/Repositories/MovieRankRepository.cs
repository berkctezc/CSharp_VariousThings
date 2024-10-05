namespace DynamoDb_MovieRank.Libs.Repositories;

public class MovieRankRepository : IMovieRankRepository
{
    private readonly DynamoDBContext _context;
    private readonly IAmazonDynamoDB _dynamoDbClient;

    public MovieRankRepository(IAmazonDynamoDB dynamoDbClient)
    {
        _dynamoDbClient = dynamoDbClient;
        _context = new DynamoDBContext(_dynamoDbClient);
    }

    public async Task<IEnumerable<MovieDb>> GetAllItems()
    {
        return await _context.ScanAsync<MovieDb>(new List<ScanCondition>()).GetRemainingAsync();
    }

    public async Task<MovieDb> GetMovie(int userId, string movieName)
    {
        return await _context.LoadAsync<MovieDb>(userId, movieName);
    }

    public async Task<IEnumerable<MovieDb>> GetUsersRankedMoviesByMovieTitle(
        int userId,
        string movieName
    )
    {
        var config = new DynamoDBOperationConfig
        {
            QueryFilter = new List<ScanCondition>
            {
                new("MovieName", ScanOperator.BeginsWith, movieName),
            },
        };

        return await _context.QueryAsync<MovieDb>(userId, config).GetRemainingAsync();
    }

    public async Task AddMovie(MovieDb movieDb)
    {
        await _context.SaveAsync(movieDb);
    }

    public async Task UpdateMovie(MovieDb request)
    {
        await _context.SaveAsync(request);
    }

    public async Task<IEnumerable<MovieDb>> GetMovieRank(string movieName)
    {
        var config = new DynamoDBOperationConfig { IndexName = "MovieName-index" };

        return await _context.QueryAsync<MovieDb>(movieName, config).GetRemainingAsync();
    }

    public async Task CreateDynamoTable(string tableName)
    {
        var request = new CreateTableRequest
        {
            TableName = tableName,
            AttributeDefinitions = new List<AttributeDefinition>
            {
                new() { AttributeName = "Id", AttributeType = "N" },
            },
            KeySchema = new List<KeySchemaElement>
            {
                new() { AttributeName = "Id", KeyType = "HASH" },
            },
            ProvisionedThroughput = new ProvisionedThroughput
            {
                ReadCapacityUnits = 1,
                WriteCapacityUnits = 1,
            },
        };

        await _dynamoDbClient.CreateTableAsync(request);
    }

    public async Task DeleteDynamoTable(string tableName)
    {
        var request = new DeleteTableRequest { TableName = tableName };

        await _dynamoDbClient.DeleteTableAsync(request);
    }
}
