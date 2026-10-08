using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TennisBooking.ViewModels;

namespace TennisBooking.Areas.Admin.Controllers;

[Area("Admin")]
public sealed class AccountController(SignInManager<IdentityUser> signInManager) : Controller
{
    [HttpGet("admin/login")]
    public IActionResult Login(string? returnUrl = null) => View(new AdminLoginViewModel { ReturnUrl = returnUrl });

    [HttpPost("admin/login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AdminLoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        if (result.Succeeded) return LocalRedirect(string.IsNullOrWhiteSpace(model.ReturnUrl) ? "/admin/dashboard" : model.ReturnUrl);
        ModelState.AddModelError(string.Empty, "admin.login.invalid");
        return View(model);
    }

    [HttpPost("admin/logout")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction(nameof(Login));
    }
}
