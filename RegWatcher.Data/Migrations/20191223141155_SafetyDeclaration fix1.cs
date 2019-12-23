using Microsoft.EntityFrameworkCore.Migrations;

namespace RegWatcher.Data.Migrations
{
    public partial class SafetyDeclarationfix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SafetyDeclarations_Documents_DocumentId",
                table: "SafetyDeclarations");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                table: "SafetyDeclarations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SafetyDeclarations_Documents_DocumentId",
                table: "SafetyDeclarations",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SafetyDeclarations_Documents_DocumentId",
                table: "SafetyDeclarations");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                table: "SafetyDeclarations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SafetyDeclarations_Documents_DocumentId",
                table: "SafetyDeclarations",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
