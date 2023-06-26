using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking_Task.Migrations
{
    public partial class addchangebooktable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_UserId",
                table: "Books",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_UserId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_UserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "Users",
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
    }
}
