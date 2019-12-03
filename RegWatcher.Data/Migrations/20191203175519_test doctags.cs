using Microsoft.EntityFrameworkCore.Migrations;

namespace RegWatcher.Data.Migrations
{
    public partial class testdoctags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Documents_DocumentId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_DocumentId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Tags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "Tags",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_DocumentId",
                table: "Tags",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Documents_DocumentId",
                table: "Tags",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
