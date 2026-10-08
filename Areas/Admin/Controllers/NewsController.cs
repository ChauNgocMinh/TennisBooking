using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TennisBooking.Services;
using TennisBooking.ViewModels;

namespace TennisBooking.Areas.Admin.Controllers;

[Area("Admin"), Authorize]
public sealed class NewsController(IAdminManagementService service) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken) => View(await service.GetNewsAsync(cancellationToken));
    public IActionResult Create() => View(new AdminNewsViewModel());
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        var model = await service.GetNewsItemAsync(id, cancellationToken);
        return model is null ? NotFound() : View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(AdminNewsViewModel model, CancellationToken cancellationToken)
    {
        if (model.Id == Guid.Empty && (model.BannerImage is null || model.BannerImage.Length == 0))
        {
            ModelState.AddModelError(nameof(model.BannerImage), "admin.bannerRequired");
        }
        if (!ModelState.IsValid) return View(model.Id == Guid.Empty ? "Create" : "Edit", model);
        try
        {
            await service.SaveNewsAsync(model, cancellationToken);
        }
        catch (InvalidOperationException exception)
        {
            ModelState.AddModelError(nameof(model.BannerImage), exception.Message);
            return View(model.Id == Guid.Empty ? "Create" : "Edit", model);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await service.DeleteNewsAsync(id, cancellationToken);
        return RedirectToAction(nameof(Index));
    }
}
