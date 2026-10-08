using System.ComponentModel.DataAnnotations;

namespace TennisBooking.ViewModels;

public sealed class AdminLoginViewModel
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public string? ReturnUrl { get; set; }
}

public sealed class AdminBookingViewModel
{
    public Guid Id { get; set; }

    public string CourtName { get; set; } = string.Empty;

    public string CustomerName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public TennisBooking.Common.Enum.BookingStatus Status { get; set; }
}

public sealed class AdminDashboardViewModel
{
    public int CourtCount { get; init; }
    public int CoachCount { get; init; }
    public int NewsCount { get; init; }
}

public sealed class AdminCourtViewModel
{
    public Guid Id { get; set; }

    [Required, StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required, StringLength(30)]
    public string CourtType { get; set; } = string.Empty;

    [Range(typeof(decimal), "0", "999999999")]
    public decimal Price { get; set; }
}

public sealed class AdminCoachViewModel
{
    public Guid Id { get; set; }

    [Required, StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string ImageUrl { get; set; } = string.Empty;

    public IFormFile? ImageFile { get; set; }

    [Required, StringLength(500)]
    public string Experience { get; set; } = string.Empty;

    [Required, StringLength(1000)]
    public string Certificates { get; set; } = string.Empty;

    [Required, StringLength(1000)]
    public string Achievements { get; set; } = string.Empty;

    [Required]
    public string IntroductionHtml { get; set; } = string.Empty;
}

public sealed class AdminNewsViewModel
{
    public Guid Id { get; set; }

    [Required, StringLength(300)]
    public string TitleVi { get; set; } = string.Empty;

    [Required, StringLength(300)]
    public string TitleEn { get; set; } = string.Empty;

    [StringLength(500)]
    public string BannerImageUrl { get; set; } = string.Empty;

    public IFormFile? BannerImage { get; set; }

    [Required, StringLength(500)]
    public string ShortContentVi { get; set; } = string.Empty;

    [Required, StringLength(500)]
    public string ShortContentEn { get; set; } = string.Empty;

    [Required]
    public string ContentVi { get; set; } = string.Empty;

    [Required]
    public string ContentEn { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    public DateTime PublishedAt { get; set; } = DateTime.Now;
}
