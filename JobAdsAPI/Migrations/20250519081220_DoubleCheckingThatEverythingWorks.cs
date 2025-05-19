using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAdsAPI.Migrations
{
    /// <inheritdoc />
    public partial class DoubleCheckingThatEverythingWorks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobAdOtherSkill_OtherSkill_OtherSkillsId",
                table: "JobAdOtherSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAds_ExpierienceLevel_ExpierienceLevelId",
                table: "JobAds");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAds_Location_LocationId",
                table: "JobAds");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAds_WorkType_WorkTypeId",
                table: "JobAds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkType",
                table: "WorkType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OtherSkill",
                table: "OtherSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpierienceLevel",
                table: "ExpierienceLevel");

            migrationBuilder.RenameTable(
                name: "WorkType",
                newName: "WorkTypes");

            migrationBuilder.RenameTable(
                name: "OtherSkill",
                newName: "OtherSkills");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "ExpierienceLevel",
                newName: "ExpierienceLevels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTypes",
                table: "WorkTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OtherSkills",
                table: "OtherSkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpierienceLevels",
                table: "ExpierienceLevels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAdOtherSkill_OtherSkills_OtherSkillsId",
                table: "JobAdOtherSkill",
                column: "OtherSkillsId",
                principalTable: "OtherSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobAds_ExpierienceLevels_ExpierienceLevelId",
                table: "JobAds",
                column: "ExpierienceLevelId",
                principalTable: "ExpierienceLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAds_Locations_LocationId",
                table: "JobAds",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAds_WorkTypes_WorkTypeId",
                table: "JobAds",
                column: "WorkTypeId",
                principalTable: "WorkTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobAdOtherSkill_OtherSkills_OtherSkillsId",
                table: "JobAdOtherSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAds_ExpierienceLevels_ExpierienceLevelId",
                table: "JobAds");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAds_Locations_LocationId",
                table: "JobAds");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAds_WorkTypes_WorkTypeId",
                table: "JobAds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTypes",
                table: "WorkTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OtherSkills",
                table: "OtherSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpierienceLevels",
                table: "ExpierienceLevels");

            migrationBuilder.RenameTable(
                name: "WorkTypes",
                newName: "WorkType");

            migrationBuilder.RenameTable(
                name: "OtherSkills",
                newName: "OtherSkill");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "ExpierienceLevels",
                newName: "ExpierienceLevel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkType",
                table: "WorkType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OtherSkill",
                table: "OtherSkill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpierienceLevel",
                table: "ExpierienceLevel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAdOtherSkill_OtherSkill_OtherSkillsId",
                table: "JobAdOtherSkill",
                column: "OtherSkillsId",
                principalTable: "OtherSkill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobAds_ExpierienceLevel_ExpierienceLevelId",
                table: "JobAds",
                column: "ExpierienceLevelId",
                principalTable: "ExpierienceLevel",
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
    }
}
