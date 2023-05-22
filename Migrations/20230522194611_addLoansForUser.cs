using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLibrary.Migrations
{
    /// <inheritdoc />
    public partial class addLoansForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "LoanOnlineLibraryUser",
                columns: table => new
                {
                    LoansLoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanOnlineLibraryUser", x => new { x.LoansLoanId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_LoanOnlineLibraryUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanOnlineLibraryUser_Loans_LoansLoanId",
                        column: x => x.LoansLoanId,
                        principalTable: "Loans",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanOnlineLibraryUser_UsersId",
                table: "LoanOnlineLibraryUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanOnlineLibraryUser");

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
    }
}
