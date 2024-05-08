using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobLandin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaBaseDadosII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 18, 51, 31, 37, DateTimeKind.Local).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 18, 51, 31, 37, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 18, 51, 31, 37, DateTimeKind.Local).AddTicks(6603));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 18, 45, 54, 234, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 18, 45, 54, 234, DateTimeKind.Local).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 18, 45, 54, 234, DateTimeKind.Local).AddTicks(8237));
        }
    }
}
