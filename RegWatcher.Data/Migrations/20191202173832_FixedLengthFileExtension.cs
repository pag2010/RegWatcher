using Microsoft.EntityFrameworkCore.Migrations;

namespace RegWatcher.Data.Migrations
{
    public partial class FixedLengthFileExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "FileExtensions");

            migrationBuilder.AddColumn<string>(
                name: "ExtensionName",
                table: "FileExtensions",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtensionName",
                table: "FileExtensions");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "FileExtensions",
                nullable: false,
                defaultValue: "");
        }
    }
}
