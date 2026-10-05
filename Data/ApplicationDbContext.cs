using Microsoft.EntityFrameworkCore;
using TennisBooking.Common;
using TennisBooking.Entities;

namespace TennisBooking.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<TennisCourt> TennisCourts => Set<TennisCourt>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<CourtSlot> CourtSlots => Set<CourtSlot>();
    public DbSet<Coach> Coaches => Set<Coach>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TennisCourt>(entity =>
        {
            entity.Property(court => court.Name).HasMaxLength(200);
            entity.Property(court => court.CourtType).HasMaxLength(30).IsRequired();
            entity.Property(court => court.Price).HasColumnType("decimal(18,2)");
            entity.HasIndex(court => court.CourtType);

            entity.HasData(
                new TennisCourt
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Sân Private",
                    Description = "Sân dành cho lớp cá nhân.",
                    CourtType = "private",
                    Price = 300000,
                    CreateFrom = Guid.Empty,
                    UpdateFrom = Guid.Empty
                },
                new TennisCourt
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Sân Group",
                    Description = "Sân dành cho lớp nhóm.",
                    CourtType = "group",
                    Price = 450000,
                    CreateFrom = Guid.Empty,
                    UpdateFrom = Guid.Empty
                },
                new TennisCourt
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Sân Kids",
                    Description = "Sân dành cho lớp trẻ em.",
                    CourtType = "kids",
                    Price = 250000,
                    CreateFrom = Guid.Empty,
                    UpdateFrom = Guid.Empty
                });
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.Property(booking => booking.CustomerName).HasMaxLength(200).IsRequired();
            entity.Property(booking => booking.PhoneNumber).HasMaxLength(30).IsRequired();
            entity.HasOne(booking => booking.Court)
                .WithMany()
                .HasForeignKey(booking => booking.CourtId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CourtSlot>(entity =>
        {
            entity.HasIndex(slot => new { slot.CourtId, slot.SlotStart }).IsUnique();
            entity.HasOne(slot => slot.Booking)
                .WithMany(booking => booking.Slots)
                .HasForeignKey(slot => slot.BookingId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Coach>(entity =>
        {
            entity.Property(coach => coach.Name).HasMaxLength(200).IsRequired();
            entity.Property(coach => coach.ImageUrl).HasMaxLength(500).IsRequired();
            entity.Property(coach => coach.Experience).HasMaxLength(500).IsRequired();
            entity.Property(coach => coach.Certificates).HasMaxLength(1000).IsRequired();
            entity.Property(coach => coach.Achievements).HasMaxLength(1000).IsRequired();
            entity.Property(coach => coach.IntroductionHtml).HasColumnType("nvarchar(max)").IsRequired();

            entity.HasData(
                new Coach
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Name = "Nguyễn Minh Anh",
                    ImageUrl = "/media/coaches/coach-minh.png",
                    Experience = "12 năm huấn luyện tennis chuyên nghiệp",
                    Certificates = "PTR Professional · ITF Level 2",
                    Achievements = "Vô địch ACTN Coach Cup 2023 · Huấn luyện viên trẻ xuất sắc 2024",
                    IntroductionHtml = "<p>Anh Minh theo đuổi phương pháp huấn luyện rõ ràng, kỷ luật và phù hợp với mục tiêu riêng của từng học viên.</p><p>Anh đặc biệt mạnh về kỹ thuật nền tảng, chiến thuật đánh đơn và xây dựng giáo án dài hạn.</p>",
                    CreateFrom = Guid.Empty,
                    UpdateFrom = Guid.Empty
                },
                new Coach
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Name = "Trần Lan Phương",
                    ImageUrl = "/media/coaches/coach-lan.png",
                    Experience = "8 năm huấn luyện trẻ em và lớp nhóm",
                    Certificates = "ITF Level 1 · USTA Safe Play",
                    Achievements = "Phát triển hơn 100 học viên thiếu nhi · Diễn giả Tennis For Kids 2024",
                    IntroductionHtml = "<p>Cô Lan mang đến những buổi học giàu năng lượng, an toàn và dễ tiếp cận cho trẻ em ở mọi trình độ.</p><p>Cô chú trọng niềm vui vận động, sự tự tin và thói quen chơi thể thao bền vững.</p>",
                    CreateFrom = Guid.Empty,
                    UpdateFrom = Guid.Empty
                },
                new Coach
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    Name = "Lê Quốc Tuấn",
                    ImageUrl = "/media/coaches/coach-tuan.png",
                    Experience = "15 năm thi đấu và huấn luyện tennis",
                    Certificates = "PTR Professional · ITF Level 3 · CPR Certified",
                    Achievements = "Top 8 giải Tennis Open toàn quốc 2018 · Cố vấn chiến thuật ACTN",
                    IntroductionHtml = "<p>Anh Tuấn kết hợp kinh nghiệm thi đấu thực tế với tư duy chiến thuật để giúp học viên chơi chủ động và hiệu quả hơn.</p><p>Chuyên môn của anh tập trung vào nâng cao thể lực, giao bóng và xử lý điểm số áp lực.</p>",
                    CreateFrom = Guid.Empty,
                    UpdateFrom = Guid.Empty
                });
        });

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.FindProperty(nameof(BaseModel.CreatedAt)) is not null)
            {
                entityType.FindProperty(nameof(BaseModel.CreatedAt))!.SetDefaultValueSql("GETUTCDATE()");
                entityType.FindProperty(nameof(BaseModel.UpdatedAt))!.SetDefaultValueSql("GETUTCDATE()");
            }
        }
    }
}
