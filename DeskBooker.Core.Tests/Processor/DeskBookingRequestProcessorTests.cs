using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;
using Moq;
using System;
using Xunit;

namespace DeskBooker.Core.Tests.Processor
{
    /*
     * STEP 1: Get a Red (RED)
     * STEP 2: Write the minimum code to pass the test (GREEN)
     * STEP 3: Refactor the code without changing functionality (REFACTOR)
     */

    public class DeskBookingRequestProcessorTests
    {
        private readonly DeskBookingRequestProcessor _processor;
        private readonly DeskBookingRequest _request;
        private readonly Mock<IDeskBookingRepository> _deskBookingRepositoryMock;

        public DeskBookingRequestProcessorTests()
        {
            // Arrange
            _request = new DeskBookingRequest
            {
                FirstName = "Berkc",
                LastName = "Tezc",
                Email = "berkctezc@github.com",
                Date = new DateTime(2021, 2, 8)
            };

            _deskBookingRepositoryMock = new Mock<IDeskBookingRepository>();
            _processor = new DeskBookingRequestProcessor(
                _deskBookingRepositoryMock.Object
            );
        }

        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {
            // Act
            DeskBookingResult result = _processor.BookDesk(_request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_request.FirstName, result.FirstName);
            Assert.Equal(_request.LastName, result.LastName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.Date, result.Date);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveDeskBooking()
        {
            DeskBooking savedDeskBooking = null;
            _deskBookingRepositoryMock.Setup(x => x.Save(It.IsAny<DeskBooking>()))
            .Callback<DeskBooking>(dB =>
            {
                savedDeskBooking = dB;
            });

            _processor.BookDesk(_request);

            _deskBookingRepositoryMock.Verify(x => x.Save(It.IsAny<Deskbooking>()), Times.Once);

            Assert.NotNull(savedDeskBooking);
            Assert.Equal(_request.FirstName, savedDeskBooking.FirstName);
            Assert.Equal(_request.FirstName, savedDeskBooking.LastName);
            Assert.Equal(_request.FirstName, savedDeskBooking.Email);
            Assert.Equal(_request.FirstName, savedDeskBooking.Date);
        }
    }
}
