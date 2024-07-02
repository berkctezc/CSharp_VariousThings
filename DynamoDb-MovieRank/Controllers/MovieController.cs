namespace DynamoDb_MovieRank.Controllers;

[Route("movies")]
public class MovieController(IMovieRankService movieRankService) : Controller
{
	[HttpGet]
	public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
	{
		var results = await movieRankService.GetAllItemsFromDatabase();

		return results;
	}

	[HttpGet("{userId}/{movieName}")]
	public async Task<MovieResponse> GetMovie(int userId, string movieName)
	{
		var result = await movieRankService.GetMovie(userId, movieName);

		return result;
	}

	[HttpGet("user/{userId}/rankedMovies/{movieName}")]
	public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
	{
		var results = await movieRankService.GetUsersRankedMoviesByMovieTitle(userId, movieName);

		return results;
	}

	[HttpPost("{userId}")]
	public async Task<IActionResult> AddMovie(int userId, [FromBody] MovieRankRequest movieRankRequest)
	{
		await movieRankService.AddMovie(userId, movieRankRequest);

		return Ok();
	}

	[HttpPatch("{userId}")]
	public async Task<IActionResult> UpdateMovie(int userId, [FromBody] MovieUpdateRequest request)
	{
		await movieRankService.UpdateMovie(userId, request);

		return Ok();
	}

	[HttpGet]
	[Route("{movieName}/ranking")]
	public async Task<MovieRankResponse> GetMoviesRanking(string movieName)
	{
		var result = await movieRankService.GetMovieRank(movieName);

		return result;
	}
}