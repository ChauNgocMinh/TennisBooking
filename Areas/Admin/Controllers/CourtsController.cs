using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TennisBooking.Services;
using TennisBooking.ViewModels;

namespace TennisBooking.Areas.Admin.Controllers;

[Area("Admin"), Authorize]
public sealed class CourtsController(IAdminManagementService service) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken) => View(await service.GetCourtsAsync(cancellationToken));
    public IActionResult Create() => View(new AdminCourtViewModel());
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken) => await Form(id, cancellationToken);

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(AdminCourtViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View(model.Id == Guid.Empty ? "Create" : "Edit", model);
        await service.SaveCourtAsync(model, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        if (!await service.DeleteCourtAsync(id, cancellationToken)) TempData["AdminError"] = "admin.deleteConflict";
        return RedirectToAction(nameof(Index));
    }

    private async Task<IActionResult> Form(Guid id, CancellationToken cancellationToken)
    {
        var model = await service.GetCourtAsync(id, cancellationToken);
        return model is null ? NotFound() : View(model);
    }
}
