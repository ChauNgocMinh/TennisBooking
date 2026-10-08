using Microsoft.AspNetCore.Mvc;
using TennisBooking.Services;
using TennisBooking.ViewModels;

namespace TennisBooking.Controllers;

public class NewsController(INewsService newsService) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        return View(await newsService.GetAllAsync(cancellationToken));
    }

    public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
    {
        var news = await newsService.GetByIdAsync(id, cancellationToken);
        if (news is null) return NotFound();

        return View(new NewsDetailsViewModel
        {
            News = news,
            RelatedNews = await newsService.GetRelatedAsync(id, 3, cancellationToken)
        });
    }

    public IActionResult Tournament() => View();

    public IActionResult TrainingCourt() => View();

    public IActionResult Promotion() => View();
}
