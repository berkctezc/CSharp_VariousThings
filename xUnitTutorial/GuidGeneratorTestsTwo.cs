using Xunit;
using Xunit.Abstractions;

namespace xUnitTutorial;

[Collection("Guid generator")]
public class GuidGeneratorTestsTwo
{
    private readonly GuidGenerator _guidGenerator;
    private readonly ITestOutputHelper _output;

    public GuidGeneratorTestsTwo(GuidGenerator guidGenerator, ITestOutputHelper output)
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