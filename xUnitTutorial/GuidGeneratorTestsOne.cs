namespace xUnitTutorial;

[Collection("Guid generator")]
public class GuidGeneratorTestsOne(GuidGenerator guidGenerator, ITestOutputHelper output)
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
