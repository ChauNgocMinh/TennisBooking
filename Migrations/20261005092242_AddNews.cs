using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TennisBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleVi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    BannerImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContentVi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreateFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "BannerImageUrl", "ContentEn", "ContentVi", "CreateFrom", "Link", "PublishedAt", "TitleEn", "TitleVi", "UpdateFrom" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), "/media/news/ace-community-cup.jpg", "The friendly tournament for players of all levels returns this month.", "Giải đấu giao lưu dành cho người chơi ở nhiều trình độ sẽ diễn ra trong tháng này.", new Guid("00000000-0000-0000-0000-000000000000"), "https://example.com/ace-community-cup", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ACE Community Cup returns for a new season", "ACE Community Cup trở lại với mùa giải mới", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "/media/news/evening-training.jpg", "ACE adds more evening slots so you can keep a consistent training routine.", "ACE bổ sung thêm các khung giờ buổi tối để bạn dễ dàng duy trì lịch tập đều đặn.", new Guid("00000000-0000-0000-0000-000000000000"), "https://example.com/evening-training", new DateTime(2026, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "More evening training court hours", "Mở rộng khung giờ sân tập buổi tối", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "/media/news/new-student-offer.jpg", "Book your first session and receive a tailored training consultation from ACE.", "Đăng ký buổi học đầu tiên để nhận tư vấn lộ trình phù hợp từ đội ngũ ACE.", new Guid("00000000-0000-0000-0000-000000000000"), "https://example.com/new-student-offer", new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "A welcome offer for new students", "Ưu đãi dành cho học viên mới", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_PublishedAt",
                table: "News",
                column: "PublishedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
