using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TennisBooking.Services;

namespace TennisBooking.Areas.Admin.Controllers;

[Area("Admin"), Authorize]
public sealed class DashboardController(IAdminManagementService service) : Controller
{
    [HttpGet("admin/dashboard")]
    public async Task<IActionResult> Index(CancellationToken cancellationToken) => View(await service.GetDashboardAsync(cancellationToken));
}
