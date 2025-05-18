using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAdsAPI.Migrations
{
    /// <inheritdoc />
    public partial class smallChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobAds_Location_ExpierienceLevelId",
                table: "JobAds");

            migrationBuilder.CreateTable(
                name: "ExpierienceLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpierienceLevel", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_JobAds_ExpierienceLevel_ExpierienceLevelId",
                table: "JobAds",
                column: "ExpierienceLevelId",
                principalTable: "ExpierienceLevel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobAds_ExpierienceLevel_ExpierienceLevelId",
                table: "JobAds");

            migrationBuilder.DropTable(
                name: "ExpierienceLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAds_Location_ExpierienceLevelId",
                table: "JobAds",
                column: "ExpierienceLevelId",
                principalTable: "Location",
                principalColumn: "Id");
        }
    }
}
