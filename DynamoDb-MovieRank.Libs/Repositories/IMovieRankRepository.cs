namespace DynamoDb_MovieRank.Libs.Repositories;

public interface IMovieRankRepository
{
    Task<IEnumerable<MovieDb>> GetAllItems();

    Task<MovieDb> GetMovie(int userId, string movieName);

    Task<IEnumerable<MovieDb>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName);

    Task AddMovie(MovieDb movieDb);

    Task UpdateMovie(MovieDb request);

    Task<IEnumerable<MovieDb>> GetMovieRank(string movieName);

    Task CreateDynamoTable(string tableName);

    Task DeleteDynamoTable(string tableName);
}