using Microsoft.AspNetCore.Mvc;

namespace TennisBooking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
