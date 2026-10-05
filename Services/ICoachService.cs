using TennisBooking.ViewModels;

namespace TennisBooking.Services;

public interface ICoachService
{
    Task<IReadOnlyCollection<CoachViewModel>> GetAllAsync(CancellationToken cancellationToken = default);
}
