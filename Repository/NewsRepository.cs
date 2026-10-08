using Microsoft.EntityFrameworkCore;
using TennisBooking.Data;
using TennisBooking.Entities;

namespace TennisBooking.Repository;

public sealed class NewsRepository(ApplicationDbContext context) : INewsRepository
{
    public async Task<IReadOnlyCollection<News>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.News
            .AsNoTracking()
            .OrderByDescending(news => news.PublishedAt)
            .ThenBy(news => news.TitleVi)
            .ToListAsync(cancellationToken);
    }

    public async Task<News?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.News
            .AsNoTracking()
            .FirstOrDefaultAsync(news => news.Id == id, cancellationToken);
    }
}
