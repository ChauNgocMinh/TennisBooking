namespace TennisBooking.ViewModels;

public sealed class BookingAvailabilityViewModel
{
    public Guid CourtId { get; init; }

    public string CourtType { get; init; } = string.Empty;

    public DateTime WeekStart { get; init; }

    public IReadOnlyCollection<DateTime> BookedSlots { get; init; } = [];
}
