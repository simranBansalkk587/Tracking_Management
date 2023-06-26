using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking_Task.Migrations
{
    public partial class removeBookId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackDetails_Books_BooksId",
                table: "TrackDetails");

            migrationBuilder.DropIndex(
                name: "IX_TrackDetails_BooksId",
                table: "TrackDetails");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "TrackDetails");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "TrackDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "TrackDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "TrackDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackDetails_BooksId",
                table: "TrackDetails",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackDetails_Books_BooksId",
                table: "TrackDetails",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
