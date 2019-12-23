using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RegWatcher.Data.Migrations
{
    public partial class checkingsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acts",
                columns: table => new
                {
                    ActId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActNumber = table.Column<string>(nullable: true),
                    DocumentId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acts", x => x.ActId);
                    table.ForeignKey(
                        name: "FK_Acts_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckingKinds",
                columns: table => new
                {
                    CheckingKindId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingKinds", x => x.CheckingKindId);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Number = table.Column<string>(nullable: true),
                    DocumentId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checkings",
                columns: table => new
                {
                    CheckingId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    CheckingDate = table.Column<DateTime>(nullable: false),
                    CloseDate = table.Column<DateTime>(nullable: true),
                    GTSId = table.Column<int>(nullable: false),
                    CheckingKindId = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    DocumentReasonId = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    StepId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkings", x => x.CheckingId);
                    table.ForeignKey(
                        name: "FK_Checkings_CheckingKinds_CheckingKindId",
                        column: x => x.CheckingKindId,
                        principalTable: "CheckingKinds",
                        principalColumn: "CheckingKindId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checkings_Documents_DocumentReasonId",
                        column: x => x.DocumentReasonId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkings_GTSs_GTSId",
                        column: x => x.GTSId,
                        principalTable: "GTSs",
                        principalColumn: "GTSId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checkings_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckingResults",
                columns: table => new
                {
                    CheckingResultId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CheckingId = table.Column<int>(nullable: false),
                    ViolationCount = table.Column<int>(nullable: false),
                    Fine = table.Column<decimal>(nullable: false),
                    Article = table.Column<string>(nullable: true),
                    ActId = table.Column<int>(nullable: false),
                    PrescriptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingResults", x => x.CheckingResultId);
                    table.ForeignKey(
                        name: "FK_CheckingResults_Acts_ActId",
                        column: x => x.ActId,
                        principalTable: "Acts",
                        principalColumn: "ActId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingResults_Checkings_CheckingId",
                        column: x => x.CheckingId,
                        principalTable: "Checkings",
                        principalColumn: "CheckingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingResults_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acts_DocumentId",
                table: "Acts",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingResults_ActId",
                table: "CheckingResults",
                column: "ActId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingResults_CheckingId",
                table: "CheckingResults",
                column: "CheckingId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingResults_PrescriptionId",
                table: "CheckingResults",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkings_CheckingKindId",
                table: "Checkings",
                column: "CheckingKindId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkings_DocumentReasonId",
                table: "Checkings",
                column: "DocumentReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkings_GTSId",
                table: "Checkings",
                column: "GTSId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkings_StepId",
                table: "Checkings",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkings_UserId",
                table: "Checkings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DocumentId",
                table: "Prescriptions",
                column: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckingResults");

            migrationBuilder.DropTable(
                name: "Acts");

            migrationBuilder.DropTable(
                name: "Checkings");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "CheckingKinds");
        }
    }
}
