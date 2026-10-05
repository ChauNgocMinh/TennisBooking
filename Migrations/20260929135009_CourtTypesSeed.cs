using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TennisBooking.Migrations
{
    /// <inheritdoc />
    public partial class CourtTypesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourtType",
                table: "TennisCourts",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "private");

            migrationBuilder.CreateIndex(
                name: "IX_TennisCourts_CourtType",
                table: "TennisCourts",
                column: "CourtType");

            migrationBuilder.InsertData(
                table: "TennisCourts",
                columns: new[] { "Id", "CourtType", "CreateFrom", "Description", "Name", "Price", "UpdateFrom" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "private", Guid.Empty, "Sân dành cho lớp cá nhân.", "Sân Private", 300000m, Guid.Empty },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "group", Guid.Empty, "Sân dành cho lớp nhóm.", "Sân Group", 450000m, Guid.Empty },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "kids", Guid.Empty, "Sân dành cho lớp trẻ em.", "Sân Kids", 250000m, Guid.Empty }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("TennisCourts", "Id", new Guid("11111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData("TennisCourts", "Id", new Guid("22222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData("TennisCourts", "Id", new Guid("33333333-3333-3333-3333-333333333333"));
            migrationBuilder.DropIndex("IX_TennisCourts_CourtType", "TennisCourts");
            migrationBuilder.DropColumn("CourtType", "TennisCourts");
        }
    }
}
