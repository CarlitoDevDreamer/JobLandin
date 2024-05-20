﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobLandin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CandidatesList4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "CandidateId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "CandidateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "CandidateId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 40, 39, 227, DateTimeKind.Local).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 40, 39, 227, DateTimeKind.Local).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 40, 39, 227, DateTimeKind.Local).AddTicks(7553));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "CandidateId", "CandidateName", "Industry", "Location", "ProfilePicUrl", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 1, "John Doe", "Technology", "Lagos", "https://placehold.co/200x200", "1", null },
                    { 2, "Jane Doe", "Technology", "Abuja", "https://placehold.co/200x200", "2", null },
                    { 3, "James Doe", "Technology", "Port Harcourt", "https://placehold.co/200x200", "3", null }
                });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 38, 3, 146, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 38, 3, 146, DateTimeKind.Local).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 22, 38, 3, 146, DateTimeKind.Local).AddTicks(6656));
        }
    }
}
