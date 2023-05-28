using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Insert_BookId_and_UserId_in_Loan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "Loans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Loans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Loans");
        }
    }
}
