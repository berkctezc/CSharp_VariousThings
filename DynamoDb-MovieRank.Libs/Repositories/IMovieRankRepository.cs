namespace DynamoDb_MovieRank.Libs.Repositories;

public interface IMovieRankRepository
{
    Task<ScanResponse> GetAllItems();

    Task<GetItemResponse> GetMovie(int userId, string movieName);

    Task<QueryResponse> GetUsersRankedMoviesByMovieTitle(int userId, string movieName);

    Task AddMovie(int userId, MovieRankRequest movieRankRequest);

    Task UpdateMovie(int userId, MovieUpdateRequest updateRequest);

    Task<QueryResponse> GetMovieRank(string movieName);

    Task CreateDynamoTable(string tableName);

    Task DeleteDynamoDbTable(string tableName);
}