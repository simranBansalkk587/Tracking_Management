using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking_Task.Migrations
{
    public partial class removeemailforinivtetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "InivitedTables");

            migrationBuilder.DropColumn(
                name: "EmailStatus",
                table: "InivitedTables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "InivitedTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmailStatus",
                table: "InivitedTables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
