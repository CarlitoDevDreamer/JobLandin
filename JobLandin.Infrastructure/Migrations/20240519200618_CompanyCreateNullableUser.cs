using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobLandin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompanyCreateNullableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 18, 21, 53, 13, 441, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 18, 21, 53, 13, 441, DateTimeKind.Local).AddTicks(2898));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 18, 21, 53, 13, 441, DateTimeKind.Local).AddTicks(2902));
        }
    }
}
