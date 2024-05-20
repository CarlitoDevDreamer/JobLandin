using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobLandin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CandidatesList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                    table.ForeignKey(
                        name: "FK_Candidates_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 21, 38, 30, 574, DateTimeKind.Local).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 21, 38, 30, 574, DateTimeKind.Local).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 21, 38, 30, 574, DateTimeKind.Local).AddTicks(4821));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CandidateId",
                table: "AspNetUsers",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_UserId1",
                table: "Candidates",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CandidateId",
                table: "AspNetUsers",
                column: "CandidateId",
                principalTable: "Companies",
                principalColumn: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CandidateId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CandidateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 19, 21, 6, 17, 768, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 19, 21, 6, 17, 768, DateTimeKind.Local).AddTicks(2094));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 19, 21, 6, 17, 768, DateTimeKind.Local).AddTicks(2097));
        }
    }
}
