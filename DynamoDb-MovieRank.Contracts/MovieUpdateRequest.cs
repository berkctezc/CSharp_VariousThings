namespace DynamoDb_MovieRank.Contracts;

public class MovieUpdateRequest
{
	public string MovieName { get; set; }
	public int Ranking { get; set; }
}
