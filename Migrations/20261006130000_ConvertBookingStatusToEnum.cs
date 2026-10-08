using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TennisBooking.Migrations
{
    public partial class ConvertBookingStatusToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add temporary int column
            migrationBuilder.AddColumn<int>(
                name: "Status_tmp",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 1);

            // Map existing bit values to enum values: 0 -> Pending(1), 1 -> Confirmed(2)
            migrationBuilder.Sql("UPDATE Bookings SET Status_tmp = CASE WHEN Status = 1 THEN 2 ELSE 1 END;");

            // Remove old bit column and rename temp to Status
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Status_tmp",
                table: "Bookings",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Recreate temporary bit column
            migrationBuilder.AddColumn<bool>(
                name: "Status_tmp",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            // Map enum values back to bit: Confirmed(2) -> 1, others -> 0
            migrationBuilder.Sql("UPDATE Bookings SET Status_tmp = CASE WHEN Status = 2 THEN 1 ELSE 0 END;");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Status_tmp",
                table: "Bookings",
                newName: "Status");
        }
    }
}
