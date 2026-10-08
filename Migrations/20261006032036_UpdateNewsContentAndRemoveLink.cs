using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TennisBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewsContentAndRemoveLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "ShortContentEn",
                table: "News",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortContentVi",
                table: "News",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                columns: new[] { "ShortContentEn", "ShortContentVi" },
                values: new object[] { "A friendly tournament for players of all levels.", "Giải đấu giao lưu dành cho người chơi ở nhiều trình độ." });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "ShortContentEn", "ShortContentVi" },
                values: new object[] { "More evening slots to help you keep a consistent training routine.", "Thêm khung giờ buổi tối để bạn duy trì lịch tập đều đặn." });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "ShortContentEn", "ShortContentVi" },
                values: new object[] { "A warm welcome offer for new ACE students.", "Ưu đãi mới dành cho học viên lần đầu đến với ACE." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortContentEn",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ShortContentVi",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "News",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                column: "Link",
                value: "https://example.com/ace-community-cup");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "Link",
                value: "https://example.com/evening-training");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Link",
                value: "https://example.com/new-student-offer");
        }
    }
}
