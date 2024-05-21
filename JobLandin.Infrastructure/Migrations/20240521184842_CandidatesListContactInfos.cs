using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobLandin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CandidatesListContactInfos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactInfo",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 19, 48, 41, 439, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 19, 48, 41, 439, DateTimeKind.Local).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 19, 48, 41, 439, DateTimeKind.Local).AddTicks(7938));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactInfo",
                table: "Candidates");

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
        }
    }
}
