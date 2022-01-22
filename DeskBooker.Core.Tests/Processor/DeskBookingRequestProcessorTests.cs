using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;
using System;
using Xunit;

namespace DeskBooker.Core.Tests.Processor;
/*
 * STEP 1: Get a Red (RED)
 * STEP 2: Write the minimum code to pass the test (GREEN)
 * STEP 3: Refactor the code without changing functionality (REFACTOR)
 */

public class DeskBookingRequestProcessorTests
{
    private readonly DeskBookingRequestProcessor _processor;

    public DeskBookingRequestProcessorTests()
    {
        _processor = new DeskBookingRequestProcessor();
    }

    [Fact]
    public void ShouldReturnDeskBookingResultWithRequestValues()
    {
        // Arrange
        var request = new DeskBookingRequest
        {
            FirstName = "Berkc",
            LastName = "Tezc",
            Email = "berkctezc@github.com",
            Date = new DateTime(2021, 2, 8)
        };

        // Act
        var result = _processor.BookDesk(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(request.FirstName, result.FirstName);
        Assert.Equal(request.LastName, result.LastName);
        Assert.Equal(request.Email, result.Email);
        Assert.Equal(request.Date, result.Date);
    }

    [Fact]
    public void ShouldThrowExceptionIfRequestIsNull()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));

        Assert.Equal("request", exception.ParamName);
    }
}