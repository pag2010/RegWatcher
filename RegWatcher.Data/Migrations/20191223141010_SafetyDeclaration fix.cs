using Microsoft.EntityFrameworkCore.Migrations;

namespace RegWatcher.Data.Migrations
{
    public partial class SafetyDeclarationfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "SafetyDeclarations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SafetyDeclarations_DocumentId",
                table: "SafetyDeclarations",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SafetyDeclarations_Documents_DocumentId",
                table: "SafetyDeclarations",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SafetyDeclarations_Documents_DocumentId",
                table: "SafetyDeclarations");

            migrationBuilder.DropIndex(
                name: "IX_SafetyDeclarations_DocumentId",
                table: "SafetyDeclarations");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "SafetyDeclarations");
        }
    }
}
