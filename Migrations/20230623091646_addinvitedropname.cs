using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking_Task.Migrations
{
    public partial class addinvitedropname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "InivitedPerson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "InivitedPerson",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
