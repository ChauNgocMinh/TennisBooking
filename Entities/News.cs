using TennisBooking.Common;

namespace TennisBooking.Entities;

public class News : BaseModel
{
    public string TitleVi { get; set; } = string.Empty;

    public string TitleEn { get; set; } = string.Empty;

    public string BannerImageUrl { get; set; } = string.Empty;

    public string ShortContentVi { get; set; } = string.Empty;

    public string ShortContentEn { get; set; } = string.Empty;

    public string ContentVi { get; set; } = string.Empty;

    public string ContentEn { get; set; } = string.Empty;

    public DateTime PublishedAt { get; set; }
}
