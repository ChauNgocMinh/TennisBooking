namespace TennisBooking.ViewModels;

public class NewsViewModel
{
    public Guid Id { get; set; }

    public string TitleVi { get; set; } = string.Empty;

    public string TitleEn { get; set; } = string.Empty;

    public string BannerImageUrl { get; set; } = string.Empty;

    public string ShortContentVi { get; set; } = string.Empty;

    public string ShortContentEn { get; set; } = string.Empty;

    public string ContentVi { get; set; } = string.Empty;

    public string ContentEn { get; set; } = string.Empty;

    public DateTime PublishedAt { get; set; }
}

public sealed class NewsDetailsViewModel
{
    public NewsViewModel News { get; init; } = new();

    public IReadOnlyCollection<NewsViewModel> RelatedNews { get; init; } = [];
}
