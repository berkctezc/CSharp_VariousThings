using Amazon.Lambda.TestUtilities;
using Xunit;

namespace AnnotationsAPI.Lambda.Tests;

public class FunctionsTest
{
	public FunctionsTest() { }

	[Fact]
	public void TestAdd()
	{
		TestLambdaContext context = new TestLambdaContext();

		var functions = new Functions();
		Assert.Equal(12, functions.Add(3, 9, context));
	}
}
