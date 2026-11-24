using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TennisBooking.Data;
using TennisBooking.ViewModels;

namespace TennisBooking.Areas.Admin.Controllers;

[Area("Admin"), Authorize]
public sealed class BookingsController(ApplicationDbContext context) : Controller
{
    public async Task<IActionResult> Index(int page = 1, CancellationToken cancellationToken = default)
    {
        const int pageSize = 10;
        page = Math.Max(1, page);
        var query = context.Bookings
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
            });
        var totalItems = await query.CountAsync(cancellationToken);
        var totalPages = Math.Max(1, (int)Math.Ceiling(totalItems / (double)pageSize));
        page = Math.Min(page, totalPages);
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

        return View(new AdminPagedViewModel<AdminBookingViewModel>
        {
            Items = items,
            Pagination = new AdminPaginationViewModel { Page = page, TotalPages = totalPages }
        });
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
            TempData["AdminError"] = "Không thể xóa dữ liệu đặt lịch đang được sử dụng.";
        }
        return RedirectToAction(nameof(Index));
    }
}
