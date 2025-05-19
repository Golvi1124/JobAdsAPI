using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobAdsAPI.Migrations
{
    /// <inheritdoc />
    public partial class StartingNewAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpierienceLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpierienceLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobAdDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobDescription = table.Column<string>(type: "TEXT", nullable: true),
                    EmployerDescription = table.Column<string>(type: "TEXT", nullable: true),
                    JobAdId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAdDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobAds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PublishedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: true),
                    IsCSharpMentioned = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDotNetMentioned = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSQLMentioned = table.Column<bool>(type: "INTEGER", nullable: false),
                    JobAdDescriptionId = table.Column<int>(type: "INTEGER", nullable: true),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: true),
                    WorkTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    ExpierienceLevelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAds_ExpierienceLevels_ExpierienceLevelId",
                        column: x => x.ExpierienceLevelId,
                        principalTable: "ExpierienceLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobAds_JobAdDescriptions_JobAdDescriptionId",
                        column: x => x.JobAdDescriptionId,
                        principalTable: "JobAdDescriptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobAds_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobAds_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobAdOtherSkills",
                columns: table => new
                {
                    JobAdId = table.Column<int>(type: "INTEGER", nullable: false),
                    OtherSkillId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAdOtherSkills", x => new { x.JobAdId, x.OtherSkillId });
                    table.ForeignKey(
                        name: "FK_JobAdOtherSkills_JobAds_JobAdId",
                        column: x => x.JobAdId,
                        principalTable: "JobAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobAdOtherSkills_OtherSkills_OtherSkillId",
                        column: x => x.OtherSkillId,
                        principalTable: "OtherSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExpierienceLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Junior" },
                    { 2, "Mid" },
                    { 3, "Senior" }
                });

            migrationBuilder.InsertData(
                table: "WorkTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Office" },
                    { 2, "Hybrid" },
                    { 3, "Remote" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobAdOtherSkills_OtherSkillId",
                table: "JobAdOtherSkills",
                column: "OtherSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAds_ExpierienceLevelId",
                table: "JobAds",
                column: "ExpierienceLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAds_JobAdDescriptionId",
                table: "JobAds",
                column: "JobAdDescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobAds_LocationId",
                table: "JobAds",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAds_WorkTypeId",
                table: "JobAds",
                column: "WorkTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobAdOtherSkills");

            migrationBuilder.DropTable(
                name: "JobAds");

            migrationBuilder.DropTable(
                name: "OtherSkills");

            migrationBuilder.DropTable(
                name: "ExpierienceLevels");

            migrationBuilder.DropTable(
                name: "JobAdDescriptions");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "WorkTypes");
        }
    }
}
