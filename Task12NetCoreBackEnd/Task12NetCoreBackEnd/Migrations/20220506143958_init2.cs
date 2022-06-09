using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task12NetCoreBackEnd.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "MoneyOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinanceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyOperations_FinanceTypes_FinanceTypeId",
                        column: x => x.FinanceTypeId,
                        principalTable: "FinanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOperations_FinanceTypeId",
                table: "MoneyOperations",
                column: "FinanceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneyOperations");

            migrationBuilder.DropTable(
                name: "FinanceTypes");
        }
    }
}
