namespace TennisBooking.ViewModels;

public sealed class BookingCreateResult
{
    public IReadOnlyCollection<Guid> BookingIds { get; init; } = [];
}
