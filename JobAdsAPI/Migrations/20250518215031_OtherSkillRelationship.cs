using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAdsAPI.Migrations
{
    /// <inheritdoc />
    public partial class OtherSkillRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherSkills",
                table: "JobAds");

            migrationBuilder.CreateTable(
                name: "OtherSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherSkill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobAdOtherSkill",
                columns: table => new
                {
                    JobAdsId = table.Column<int>(type: "INTEGER", nullable: false),
                    OtherSkillsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAdOtherSkill", x => new { x.JobAdsId, x.OtherSkillsId });
                    table.ForeignKey(
                        name: "FK_JobAdOtherSkill_JobAds_JobAdsId",
                        column: x => x.JobAdsId,
                        principalTable: "JobAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobAdOtherSkill_OtherSkill_OtherSkillsId",
                        column: x => x.OtherSkillsId,
                        principalTable: "OtherSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobAdOtherSkill_OtherSkillsId",
                table: "JobAdOtherSkill",
                column: "OtherSkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobAdOtherSkill");

            migrationBuilder.DropTable(
                name: "OtherSkill");

            migrationBuilder.AddColumn<string>(
                name: "OtherSkills",
                table: "JobAds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 1,
                column: "OtherSkills",
                value: "Azure, Docker");

            migrationBuilder.UpdateData(
                table: "JobAds",
                keyColumn: "Id",
                keyValue: 2,
                column: "OtherSkills",
                value: "React, JavaScript");
        }
    }
}
