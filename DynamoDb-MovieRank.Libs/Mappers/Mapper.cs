namespace DynamoDb_MovieRank.Libs.Mappers;

public class Mapper : IMapper
{
    public IEnumerable<MovieResponse> ToMovieContract(ScanResponse response)
    {
        return response.Items.Select(ToMovieContract);
    }

    public IEnumerable<MovieResponse> ToMovieContract(QueryResponse response)
    {
        return response.Items.Select(ToMovieContract);
    }

    public MovieResponse ToMovieContract(GetItemResponse response)
    {
        return new MovieResponse
        {
            MovieName = response.Item["MovieName"].S,
            Description = response.Item["Description"].S,
            Actors = response.Item["Actors"].SS,
            Ranking = Convert.ToInt32(response.Item["Ranking"].N),
            TimeRanked = response.Item["RankedDateTime"].S
        };
    }

    private MovieResponse ToMovieContract(Dictionary<string, AttributeValue> item)
    {
        return new MovieResponse
        {
            MovieName = item["MovieName"].S,
            Description = item["Description"].S,
            Actors = item["Actors"].SS,
            Ranking = Convert.ToInt32(item["Ranking"].N),
            TimeRanked = item["RankedDateTime"].S
        };
    }
}