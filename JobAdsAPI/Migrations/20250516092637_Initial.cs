using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAdsAPI.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "JobAds",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                PublishedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                JobTitle = table.Column<string>(type: "TEXT", nullable: true),
                Location = table.Column<string>(type: "TEXT", nullable: true),
                JobRole = table.Column<string>(type: "TEXT", nullable: true),
                WorkType = table.Column<string>(type: "TEXT", nullable: true),
                ExpierienceLevel = table.Column<string>(type: "TEXT", nullable: true),
                IsCSharpMentioned = table.Column<bool>(type: "INTEGER", nullable: false),
                IsDotNetMentioned = table.Column<bool>(type: "INTEGER", nullable: false),
                IsSQLMentioned = table.Column<bool>(type: "INTEGER", nullable: false),
                OtherSkills = table.Column<string>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_JobAds", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "JobAds");
    }
}
