using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RegWatcher.Data.Migrations
{
    public partial class GTSadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DangerKinds",
                columns: table => new
                {
                    DangerKindId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangerKinds", x => x.DangerKindId);
                });

            migrationBuilder.CreateTable(
                name: "GTSs",
                columns: table => new
                {
                    GTSId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    DangerKindId = table.Column<int>(nullable: false),
                    Purpose = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GTSs", x => x.GTSId);
                    table.ForeignKey(
                        name: "FK_GTSs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GTSs_DangerKinds_DangerKindId",
                        column: x => x.DangerKindId,
                        principalTable: "DangerKinds",
                        principalColumn: "DangerKindId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SafetyDeclarations",
                columns: table => new
                {
                    SafetyDeclarationId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GTSId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyDeclarations", x => x.SafetyDeclarationId);
                    table.ForeignKey(
                        name: "FK_SafetyDeclarations_GTSs_GTSId",
                        column: x => x.GTSId,
                        principalTable: "GTSs",
                        principalColumn: "GTSId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GTSs_CompanyId",
                table: "GTSs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_GTSs_DangerKindId",
                table: "GTSs",
                column: "DangerKindId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyDeclarations_GTSId",
                table: "SafetyDeclarations",
                column: "GTSId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SafetyDeclarations");

            migrationBuilder.DropTable(
                name: "GTSs");

            migrationBuilder.DropTable(
                name: "DangerKinds");
        }
    }
}
