using TennisBooking.ViewModels;

namespace TennisBooking.Services;

public interface INewsService
{
    Task<IReadOnlyCollection<NewsViewModel>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<NewsViewModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<NewsViewModel>> GetRelatedAsync(Guid id, int take = 3, CancellationToken cancellationToken = default);
}
