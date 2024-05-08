using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobLandin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewCompanyEntityJobApplicationMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationDetails",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationMethod",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "CompanyName", "Description", "Industry", "Location", "Logo", "Size", "Website" },
                values: new object[,]
                {
                    { 1, "Google", "Google is a multinational technology company that specializes in Internet-related services and products, which include online advertising technologies, a search engine, cloud computing, software, and hardware.", "Technology", "Lagos", new byte[] { 103, 111, 111, 103, 108, 101, 95, 108, 111, 103, 111 }, 1000, "https://www.google.com" },
                    { 2, "Facebook", "Facebook is an American online social media and social networking service company based in Menlo Park, California.", "Technology", "Abuja", new byte[] { 102, 97, 99, 101, 98, 111, 111, 107, 95, 108, 111, 103, 111 }, 500, "https://www.facebook.com" },
                    { 3, "Microsoft", "Microsoft Corporation is an American multinational technology company with headquarters in Redmond, Washington.", "Technology", "Port Harcourt", new byte[] { 109, 105, 99, 114, 111, 115, 111, 102, 116, 95, 108, 111, 103, 111 }, 2000, "https://www.microsoft.com" }
                });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationDetails", "ApplicationMethod", "CompanyId", "CreatedAt" },
                values: new object[] { "https://www.google.com/careers/", 0, 1, new DateTime(2024, 5, 8, 14, 44, 58, 362, DateTimeKind.Local).AddTicks(5390) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApplicationDetails", "ApplicationMethod", "CompanyId", "CreatedAt" },
                values: new object[] { "data@email.com", 1, 3, new DateTime(2024, 5, 8, 14, 44, 58, 362, DateTimeKind.Local).AddTicks(5441) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApplicationDetails", "ApplicationMethod", "CompanyId", "CreatedAt" },
                values: new object[] { "08012345678", 2, 2, new DateTime(2024, 5, 8, 14, 44, 58, 362, DateTimeKind.Local).AddTicks(5445) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropColumn(
                name: "ApplicationDetails",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ApplicationMethod",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Jobs");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: null);
        }
    }
}
