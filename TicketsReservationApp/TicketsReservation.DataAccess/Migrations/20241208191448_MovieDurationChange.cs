using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MovieDurationChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Durtion",
                table: "Movies",
                newName: "Duration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Movies",
                newName: "Durtion");
        }
    }
}
