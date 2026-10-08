using Microsoft.AspNetCore.Identity;

namespace TennisBooking.Data;

public static class AdminSeedData
{
    public static async Task SeedAsync(IServiceProvider services, IConfiguration configuration)
    {
        var email = configuration["Admin:Email"];
        var password = configuration["Admin:Password"];
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password)) return;

        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        if (await userManager.FindByEmailAsync(email) is not null) return;

        var result = await userManager.CreateAsync(
            new IdentityUser { UserName = email, Email = email, EmailConfirmed = true },
            password);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Unable to create the configured admin account.");
        }
    }
}
