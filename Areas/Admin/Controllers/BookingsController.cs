using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TennisBooking.Data;
using TennisBooking.ViewModels;

namespace TennisBooking.Areas.Admin.Controllers;

[Area("Admin"), Authorize]
public sealed class BookingsController(ApplicationDbContext context) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var items = await context.Bookings
            .AsNoTracking()
            .Include(b => b.Court)
            .OrderByDescending(b => b.StartTime)
            .Select(b => new AdminBookingViewModel
            {
                Id = b.Id,
                CourtName = b.Court.Name,
                CustomerName = b.CustomerName,
                PhoneNumber = b.PhoneNumber,
                StartTime = b.StartTime,
                EndTime = b.EndTime,
                Status = b.Status
            })
            .ToListAsync(cancellationToken);

        return View(items);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Confirm(Guid id, CancellationToken cancellationToken)
    {
        var booking = await context.Bookings.FindAsync([id], cancellationToken);
        if (booking is null) return NotFound();
        booking.Status = TennisBooking.Common.Enum.BookingStatus.Confirmed;
        await context.SaveChangesAsync(cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(Guid id, CancellationToken cancellationToken)
    {
        var booking = await context.Bookings.FindAsync([id], cancellationToken);
        if (booking is null) return NotFound();
        booking.Status = TennisBooking.Common.Enum.BookingStatus.Cancelled;
        await context.SaveChangesAsync(cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> SetPending(Guid id, CancellationToken cancellationToken)
    {
        var booking = await context.Bookings.FindAsync([id], cancellationToken);
        if (booking is null) return NotFound();
        booking.Status = TennisBooking.Common.Enum.BookingStatus.Pending;
        await context.SaveChangesAsync(cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var booking = await context.Bookings.FindAsync([id], cancellationToken);
        if (booking is null) return NotFound();
        context.Bookings.Remove(booking);
        try
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException)
        {
            TempData["AdminError"] = "admin.deleteConflict";
        }
        return RedirectToAction(nameof(Index));
    }
}
