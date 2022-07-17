﻿namespace DeskBooker.Core.Processor;

public class DeskBookingRequestProcessor
{
    private readonly IDeskBookingRepository _deskBookingRepository;
    private readonly IDeskRepository _deskRepository;

    public DeskBookingRequestProcessor(IDeskBookingRepository deskBookingRepository, IDeskRepository deskRepository)
    {
        _deskBookingRepository = deskBookingRepository;
        _deskRepository = deskRepository;
    }

    public DeskBookingResult BookDesk(DeskBookingRequest request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));

        var result = Create<DeskBookingResult>(request);

        var availableDesks = _deskRepository.GetAvailableDesks(request.Date);

        if (availableDesks.FirstOrDefault() is Desk availableDesk)
        {
            var deskBooking = Create<DeskBooking>(request);
            deskBooking.DeskId = availableDesk.Id;
            _deskBookingRepository.Save(deskBooking);

            result.DeskBookingId = deskBooking.Id;
            result.Code = DeskBookingResultCode.Success;
        }
        else
        {
            result.Code = DeskBookingResultCode.NoDeskAvailable;
        }

        return result;
    }

    private static T Create<T>(DeskBookingRequest request) where T : DeskBookingBase, new()
    {
        return new T
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Date = request.Date
        };
    }
}