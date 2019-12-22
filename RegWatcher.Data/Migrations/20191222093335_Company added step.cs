using Microsoft.EntityFrameworkCore.Migrations;

namespace RegWatcher.Data.Migrations
{
    public partial class Companyaddedstep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StepId1",
                table: "Companies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_StepId1",
                table: "Companies",
                column: "StepId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Steps_StepId1",
                table: "Companies",
                column: "StepId1",
                principalTable: "Steps",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Steps_StepId1",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_StepId1",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StepId1",
                table: "Companies");
        }
    }
}
