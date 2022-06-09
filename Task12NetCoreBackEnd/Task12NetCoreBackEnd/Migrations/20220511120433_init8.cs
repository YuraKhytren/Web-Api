using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task12NetCoreBackEnd.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyOperations_DayReports_DayReportId",
                table: "MoneyOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyOperations_MonthReports_MonthReportId",
                table: "MoneyOperations");

            migrationBuilder.DropTable(
                name: "DayReports");

            migrationBuilder.DropTable(
                name: "MonthReports");

            migrationBuilder.DropIndex(
                name: "IX_MoneyOperations_DayReportId",
                table: "MoneyOperations");

            migrationBuilder.DropIndex(
                name: "IX_MoneyOperations_MonthReportId",
                table: "MoneyOperations");

            migrationBuilder.DropColumn(
                name: "DayReportId",
                table: "MoneyOperations");

            migrationBuilder.DropColumn(
                name: "MonthReportId",
                table: "MoneyOperations");

            migrationBuilder.AlterColumn<decimal>(
                name: "Money",
                table: "MoneyOperations",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Money",
                table: "MoneyOperations",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "DayReportId",
                table: "MoneyOperations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthReportId",
                table: "MoneyOperations",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOperations_DayReportId",
                table: "MoneyOperations",
                column: "DayReportId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOperations_MonthReportId",
                table: "MoneyOperations",
                column: "MonthReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyOperations_DayReports_DayReportId",
                table: "MoneyOperations",
                column: "DayReportId",
                principalTable: "DayReports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyOperations_MonthReports_MonthReportId",
                table: "MoneyOperations",
                column: "MonthReportId",
                principalTable: "MonthReports",
                principalColumn: "Id");
        }
    }
}
