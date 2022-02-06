using DeskBooker.Core.Domain;
using System;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessor
    {
        public DeskBookingRequestProcessor(DataInterface.IDeskBookingRepository @object)
        {
        }

        public DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            return new DeskBookingResult
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date,
            };
        }
    }
}