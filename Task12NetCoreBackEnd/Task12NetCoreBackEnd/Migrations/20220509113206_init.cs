using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task12NetCoreBackEnd.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayIncome = table.Column<int>(type: "int", nullable: false),
                    DayOutcome = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Income = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthIncome = table.Column<int>(type: "int", nullable: false),
                    MonthOutcome = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoneyOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    FinanceTypeId = table.Column<int>(type: "int", nullable: false),
                    DayReportId = table.Column<int>(type: "int", nullable: true),
                    MonthReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyOperations_DayReports_DayReportId",
                        column: x => x.DayReportId,
                        principalTable: "DayReports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MoneyOperations_FinanceTypes_FinanceTypeId",
                        column: x => x.FinanceTypeId,
                        principalTable: "FinanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoneyOperations_MonthReports_MonthReportId",
                        column: x => x.MonthReportId,
                        principalTable: "MonthReports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOperations_DayReportId",
                table: "MoneyOperations",
                column: "DayReportId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOperations_FinanceTypeId",
                table: "MoneyOperations",
                column: "FinanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOperations_MonthReportId",
                table: "MoneyOperations",
                column: "MonthReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneyOperations");

            migrationBuilder.DropTable(
                name: "DayReports");

            migrationBuilder.DropTable(
                name: "FinanceTypes");

            migrationBuilder.DropTable(
                name: "MonthReports");
        }
    }
}
