using Microsoft.EntityFrameworkCore;
using JobAdsAPI.Models;

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

        // Define the one-to-one relationship between JobAd and JobAdDescription
        modelBuilder.Entity<JobAd>()
            .HasOne(j => j.JobAdDescription)
            .WithOne()
            .HasForeignKey<JobAd>(j => j.JobAdDescriptionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Define the many-to-many relationship between JobAd and OtherSkill
        modelBuilder.Entity<JobAd>()
            .HasMany(j => j.OtherSkills)
            .WithMany(s => s.JobAds)
            .UsingEntity<Dictionary<string, object>>(
                "JobAdOtherSkills",
                j => j.HasOne<OtherSkill>().WithMany().HasForeignKey("OtherSkillId"),
                s => s.HasOne<JobAd>().WithMany().HasForeignKey("JobAdId")
            );

        // Seed ExpierienceLevel data
        modelBuilder.Entity<ExpierienceLevel>().HasData(
            new ExpierienceLevel { Id = 1, Name = "Junior" },
            new ExpierienceLevel { Id = 2, Name = "Mid" },
            new ExpierienceLevel { Id = 3, Name = "Senior" }
        );

        // Seed WorkType data
        modelBuilder.Entity<WorkType>().HasData(
            new WorkType { Id = 1, Name = "Office" },
            new WorkType { Id = 2, Name = "Hybrid" },
            new WorkType { Id = 3, Name = "Remote" }
        );
    }
}