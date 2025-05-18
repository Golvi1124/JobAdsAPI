using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAdsAPI.Migrations
{
    /// <inheritdoc />
    public partial class JobAdDescriptionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    table.ForeignKey(
                        name: "FK_JobAdDescriptions_JobAds_JobAdId",
                        column: x => x.JobAdId,
                        principalTable: "JobAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobAdDescriptions_JobAdId",
                table: "JobAdDescriptions",
                column: "JobAdId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobAdDescriptions");
        }
    }
}
