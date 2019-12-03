using Microsoft.EntityFrameworkCore.Migrations;

namespace RegWatcher.Data.Migrations
{
    public partial class FixDocumentOwnerFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerUserId",
                table: "Documents",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_OwnerUserId",
                table: "Documents",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_OwnerUserId",
                table: "Documents",
                column: "OwnerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_OwnerUserId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_OwnerUserId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Documents");
        }
    }
}
