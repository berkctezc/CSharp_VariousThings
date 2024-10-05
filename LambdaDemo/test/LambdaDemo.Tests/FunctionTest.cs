namespace LambdaDemo.Tests;

public class FunctionTest
{
    private readonly TestLambdaContext _context;
    private readonly Function _function;

    public FunctionTest()
    {
        _function = new Function();
        _context = new TestLambdaContext();
    }

    [Fact]
    public void TestCasing()
    {
        // Arrange
        const string userInput = "hello world";

        // Act
        var casing = _function.FunctionHandler(userInput, _context);

        // Assert
        Assert.Equal(userInput.ToLower(), casing.Lower);
        Assert.Equal(userInput.ToUpper(), casing.Upper);
    }
}
