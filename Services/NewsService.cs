using TennisBooking.Repository;
using TennisBooking.ViewModels;

namespace TennisBooking.Services;

public sealed class NewsService(INewsRepository newsRepository) : INewsService
{
    public async Task<IReadOnlyCollection<NewsViewModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var news = await newsRepository.GetAllAsync(cancellationToken);

        return news
            .Select(item => new NewsViewModel
            {
                Id = item.Id,
                TitleVi = item.TitleVi,
                TitleEn = item.TitleEn,
                BannerImageUrl = item.BannerImageUrl,
                ShortContentVi = item.ShortContentVi,
                ShortContentEn = item.ShortContentEn,
                ContentVi = item.ContentVi,
                ContentEn = item.ContentEn,
                PublishedAt = item.PublishedAt
            })
            .ToList();
    }

    public async Task<NewsViewModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await newsRepository.GetByIdAsync(id, cancellationToken);
        return item is null ? null : Map(item);
    }

    public async Task<IReadOnlyCollection<NewsViewModel>> GetRelatedAsync(Guid id, int take = 3, CancellationToken cancellationToken = default)
    {
        return (await GetAllAsync(cancellationToken))
            .Where(item => item.Id != id)
            .Take(take)
            .ToList();
    }

    private static NewsViewModel Map(Entities.News item)
    {
        return new NewsViewModel
        {
            Id = item.Id,
            TitleVi = item.TitleVi,
            TitleEn = item.TitleEn,
            BannerImageUrl = item.BannerImageUrl,
            ShortContentVi = item.ShortContentVi,
            ShortContentEn = item.ShortContentEn,
            ContentVi = item.ContentVi,
            ContentEn = item.ContentEn,
            PublishedAt = item.PublishedAt
        };
    }
}
