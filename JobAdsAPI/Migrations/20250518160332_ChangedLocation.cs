using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAdsAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Oslo");

            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Bergen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Remote");

            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Hybrid");
        }
    }
}
