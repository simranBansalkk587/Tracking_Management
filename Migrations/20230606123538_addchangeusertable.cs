using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking_Task.Migrations
{
    public partial class addchangeusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "InivitedTables",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmailStatus",
                table: "InivitedTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BooksId",
                table: "Users",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Books_BooksId",
                table: "Users",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Books_BooksId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BooksId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailStatus",
                table: "InivitedTables");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "InivitedTables",
                newName: "Name");
        }
    }
}
