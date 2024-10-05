namespace MockLib.Test;

public class MockTests
{
    // Store all the mocked method in MyMock
    // Write a class in string form and compile it
    // Attach the behavior to the class

    [Fact]
    public void Mock_ShouldMock()
    {
        // Arrange
        var mockExample = new MyMock<IExample>();

        // Act
        mockExample.MockMethod(x => x.ExampleMethod(), "hi from MyMock");
        var example = mockExample.Object;

        // Assert
        Assert.Equal("hi from MyMock", example.ExampleMethod());
    }

    [Fact]
    public void Mock_ShouldMock2()
    {
        // Arrange
        var mockExample = new MyMock<IExample>();

        // Act
        mockExample.MockMethod(x => x.MagicNumber(420), 240);
        var example = mockExample.Object;

        // Assert
        Assert.Equal(240, example.MagicNumber(420));
    }
}
