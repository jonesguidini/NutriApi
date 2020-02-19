using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nutrivida.Data.Migrations
{
    public partial class Atualiza_Campo_DateDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "SaleCategories");

            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "FinancialRecords");

            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "Expensives");

            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "ExpensiveCategories");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Sales",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "SaleCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinancialRecords",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Expensives",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ExpensiveCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "SaleCategories");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinancialRecords");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Expensives");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ExpensiveCategories");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "Sales",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "SaleCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "FinancialRecords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "Expensives",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "ExpensiveCategories",
                type: "datetime2",
                nullable: true);
        }
    }
}
