using Microsoft.EntityFrameworkCore;
using JobAdsAPI.Models;

namespace JobAdsAPI.Data;

public class JobAdDbContext(DbContextOptions<JobAdDbContext> options) : DbContext(options)
{
    public DbSet<JobAd> JobAds => Set<JobAd>();

    public DbSet<JobAdDescription> JobAdDescriptions => Set<JobAdDescription>(); // making sure that this table name is JobAdDescriptions

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
                    Location = "Oslo",
                    JobRole = "Backend",
                    WorkType = "Remote",
                    ExpierienceLevel = "Mid",
                    IsCSharpMentioned = true,
                    IsDotNetMentioned = true,
                    IsSQLMentioned = false,
                    OtherSkills = "Azure, Docker"
                },
                new JobAd
                {
                    Id = 2,
                    PublishedAt = new DateTime(2024, 4, 14),
                    CompanyName = "Web Solutions",
                    JobTitle = "Frontend Developer",
                    Location = "Bergen",
                    JobRole = "Frontend",
                    WorkType = "Hybrid",
                    ExpierienceLevel = "Junior",
                    IsCSharpMentioned = false,
                    IsDotNetMentioned = false,
                    IsSQLMentioned = false,
                    OtherSkills = "React, JavaScript"
                }
        );
    }
}
