namespace TennisBooking.Services;

public sealed class BookingConflictException(string message) : Exception(message);

public sealed class BookingValidationException(string message) : Exception(message);

public sealed class BookingCourtNotFoundException() : Exception("No tennis court is available.");
