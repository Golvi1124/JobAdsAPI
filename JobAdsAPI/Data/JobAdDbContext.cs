using Microsoft.EntityFrameworkCore;
using JobAdsAPI.Models;
using Microsoft.Data.Sqlite;

namespace JobAdsAPI.Data;

public class JobAdDbContext(DbContextOptions<JobAdDbContext> options) : DbContext(options)
{
    public DbSet<JobAd> JobAds => Set<JobAd>();

    public DbSet<JobAdDescription> JobAdDescriptions => Set<JobAdDescription>(); // making sure that this table name is JobAdDescriptions
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<WorkType> WorkTypes => Set<WorkType>();
    public DbSet<ExpierienceLevel> ExpierienceLevels => Set<ExpierienceLevel>();
    public DbSet<OtherSkill> OtherSkills => Set<OtherSkill>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<JobAd>().HasData(

                new JobAd
                {
                    Id = 1,
                    PublishedAt = new DateTime(2023, 1, 30),
                    CompanyName = "Tech Corp",
                    JobTitle = "Software Engineer",
                    IsCSharpMentioned = true,
                    IsDotNetMentioned = true,
                    IsSQLMentioned = false,
                },
                new JobAd
                {
                    Id = 2,
                    PublishedAt = new DateTime(2024, 4, 14),
                    CompanyName = "Web Solutions",
                    JobTitle = "Frontend Developer",
                    IsCSharpMentioned = false,
                    IsDotNetMentioned = false,
                    IsSQLMentioned = false,
                }
        );
    }
}
