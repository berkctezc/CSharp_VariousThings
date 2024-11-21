namespace DynamoDb_MovieRank.Libs.Mappers;

public interface IMapper
{
	IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDb> items);

	MovieResponse ToMovieContract(MovieDb movie);

	MovieDb ToMovieDbModel(int userId, MovieRankRequest movieRankRequest);

	MovieDb ToMovieDbModel(
		int userId,
		MovieDb movieDbRequest,
		MovieUpdateRequest movieUpdateRequest
	);
}