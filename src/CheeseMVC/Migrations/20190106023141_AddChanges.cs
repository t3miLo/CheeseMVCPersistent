﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CheeseMVC.Migrations
{
    public partial class AddChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cheeses");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Cheeses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cheeses_CategoryID",
                table: "Cheeses",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheeses_Categories_CategoryID",
                table: "Cheeses",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheeses_Categories_CategoryID",
                table: "Cheeses");

            migrationBuilder.DropIndex(
                name: "IX_Cheeses_CategoryID",
                table: "Cheeses");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Cheeses");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Cheeses",
                nullable: false,
                defaultValue: 0);
        }
    }
}
