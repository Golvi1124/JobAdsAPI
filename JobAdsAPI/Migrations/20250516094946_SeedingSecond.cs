using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAdsAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedAt",
                value: new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedAt",
                value: new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedAt",
                value: new DateTime(2025, 5, 16, 9, 44, 28, 797, DateTimeKind.Utc).AddTicks(4988));

            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedAt",
                value: new DateTime(2025, 5, 16, 9, 44, 28, 797, DateTimeKind.Utc).AddTicks(6310));
        }
    }
}
