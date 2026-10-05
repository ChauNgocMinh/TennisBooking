using TennisBooking.ViewModels;

namespace TennisBooking.Services;

public interface IBookingService
{
    Task<BookingAvailabilityViewModel> GetAvailabilityAsync(DateTime weekStart, string classType, CancellationToken cancellationToken = default);

    Task<BookingCreateResult> CreateAsync(BookingRequest request, CancellationToken cancellationToken = default);
}
