using Microsoft.AspNetCore.Mvc;

namespace TennisBooking.Controllers;

public class NewsController : Controller
{
    public IActionResult Tournament() => View();

    public IActionResult TrainingCourt() => View();

    public IActionResult Promotion() => View();
}
