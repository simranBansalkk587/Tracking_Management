using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking_Task.Migrations
{
    public partial class addtrackdetailstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InivitedTableId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: true),
                    Perviouschange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trackingdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackDetails_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrackDetails_InivitedTables_InivitedTableId",
                        column: x => x.InivitedTableId,
                        principalTable: "InivitedTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackDetails_BooksId",
                table: "TrackDetails",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackDetails_InivitedTableId",
                table: "TrackDetails",
                column: "InivitedTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackDetails");
        }
    }
}
