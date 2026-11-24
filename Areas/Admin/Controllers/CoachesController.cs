using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TennisBooking.Services;
using TennisBooking.ViewModels;

namespace TennisBooking.Areas.Admin.Controllers;

[Area("Admin"), Authorize]
public sealed class CoachesController(IAdminManagementService service) : Controller
{
    public async Task<IActionResult> Index(int page = 1, CancellationToken cancellationToken = default) => View(await service.GetCoachesAsync(page, 10, cancellationToken));
    public IActionResult Create() => View(new AdminCoachViewModel());
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        var model = await service.GetCoachAsync(id, cancellationToken);
        return model is null ? NotFound() : View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(AdminCoachViewModel model, CancellationToken cancellationToken)
    {
        if (model.Id == Guid.Empty && (model.ImageFile is null || model.ImageFile.Length == 0))
        {
            ModelState.AddModelError(nameof(model.ImageFile), "Vui lòng chọn ảnh huấn luyện viên.");
        }
        if (!ModelState.IsValid) return View(model.Id == Guid.Empty ? "Create" : "Edit", model);
        try
        {
            await service.SaveCoachAsync(model, cancellationToken);
        }
        catch (InvalidOperationException exception)
        {
            ModelState.AddModelError(nameof(model.ImageFile), exception.Message);
            return View(model.Id == Guid.Empty ? "Create" : "Edit", model);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await service.DeleteCoachAsync(id, cancellationToken);
        return RedirectToAction(nameof(Index));
    }
}
