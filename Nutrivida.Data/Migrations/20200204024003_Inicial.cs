using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nutrivida.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpensiveCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ExpensiveCategoryPK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SaleCategoryPK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "varchar(100)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserPK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesObservation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpensivesObservation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumMeals = table.Column<int>(type: "int", nullable: true),
                    NumProducts = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FinancialRecordPK", x => x.Id);
                    table.ForeignKey(
                        name: "User.Possui.FinancialRecords",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expensives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpensiveCategoryId = table.Column<int>(type: "int", nullable: false),
                    FinancialRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ExpensivePK", x => x.Id);
                    table.ForeignKey(
                        name: "Expensive.Possui.Categoria",
                        column: x => x.ExpensiveCategoryId,
                        principalTable: "ExpensiveCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FinancialRecord.Possui.Expensives",
                        column: x => x.FinancialRecordId,
                        principalTable: "FinancialRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaleCategoryId = table.Column<int>(type: "int", nullable: false),
                    FinancialRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SalePK", x => x.Id);
                    table.ForeignKey(
                        name: "Sale.Possui.FinancialRecord",
                        column: x => x.FinancialRecordId,
                        principalTable: "FinancialRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Sale.Possui.Categoria",
                        column: x => x.SaleCategoryId,
                        principalTable: "SaleCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expensives_ExpensiveCategoryId",
                table: "Expensives",
                column: "ExpensiveCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensives_FinancialRecordId",
                table: "Expensives",
                column: "FinancialRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialRecords_UserId",
                table: "FinancialRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_FinancialRecordId",
                table: "Sales",
                column: "FinancialRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SaleCategoryId",
                table: "Sales",
                column: "SaleCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expensives");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "ExpensiveCategories");

            migrationBuilder.DropTable(
                name: "FinancialRecords");

            migrationBuilder.DropTable(
                name: "SaleCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
