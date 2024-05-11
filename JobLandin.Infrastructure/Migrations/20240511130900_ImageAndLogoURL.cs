using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobLandin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImageAndLogoURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                column: "LogoUrl",
                value: "https://placehold.co/600x400");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                column: "LogoUrl",
                value: "https://placehold.co/600x400");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                column: "LogoUrl",
                value: "https://placehold.co/600x400");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 14, 9, 0, 598, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 14, 9, 0, 598, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 14, 9, 0, 598, DateTimeKind.Local).AddTicks(6994));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Companies");

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Companies",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                column: "Logo",
                value: new byte[] { 103, 111, 111, 103, 108, 101, 95, 108, 111, 103, 111 });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                column: "Logo",
                value: new byte[] { 102, 97, 99, 101, 98, 111, 111, 107, 95, 108, 111, 103, 111 });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                column: "Logo",
                value: new byte[] { 109, 105, 99, 114, 111, 115, 111, 102, 116, 95, 108, 111, 103, 111 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 21, 42, 56, 873, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 21, 42, 56, 873, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 21, 42, 56, 873, DateTimeKind.Local).AddTicks(9179));
        }
    }
}
