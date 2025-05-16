using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobAdsAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobAds",
                columns: new[] { "Id", "CompanyName", "ExpierienceLevel", "IsCSharpMentioned", "IsDotNetMentioned", "IsSQLMentioned", "JobRole", "JobTitle", "Location", "OtherSkills", "PublishedAt", "WorkType" },
                values: new object[,]
                {
                    { 1, "Tech Corp", "Mid", true, true, false, "Backend", "Software Engineer", "Remote", "Azure, Docker", new DateTime(2025, 5, 16, 9, 44, 28, 797, DateTimeKind.Utc).AddTicks(4988), "Remote" },
                    { 2, "Web Solutions", "Junior", false, false, false, "Frontend", "Frontend Developer", "Hybrid", "React, JavaScript", new DateTime(2025, 5, 16, 9, 44, 28, 797, DateTimeKind.Utc).AddTicks(6310), "Hybrid" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
