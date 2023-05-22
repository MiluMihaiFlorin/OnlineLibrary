using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLibrary.Migrations
{
    /// <inheritdoc />
    public partial class testIfCategoryWasBrokenInContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Loans");

            migrationBuilder.AddColumn<Guid>(
                name: "LoanId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LoanId",
                table: "AspNetUsers",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Loans_LoanId",
                table: "AspNetUsers",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "LoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Loans_LoanId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LoanId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Loans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
