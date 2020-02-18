using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nutrivida.Data.Migrations
{
    public partial class adicionar_deleted_reference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "Sales",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Sales",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sales",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "SaleCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "SaleCategories",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SaleCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "FinancialRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "FinancialRecords",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FinancialRecords",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "Expensives",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Expensives",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Expensives",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "ExpensiveCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "ExpensiveCategories",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExpensiveCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DeletedByUserId",
                table: "Sales",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleCategories_DeletedByUserId",
                table: "SaleCategories",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialRecords_DeletedByUserId",
                table: "FinancialRecords",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensives_DeletedByUserId",
                table: "Expensives",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensiveCategories_DeletedByUserId",
                table: "ExpensiveCategories",
                column: "DeletedByUserId");

            migrationBuilder.AddForeignKey(
                name: "ExpensiveCategory.Possui.UserDeleted",
                table: "ExpensiveCategories",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Expensive.Possui.UserDeleted",
                table: "Expensives",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FinancialRecord.Possui.UserDeleted",
                table: "FinancialRecords",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "SaleCategory.Possui.UserDeleted",
                table: "SaleCategories",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Sale.Possui.UserDeleted",
                table: "Sales",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ExpensiveCategory.Possui.UserDeleted",
                table: "ExpensiveCategories");

            migrationBuilder.DropForeignKey(
                name: "Expensive.Possui.UserDeleted",
                table: "Expensives");

            migrationBuilder.DropForeignKey(
                name: "FinancialRecord.Possui.UserDeleted",
                table: "FinancialRecords");

            migrationBuilder.DropForeignKey(
                name: "SaleCategory.Possui.UserDeleted",
                table: "SaleCategories");

            migrationBuilder.DropForeignKey(
                name: "Sale.Possui.UserDeleted",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_DeletedByUserId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_SaleCategories_DeletedByUserId",
                table: "SaleCategories");

            migrationBuilder.DropIndex(
                name: "IX_FinancialRecords_DeletedByUserId",
                table: "FinancialRecords");

            migrationBuilder.DropIndex(
                name: "IX_Expensives_DeletedByUserId",
                table: "Expensives");

            migrationBuilder.DropIndex(
                name: "IX_ExpensiveCategories_DeletedByUserId",
                table: "ExpensiveCategories");

            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "SaleCategories");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "SaleCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SaleCategories");

            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "FinancialRecords");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "FinancialRecords");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FinancialRecords");

            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "Expensives");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Expensives");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Expensives");

            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "ExpensiveCategories");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "ExpensiveCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExpensiveCategories");
        }
    }
}
