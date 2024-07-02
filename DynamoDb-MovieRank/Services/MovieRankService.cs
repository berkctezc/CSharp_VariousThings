namespace DynamoDb_MovieRank.Services;

public class MovieRankService(IMovieRankRepository movieRankRepository, IMapper map) : IMovieRankService
{
	public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
	{
		var response = await movieRankRepository.GetAllItems();

		return map.ToMovieContract(response);
	}

	public async Task<MovieResponse> GetMovie(int userId, string movieName)
	{
		var response = await movieRankRepository.GetMovie(userId, movieName);

		return map.ToMovieContract(response);
	}

	public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
	{
		var response = await movieRankRepository.GetUsersRankedMoviesByMovieTitle(userId, movieName);

		return map.ToMovieContract(response);
	}

	public async Task AddMovie(int userId, MovieRankRequest movieRankRequest)
	{
		var movieDb = map.ToMovieDbModel(userId, movieRankRequest);

		await movieRankRepository.AddMovie(movieDb);
	}

	public async Task UpdateMovie(int userId, MovieUpdateRequest request)
	{
		var response = await movieRankRepository.GetMovie(userId, request.MovieName);

		var movieDb = map.ToMovieDbModel(userId, response, request);

		await movieRankRepository.UpdateMovie(movieDb);
	}

	public async Task<MovieRankResponse> GetMovieRank(string movieName)
	{
		var response = await movieRankRepository.GetMovieRank(movieName);

		var overallMovieRanking = Math.Round(response.Select(x => x.Ranking).Average());

		return new MovieRankResponse
		{
			MovieName = movieName,
			OverallRanking = overallMovieRanking
		};
	}
}