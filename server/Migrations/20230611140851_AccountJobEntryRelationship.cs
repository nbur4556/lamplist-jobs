using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AccountJobEntryRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "JobEntries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_JobEntries_AccountId",
                table: "JobEntries",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobEntries_Account_AccountId",
                table: "JobEntries",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobEntries_Account_AccountId",
                table: "JobEntries");

            migrationBuilder.DropIndex(
                name: "IX_JobEntries_AccountId",
                table: "JobEntries");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "JobEntries");
        }
    }
}
