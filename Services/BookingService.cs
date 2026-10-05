using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TennisBooking.Data;
using TennisBooking.Entities;
using TennisBooking.ViewModels;

namespace TennisBooking.Services;

public sealed class BookingService(ApplicationDbContext context) : IBookingService
{
    private const int OpeningHour = 8;
    private const int ClosingHour = 22;

    public async Task<BookingAvailabilityViewModel> GetAvailabilityAsync(
        DateTime weekStart,
        string classType,
        CancellationToken cancellationToken = default)
    {
        var court = await GetCourtAsync(classType, cancellationToken);
        var normalizedWeekStart = weekStart.Date;
        var weekEnd = normalizedWeekStart.AddDays(7);

        var bookedSlots = await context.CourtSlots
            .AsNoTracking()
            .Where(slot => slot.CourtId == court.Id
                && slot.SlotStart >= normalizedWeekStart
                && slot.SlotStart < weekEnd
                && slot.BookingId != null
                && slot.Booking != null
                && slot.Booking.Status)
            .OrderBy(slot => slot.SlotStart)
            .Select(slot => slot.SlotStart)
            .ToListAsync(cancellationToken);

        return new BookingAvailabilityViewModel
        {
            CourtId = court.Id,
            CourtType = court.CourtType,
            WeekStart = normalizedWeekStart,
            BookedSlots = bookedSlots
        };
    }

    public async Task<BookingCreateResult> CreateAsync(
        BookingRequest request,
        CancellationToken cancellationToken = default)
    {
        var dates = ValidateAndNormalize(request);
        var court = await GetCourtAsync(request.ClassType, cancellationToken);
        await using var transaction = await context.Database.BeginTransactionAsync(
            IsolationLevel.Serializable,
            cancellationToken);

        var requestedSlots = dates
            .SelectMany(date => Enumerable.Range(request.StartHour, request.EndHour - request.StartHour)
                .Select(hour => date.AddHours(hour)))
            .ToArray();

        var existingSlots = await context.CourtSlots
            .AsNoTracking()
            .Where(slot => slot.CourtId == court.Id
                && requestedSlots.Contains(slot.SlotStart)
                && slot.BookingId != null
                && slot.Booking != null
                && slot.Booking.Status)
            .Select(slot => slot.SlotStart)
            .ToListAsync(cancellationToken);

        if (existingSlots.Count > 0)
        {
            throw new BookingConflictException("One or more requested time slots are already booked.");
        }

        var bookings = dates.Select(date => new Booking
        {
            Id = Guid.NewGuid(),
            CourtId = court.Id,
            CustomerName = request.CustomerName.Trim(),
            PhoneNumber = request.PhoneNumber.Trim(),
            StartTime = date.AddHours(request.StartHour),
            EndTime = date.AddHours(request.EndHour),
            Status = true,
            CreateFrom = Guid.Empty,
            UpdateFrom = Guid.Empty
        }).ToArray();

        var slots = bookings
            .SelectMany(booking => Enumerable.Range(request.StartHour, request.EndHour - request.StartHour)
                .Select(hour => new CourtSlot
                {
                    Id = Guid.NewGuid(),
                    CourtId = court.Id,
                    BookingId = booking.Id,
                    SlotStart = booking.StartTime.Date.AddHours(hour),
                    CreateFrom = Guid.Empty,
                    UpdateFrom = Guid.Empty
                }))
            .ToArray();

        context.Bookings.AddRange(bookings);
        context.CourtSlots.AddRange(slots);

        try
        {
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (DbUpdateException exception) when (IsUniqueConstraintViolation(exception))
        {
            throw new BookingConflictException("One or more requested time slots are already booked.");
        }

        return new BookingCreateResult
        {
            BookingIds = bookings.Select(booking => booking.Id).ToArray()
        };
    }

    private async Task<TennisCourt> GetCourtAsync(string classType, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(classType))
        {
            throw new BookingValidationException("Class type is required.");
        }

        var normalizedClassType = classType.Trim().ToLowerInvariant();

        return await context.TennisCourts
            .AsNoTracking()
            .Where(court => court.CourtType == normalizedClassType)
            .OrderBy(court => court.Id)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new BookingCourtNotFoundException();
    }

    private static IReadOnlyList<DateTime> ValidateAndNormalize(BookingRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.CustomerName))
        {
            throw new BookingValidationException("Customer name is required.");
        }

        if (string.IsNullOrWhiteSpace(request.PhoneNumber))
        {
            throw new BookingValidationException("Phone number is required.");
        }

        if (string.IsNullOrWhiteSpace(request.ClassType))
        {
            throw new BookingValidationException("Class type is required.");
        }

        if (request.StartHour < OpeningHour || request.StartHour > ClosingHour - 1
            || request.EndHour < OpeningHour + 1 || request.EndHour > ClosingHour
            || request.EndHour <= request.StartHour)
        {
            throw new BookingValidationException("The requested time range is invalid.");
        }

        var today = DateTime.Today;
        var dayOfWeek = today.DayOfWeek;
        var weekStart = today.AddDays(dayOfWeek == DayOfWeek.Sunday ? -6 : 1 - (int)dayOfWeek);
        var weekEnd = weekStart.AddDays(7);
        var dates = request.Dates
            .Select(date => date.Date)
            .Distinct()
            .OrderBy(date => date)
            .ToArray();

        if (dates.Length == 0)
        {
            throw new BookingValidationException("At least one booking date is required.");
        }

        if (dates.Any(date => date < today || date >= weekEnd))
        {
            throw new BookingValidationException("Only dates in the current week can be booked.");
        }

        return dates;
    }

    private static bool IsUniqueConstraintViolation(DbUpdateException exception)
    {
        return exception.InnerException is SqlException sqlException
            && sqlException.Errors.Cast<SqlError>().Any(error => error.Number is 2601 or 2627);
    }
}
