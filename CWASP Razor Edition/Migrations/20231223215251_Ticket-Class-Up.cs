using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CWASP_Razor_Edition.Migrations
{
    /// <inheritdoc />
    public partial class TicketClassUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ticket");
        }
    }
}
