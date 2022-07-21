namespace DynamoDb_MovieRank.Libs.Mappers;

public interface IMapper
{
    IEnumerable<MovieResponse> ToMovieContract(ScanResponse response);

    MovieResponse ToMovieContract(GetItemResponse response);

    IEnumerable<MovieResponse> ToMovieContract(QueryResponse response);
}