using Microsoft.EntityFrameworkCore.Migrations;

namespace RegWatcher.Data.Migrations
{
    public partial class DocTagsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Tags_TagId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_TagId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Documents");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Documents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TagId",
                table: "Documents",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Tags_TagId",
                table: "Documents",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
