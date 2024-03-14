namespace DIFromScratch;

public class SomeServiceOne(IRandomGuidProvider randomGuidProvider) : ISomeService
{
	private readonly IRandomGuidProvider _randomGuidProvider = randomGuidProvider;

	private Guid RandomGuid { get; } = Guid.NewGuid();

	public void PrintGuid()
	{
		Console.WriteLine($"=====\n|{RandomGuid}|\n=====");
	}
}
