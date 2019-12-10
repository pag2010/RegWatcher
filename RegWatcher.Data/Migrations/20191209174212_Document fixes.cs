using Microsoft.EntityFrameworkCore.Migrations;

namespace RegWatcher.Data.Migrations
{
    public partial class Documentfixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_ResponsibleUserId",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsibleUserId",
                table: "Documents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_ResponsibleUserId",
                table: "Documents",
                column: "ResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_ResponsibleUserId",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsibleUserId",
                table: "Documents",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_ResponsibleUserId",
                table: "Documents",
                column: "ResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
