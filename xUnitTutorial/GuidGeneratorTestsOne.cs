namespace xUnitTutorial;

[Collection("Guid generator")]
public class GuidGeneratorTestsOne
{
    private readonly GuidGenerator _guidGenerator;
    private readonly ITestOutputHelper _output;

    public GuidGeneratorTestsOne(GuidGenerator guidGenerator, ITestOutputHelper output)
    {
        _output = output;
        _guidGenerator = guidGenerator;
    }

    [Fact]
    public void GuidTestOne()
    {
        var guid = _guidGenerator.RandomGuid;
        _output.WriteLine($"The guid was: {guid}");
    }

    [Fact]
    public void GuidTestTwo()
    {
        var guid = _guidGenerator.RandomGuid;
        _output.WriteLine($"The guid was: {guid}");
    }
}