namespace DIFromScratch;

public class SomeServiceOne : ISomeService
{
    private readonly IRandomGuidProvider _randomGuidProvider;

    public SomeServiceOne(IRandomGuidProvider randomGuidProvider)
    {
        _randomGuidProvider = randomGuidProvider;
    }

    private Guid RandomGuid { get; } = Guid.NewGuid();

    public void PrintGuid()
    {
        Console.WriteLine($"=====\n|{RandomGuid}|\n=====");
    }
}