namespace xUnitTutorial;

[Collection("Guid generator")]
public class GuidGeneratorTestsTwo(GuidGenerator guidGenerator, ITestOutputHelper output)
{
    [Fact]
    public void GuidTestOne()
    {
        var guid = guidGenerator.RandomGuid;
        output.WriteLine($"The guid was: {guid}");
    }

    [Fact]
    public void GuidTestTwo()
    {
        var guid = guidGenerator.RandomGuid;
        output.WriteLine($"The guid was: {guid}");
    }
}