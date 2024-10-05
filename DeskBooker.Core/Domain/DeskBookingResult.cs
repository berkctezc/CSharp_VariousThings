namespace DeskBooker.Core.Domain;

public class DeskBookingResult : DeskBookingBase
{
    public DeskBookingResultCode Code { get; set; }
    public int? DeskBookingId { get; set; }
}
