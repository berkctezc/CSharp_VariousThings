using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;
using System;
using Xunit;

namespace DeskBooker.Core.Tests.Processor
{
    /*
     * STEP 1: Get a Red 
     * STEP 2: Write the minimum code to pass the test
     * STEP 3: Refactor
     */
    public class DeskBookingRequestProcessorTests
    {
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

            var processor = new DeskBookingRequestProcessor();


            // Act
            DeskBookingResult result = processor.BookDesk(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }
    }
}
