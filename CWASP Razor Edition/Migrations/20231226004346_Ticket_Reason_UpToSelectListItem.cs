using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CWASP_Razor_Edition.Migrations
{
    /// <inheritdoc />
    public partial class Ticket_Reason_UpToSelectListItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Ticket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
