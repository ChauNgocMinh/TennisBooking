using Microsoft.AspNetCore.Mvc;
using TennisBooking.Services;
using TennisBooking.ViewModels;

namespace TennisBooking.Controllers;

public class BookingController(IBookingService bookingService, ILogger<BookingController> logger) : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Coach");
    }

    [HttpGet]
    public async Task<IActionResult> Availability(DateTime? weekStart, string? classType, CancellationToken cancellationToken)
    {
        try
        {
            var requestedWeekStart = (weekStart ?? DateTime.Today).Date;
            var monday = requestedWeekStart.AddDays(-(int)(requestedWeekStart.DayOfWeek == DayOfWeek.Sunday
                ? 6
                : requestedWeekStart.DayOfWeek - DayOfWeek.Monday));
            return Ok(await bookingService.GetAvailabilityAsync(monday, classType ?? string.Empty, cancellationToken));
        }
        catch (BookingCourtNotFoundException exception)
        {
            return NotFound(new { message = exception.Message });
        }
        catch (BookingValidationException exception)
        {
            return BadRequest(new { message = exception.Message });
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unable to load booking availability.");
            return Problem("Unable to load booking availability.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookingRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = "Booking details are invalid." });
        }

        try
        {
            var result = await bookingService.CreateAsync(request, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, result);
        }
        catch (BookingValidationException exception)
        {
            return BadRequest(new { message = exception.Message });
        }
        catch (BookingCourtNotFoundException exception)
        {
            return NotFound(new { message = exception.Message });
        }
        catch (BookingConflictException exception)
        {
            return Conflict(new { message = exception.Message });
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unable to create booking request.");
            return Problem("Unable to create the booking request.");
        }
    }
}
