using Microsoft.EntityFrameworkCore.Migrations;

namespace RegWatcher.Data.Migrations
{
    public partial class Companyaddedstep1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Steps_StepId1",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_StepId1",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StepId1",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_StepId",
                table: "Companies",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Steps_StepId",
                table: "Companies",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "StepId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Steps_StepId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_StepId",
                table: "Companies");

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
    }
}
