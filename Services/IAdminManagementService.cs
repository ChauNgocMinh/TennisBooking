using TennisBooking.ViewModels;

namespace TennisBooking.Services;

public interface IAdminManagementService
{
    Task<AdminDashboardViewModel> GetDashboardAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<AdminCourtViewModel>> GetCourtsAsync(CancellationToken cancellationToken = default);
    Task<AdminCourtViewModel?> GetCourtAsync(Guid id, CancellationToken cancellationToken = default);
    Task SaveCourtAsync(AdminCourtViewModel model, CancellationToken cancellationToken = default);
    Task<bool> DeleteCourtAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<AdminCoachViewModel>> GetCoachesAsync(CancellationToken cancellationToken = default);
    Task<AdminCoachViewModel?> GetCoachAsync(Guid id, CancellationToken cancellationToken = default);
    Task SaveCoachAsync(AdminCoachViewModel model, CancellationToken cancellationToken = default);
    Task<bool> DeleteCoachAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<AdminNewsViewModel>> GetNewsAsync(CancellationToken cancellationToken = default);
    Task<AdminNewsViewModel?> GetNewsItemAsync(Guid id, CancellationToken cancellationToken = default);
    Task SaveNewsAsync(AdminNewsViewModel model, CancellationToken cancellationToken = default);
    Task<bool> DeleteNewsAsync(Guid id, CancellationToken cancellationToken = default);
}
