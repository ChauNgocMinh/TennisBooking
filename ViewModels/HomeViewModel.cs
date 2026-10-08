namespace TennisBooking.ViewModels;

public sealed class HomeViewModel
{
    public IReadOnlyCollection<NewsViewModel> LatestNews { get; init; } = [];
}
