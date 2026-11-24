using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TennisBooking.Data;
using TennisBooking.Repository;
using TennisBooking.Services;

Directory.CreateDirectory("logs");

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(
        "logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 30,
        shared: true,
        flushToDiskInterval: TimeSpan.FromSeconds(1))
    .CreateBootstrapLogger();

try
{
    Log.Information("========== APPLICATION STARTING ==========");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) =>
    {
        configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(
                "logs/log-.txt",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 30,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1));
    });

    // =========================
    // Services
    // =========================

    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"))
            .ConfigureWarnings(w =>
                w.Ignore(
                    Microsoft.EntityFrameworkCore.Diagnostics
                        .RelationalEventId.PendingModelChangesWarning)));

    builder.Services.AddScoped<IBookingService, BookingService>();
    builder.Services.AddScoped<ICoachService, CoachService>();
    builder.Services.AddScoped<INewsRepository, NewsRepository>();
    builder.Services.AddScoped<INewsService, NewsService>();
    builder.Services.AddScoped<IAdminManagementService, AdminManagementService>();

    builder.Services
        .AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/admin/login";
        options.AccessDeniedPath = "/admin/login";
    });

    var app = builder.Build();

    // =========================
    // Database Migration + Seed
    // =========================

    try
    {
        Log.Information("Starting database migration...");

        using var scope = app.Services.CreateScope();

        var dbContext =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        Log.Information("Database connection: attempting connection...");

        var canConnect = await dbContext.Database.CanConnectAsync();

        Log.Information(
            "Database CanConnect result: {CanConnect}",
            canConnect);

        if (!canConnect)
        {
            Log.Error("Cannot connect to database.");
        }

        Log.Information("Running EF Core migrations...");

        await dbContext.Database.MigrateAsync();

        Log.Information("Database migration completed.");

        Log.Information("Starting AdminSeedData...");

        await AdminSeedData.SeedAsync(
            scope.ServiceProvider,
            scope.ServiceProvider.GetRequiredService<IConfiguration>());

        Log.Information("AdminSeedData completed.");
    }
    catch (Exception ex)
    {
        Log.Fatal(
            ex,
            "DATABASE MIGRATION / SEED FAILED");

        throw;
    }

    // =========================
    // HTTP Pipeline
    // =========================

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseSerilogRequestLogging();

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapRazorPages()
        .WithStaticAssets();

    Log.Information("Application started successfully.");

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(
        ex,
        "APPLICATION TERMINATED UNEXPECTEDLY");
}
finally
{
    Log.Information("========== APPLICATION STOPPED ==========");
    await Log.CloseAndFlushAsync();
}