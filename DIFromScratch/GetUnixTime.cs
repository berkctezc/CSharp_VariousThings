namespace DIFromScratch;

public class GetUnixTime
{
	public long UnixTime { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds();
}