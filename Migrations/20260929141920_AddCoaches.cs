using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TennisBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddCoaches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Certificates = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Achievements = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IntroductionHtml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreateFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Achievements", "Certificates", "CreateFrom", "Experience", "ImageUrl", "IntroductionHtml", "Name", "UpdateFrom" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Vô địch ACTN Coach Cup 2023 · Huấn luyện viên trẻ xuất sắc 2024", "PTR Professional · ITF Level 2", new Guid("00000000-0000-0000-0000-000000000000"), "12 năm huấn luyện tennis chuyên nghiệp", "/media/coaches/coach-minh.png", "<p>Anh Minh theo đuổi phương pháp huấn luyện rõ ràng, kỷ luật và phù hợp với mục tiêu riêng của từng học viên.</p><p>Anh đặc biệt mạnh về kỹ thuật nền tảng, chiến thuật đánh đơn và xây dựng giáo án dài hạn.</p>", "Nguyễn Minh Anh", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Phát triển hơn 100 học viên thiếu nhi · Diễn giả Tennis For Kids 2024", "ITF Level 1 · USTA Safe Play", new Guid("00000000-0000-0000-0000-000000000000"), "8 năm huấn luyện trẻ em và lớp nhóm", "/media/coaches/coach-lan.png", "<p>Cô Lan mang đến những buổi học giàu năng lượng, an toàn và dễ tiếp cận cho trẻ em ở mọi trình độ.</p><p>Cô chú trọng niềm vui vận động, sự tự tin và thói quen chơi thể thao bền vững.</p>", "Trần Lan Phương", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Top 8 giải Tennis Open toàn quốc 2018 · Cố vấn chiến thuật ACTN", "PTR Professional · ITF Level 3 · CPR Certified", new Guid("00000000-0000-0000-0000-000000000000"), "15 năm thi đấu và huấn luyện tennis", "/media/coaches/coach-tuan.png", "<p>Anh Tuấn kết hợp kinh nghiệm thi đấu thực tế với tư duy chiến thuật để giúp học viên chơi chủ động và hiệu quả hơn.</p><p>Chuyên môn của anh tập trung vào nâng cao thể lực, giao bóng và xử lý điểm số áp lực.</p>", "Lê Quốc Tuấn", new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coaches");
        }
    }
}
