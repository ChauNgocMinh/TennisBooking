namespace TennisBooking.ViewModels;

public sealed class BookingRequest
{
    public string CustomerName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string ClassType { get; set; } = string.Empty;

    public List<DateTime> Dates { get; set; } = [];

    public int StartHour { get; set; }

    public int EndHour { get; set; }
}
