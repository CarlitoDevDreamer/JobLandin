using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobLandin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CandidatesListSixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CandidateId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_AspNetUsers_UserId1",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_UserId1",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CandidateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Candidates");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Candidates",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 58, 27, 738, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 58, 27, 738, DateTimeKind.Local).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 58, 27, 738, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_UserId",
                table: "Candidates",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_AspNetUsers_UserId",
                table: "Candidates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_AspNetUsers_UserId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_UserId",
                table: "Candidates");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Candidates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 47, 18, 387, DateTimeKind.Local).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 47, 18, 387, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 47, 18, 387, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_UserId1",
                table: "Candidates",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CandidateId",
                table: "AspNetUsers",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CandidateId",
                table: "AspNetUsers",
                column: "CandidateId",
                principalTable: "Companies",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_AspNetUsers_UserId1",
                table: "Candidates",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
