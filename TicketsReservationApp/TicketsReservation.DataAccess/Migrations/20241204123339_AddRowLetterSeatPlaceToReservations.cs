using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRowLetterSeatPlaceToReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RowLetterSeatPlace",
                table: "Reservations",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowLetterSeatPlace",
                table: "Reservations");
        }
    }
}
