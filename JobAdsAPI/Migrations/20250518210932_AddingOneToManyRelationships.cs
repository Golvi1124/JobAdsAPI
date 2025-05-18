using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAdsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingOneToManyRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpierienceLevel",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "JobRole",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "WorkType",
                table: "JobAds");

            migrationBuilder.AddColumn<int>(
                name: "ExpierienceLevelId",
                table: "JobAds",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "JobAds",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkTypeId",
                table: "JobAds",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkType", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpierienceLevelId", "LocationId", "WorkTypeId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpierienceLevelId", "LocationId", "WorkTypeId" },
                values: new object[] { null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_JobAds_ExpierienceLevelId",
                table: "JobAds",
                column: "ExpierienceLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAds_LocationId",
                table: "JobAds",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAds_WorkTypeId",
                table: "JobAds",
                column: "WorkTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAds_Location_ExpierienceLevelId",
                table: "JobAds",
                column: "ExpierienceLevelId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAds_Location_LocationId",
                table: "JobAds",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAds_WorkType_WorkTypeId",
                table: "JobAds",
                column: "WorkTypeId",
                principalTable: "WorkType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobAds_Location_ExpierienceLevelId",
                table: "JobAds");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAds_Location_LocationId",
                table: "JobAds");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAds_WorkType_WorkTypeId",
                table: "JobAds");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "WorkType");

            migrationBuilder.DropIndex(
                name: "IX_JobAds_ExpierienceLevelId",
                table: "JobAds");

            migrationBuilder.DropIndex(
                name: "IX_JobAds_LocationId",
                table: "JobAds");

            migrationBuilder.DropIndex(
                name: "IX_JobAds_WorkTypeId",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "ExpierienceLevelId",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "WorkTypeId",
                table: "JobAds");

            migrationBuilder.AddColumn<string>(
                name: "ExpierienceLevel",
                table: "JobAds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobRole",
                table: "JobAds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "JobAds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkType",
                table: "JobAds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpierienceLevel", "JobRole", "Location", "WorkType" },
                values: new object[] { "Mid", "Backend", "Oslo", "Remote" });

            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpierienceLevel", "JobRole", "Location", "WorkType" },
                values: new object[] { "Junior", "Frontend", "Bergen", "Hybrid" });
        }
    }
}
