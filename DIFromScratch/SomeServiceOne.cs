namespace DIFromScratch;

public class SomeServiceOne : ISomeService
{
    private Guid RandomGuid { get; } = Guid.NewGuid();

    private readonly IRandomGuidProvider _randomGuidProvider;

    public SomeServiceOne(IRandomGuidProvider randomGuidProvider)
    {
        _randomGuidProvider = randomGuidProvider;
    }

    public void PrintGuid()
    {
        Console.WriteLine($"=====\n|{RandomGuid}|\n=====");
    }
}