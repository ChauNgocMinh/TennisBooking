using Microsoft.AspNetCore.Mvc;
using TennisBooking.Services;
using TennisBooking.ViewModels;

namespace TennisBooking.Controllers;

public class HomeController(INewsService newsService) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        return View(new HomeViewModel
        {
            LatestNews = (await newsService.GetAllAsync(cancellationToken)).Take(3).ToList()
        });
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
