using TennisBooking.Common;

namespace TennisBooking.Entities;

public class Coach : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public string Experience { get; set; } = string.Empty;

    public string Certificates { get; set; } = string.Empty;

    public string Achievements { get; set; } = string.Empty;

    public string IntroductionHtml { get; set; } = string.Empty;
}
