namespace DynamoDb_MovieRank.Contracts;

public class MovieRankResponse
{
	public string MovieName { get; set; }

	public double OverallRanking { get; set; }
}