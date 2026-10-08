using TennisBooking.Entities;

namespace TennisBooking.Data;

public static class NewsSeedData
{
    public static IReadOnlyCollection<News> Items { get; } =
    [
        new News
        {
            Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
            TitleVi = "ACE Community Cup trở lại với mùa giải mới",
            TitleEn = "ACE Community Cup returns for a new season",
            BannerImageUrl = "/media/news/ace-community-cup.jpg",
            ShortContentVi = "Giải đấu giao lưu dành cho người chơi ở nhiều trình độ.",
            ShortContentEn = "A friendly tournament for players of all levels.",
            ContentVi = "Giải đấu giao lưu dành cho người chơi ở nhiều trình độ sẽ diễn ra trong tháng này.",
            ContentEn = "The friendly tournament for players of all levels returns this month.",
            PublishedAt = new DateTime(2026, 10, 1),
            CreateFrom = Guid.Empty,
            UpdateFrom = Guid.Empty
        },
        new News
        {
            Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
            TitleVi = "Mở rộng khung giờ sân tập buổi tối",
            TitleEn = "More evening training court hours",
            BannerImageUrl = "/media/news/evening-training.jpg",
            ShortContentVi = "Thêm khung giờ buổi tối để bạn duy trì lịch tập đều đặn.",
            ShortContentEn = "More evening slots to help you keep a consistent training routine.",
            ContentVi = "ACE bổ sung thêm các khung giờ buổi tối để bạn dễ dàng duy trì lịch tập đều đặn.",
            ContentEn = "ACE adds more evening slots so you can keep a consistent training routine.",
            PublishedAt = new DateTime(2026, 9, 24),
            CreateFrom = Guid.Empty,
            UpdateFrom = Guid.Empty
        },
        new News
        {
            Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
            TitleVi = "Ưu đãi dành cho học viên mới",
            TitleEn = "A welcome offer for new students",
            BannerImageUrl = "/media/news/new-student-offer.jpg",
            ShortContentVi = "Ưu đãi mới dành cho học viên lần đầu đến với ACE.",
            ShortContentEn = "A warm welcome offer for new ACE students.",
            ContentVi = "Đăng ký buổi học đầu tiên để nhận tư vấn lộ trình phù hợp từ đội ngũ ACE.",
            ContentEn = "Book your first session and receive a tailored training consultation from ACE.",
            PublishedAt = new DateTime(2026, 9, 18),
            CreateFrom = Guid.Empty,
            UpdateFrom = Guid.Empty
        }
    ];
}
