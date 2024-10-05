namespace DIFromScratch;

public class RandomGuidProvider : IRandomGuidProvider
{
    public Guid RandomGuid { get; } = Guid.NewGuid();
}
