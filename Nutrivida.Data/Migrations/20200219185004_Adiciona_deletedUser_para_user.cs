using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nutrivida.Data.Migrations
{
    public partial class Adiciona_deletedUser_para_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelited",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "FinancialRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedByUserId",
                table: "Users",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialRecords_UserId1",
                table: "FinancialRecords",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialRecords_Users_UserId1",
                table: "FinancialRecords",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "User.Possui.UserDeleted",
                table: "Users",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialRecords_Users_UserId1",
                table: "FinancialRecords");

            migrationBuilder.DropForeignKey(
                name: "User.Possui.UserDeleted",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DeletedByUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_FinancialRecords_UserId1",
                table: "FinancialRecords");

            migrationBuilder.DropColumn(
                name: "DateDelited",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "FinancialRecords");
        }
    }
}
