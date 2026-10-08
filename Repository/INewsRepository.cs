using TennisBooking.Entities;

namespace TennisBooking.Repository;

public interface INewsRepository
{
    Task<IReadOnlyCollection<News>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<News?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
