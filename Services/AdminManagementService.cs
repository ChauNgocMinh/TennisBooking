using Microsoft.EntityFrameworkCore;
using TennisBooking.Data;
using TennisBooking.Entities;
using TennisBooking.ViewModels;

namespace TennisBooking.Services;

public sealed class AdminManagementService(ApplicationDbContext context, IWebHostEnvironment environment) : IAdminManagementService
{
    public async Task<AdminDashboardViewModel> GetDashboardAsync(CancellationToken cancellationToken = default) => new()
    {
        CourtCount = await context.TennisCourts.CountAsync(cancellationToken),
        CoachCount = await context.Coaches.CountAsync(cancellationToken),
        NewsCount = await context.News.CountAsync(cancellationToken)
    };

    public async Task<IReadOnlyCollection<AdminCourtViewModel>> GetCourtsAsync(CancellationToken cancellationToken = default) =>
        await context.TennisCourts.AsNoTracking().OrderBy(court => court.Name).Select(court => ToViewModel(court)).ToListAsync(cancellationToken);

    public async Task<AdminCourtViewModel?> GetCourtAsync(Guid id, CancellationToken cancellationToken = default) =>
        await context.TennisCourts.AsNoTracking().Where(court => court.Id == id).Select(court => ToViewModel(court)).FirstOrDefaultAsync(cancellationToken);

    public async Task SaveCourtAsync(AdminCourtViewModel model, CancellationToken cancellationToken = default)
    {
        var entity = model.Id == Guid.Empty ? new TennisCourt { Id = Guid.NewGuid(), CreateFrom = Guid.Empty } : await context.TennisCourts.FirstAsync(court => court.Id == model.Id, cancellationToken);
        entity.Name = model.Name.Trim();
        entity.Description = model.Description.Trim();
        entity.CourtType = model.CourtType.Trim().ToLowerInvariant();
        entity.Price = model.Price;
        entity.UpdateFrom = Guid.Empty;
        if (model.Id == Guid.Empty) context.TennisCourts.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> DeleteCourtAsync(Guid id, CancellationToken cancellationToken = default) => DeleteAsync(context.TennisCourts, id, cancellationToken);

    public async Task<IReadOnlyCollection<AdminCoachViewModel>> GetCoachesAsync(CancellationToken cancellationToken = default) =>
        await context.Coaches.AsNoTracking().OrderBy(coach => coach.Name).Select(coach => ToViewModel(coach)).ToListAsync(cancellationToken);

    public async Task<AdminCoachViewModel?> GetCoachAsync(Guid id, CancellationToken cancellationToken = default) =>
        await context.Coaches.AsNoTracking().Where(coach => coach.Id == id).Select(coach => ToViewModel(coach)).FirstOrDefaultAsync(cancellationToken);

    public async Task SaveCoachAsync(AdminCoachViewModel model, CancellationToken cancellationToken = default)
    {
        var entity = model.Id == Guid.Empty ? new Coach { Id = Guid.NewGuid(), CreateFrom = Guid.Empty } : await context.Coaches.FirstAsync(coach => coach.Id == model.Id, cancellationToken);
        entity.Name = model.Name.Trim(); entity.ImageUrl = await SaveImageAsync(model.ImageFile, model.ImageUrl, "coaches", cancellationToken); entity.Experience = model.Experience.Trim();
        entity.Certificates = model.Certificates.Trim(); entity.Achievements = model.Achievements.Trim(); entity.IntroductionHtml = model.IntroductionHtml.Trim(); entity.UpdateFrom = Guid.Empty;
        if (model.Id == Guid.Empty) context.Coaches.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> DeleteCoachAsync(Guid id, CancellationToken cancellationToken = default) => DeleteAsync(context.Coaches, id, cancellationToken);

    public async Task<IReadOnlyCollection<AdminNewsViewModel>> GetNewsAsync(CancellationToken cancellationToken = default) =>
        await context.News.AsNoTracking().OrderByDescending(news => news.PublishedAt).Select(news => ToViewModel(news)).ToListAsync(cancellationToken);

    public async Task<AdminNewsViewModel?> GetNewsItemAsync(Guid id, CancellationToken cancellationToken = default) =>
        await context.News.AsNoTracking().Where(news => news.Id == id).Select(news => ToViewModel(news)).FirstOrDefaultAsync(cancellationToken);

    public async Task SaveNewsAsync(AdminNewsViewModel model, CancellationToken cancellationToken = default)
    {
        var entity = model.Id == Guid.Empty ? new News { Id = Guid.NewGuid(), CreateFrom = Guid.Empty } : await context.News.FirstAsync(news => news.Id == model.Id, cancellationToken);
        entity.TitleVi = model.TitleVi.Trim(); entity.TitleEn = model.TitleEn.Trim(); entity.BannerImageUrl = await SaveBannerAsync(model, entity.BannerImageUrl, cancellationToken);
        entity.ShortContentVi = model.ShortContentVi.Trim(); entity.ShortContentEn = model.ShortContentEn.Trim();
        entity.ContentVi = model.ContentVi.Trim(); entity.ContentEn = model.ContentEn.Trim(); entity.PublishedAt = DateTime.Now; entity.UpdateFrom = Guid.Empty;
        if (model.Id == Guid.Empty) context.News.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> DeleteNewsAsync(Guid id, CancellationToken cancellationToken = default) => DeleteAsync(context.News, id, cancellationToken);

    private async Task<bool> DeleteAsync<TEntity>(DbSet<TEntity> set, Guid id, CancellationToken cancellationToken) where TEntity : class
    {
        var entity = await set.FindAsync([id], cancellationToken);
        if (entity is null) return false;
        set.Remove(entity);
        try { await context.SaveChangesAsync(cancellationToken); return true; }
        catch (DbUpdateException) { context.Entry(entity).State = EntityState.Unchanged; return false; }
    }

    private static AdminCourtViewModel ToViewModel(TennisCourt court) => new() { Id = court.Id, Name = court.Name ?? string.Empty, Description = court.Description ?? string.Empty, CourtType = court.CourtType, Price = court.Price };
    private static AdminCoachViewModel ToViewModel(Coach coach) => new() { Id = coach.Id, Name = coach.Name, ImageUrl = coach.ImageUrl, Experience = coach.Experience, Certificates = coach.Certificates, Achievements = coach.Achievements, IntroductionHtml = coach.IntroductionHtml };
    private async Task<string> SaveBannerAsync(AdminNewsViewModel model, string existingUrl, CancellationToken cancellationToken)
    {
        return await SaveImageAsync(model.BannerImage, existingUrl, "news", cancellationToken);
    }

    private async Task<string> SaveImageAsync(IFormFile? file, string existingUrl, string folderName, CancellationToken cancellationToken)
    {
        if (file is null || file.Length == 0) return existingUrl;
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
        if (!allowedExtensions.Contains(extension) || file.Length > 5 * 1024 * 1024)
        {
            throw new InvalidOperationException("The image must be JPG, PNG, WEBP, or GIF and no larger than 5 MB.");
        }

        var folder = Path.Combine(environment.WebRootPath, "media", folderName);
        Directory.CreateDirectory(folder);
        var fileName = $"{Guid.NewGuid():N}{extension}";
        await using var stream = File.Create(Path.Combine(folder, fileName));
        await file.CopyToAsync(stream, cancellationToken);
        return $"/media/{folderName}/{fileName}";
    }

    private static AdminNewsViewModel ToViewModel(News news) => new() { Id = news.Id, TitleVi = news.TitleVi, TitleEn = news.TitleEn, BannerImageUrl = news.BannerImageUrl, ShortContentVi = news.ShortContentVi, ShortContentEn = news.ShortContentEn, ContentVi = news.ContentVi, ContentEn = news.ContentEn, PublishedAt = news.PublishedAt };
}
