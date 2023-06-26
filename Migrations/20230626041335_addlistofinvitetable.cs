using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking_Task.Migrations
{
    public partial class addlistofinvitetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "InivitedPerson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "InivitedPerson",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
