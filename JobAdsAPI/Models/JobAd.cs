using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace JobAdsAPI.Models;

public class JobAd
{
    public int Id { get; set; }
    public DateTime PublishedAt { get; set; } 
    public string? CompanyName { get; set; }
    public string? JobTitle { get; set; }
    public bool IsCSharpMentioned { get; set; } = false;
    public bool IsDotNetMentioned { get; set; } = false;
    public bool IsSQLMentioned { get; set; } = false;

    // One-to-One relationship
    public JobAdDescription? JobAdDescription { get; set; }

    // One-to-Many relationship
    public int? LocationId { get; set; }
    public Location? Location { get; set; }

    public int? WorkTypeId { get; set; }
    public WorkType? WorkType { get; set; }

    public int? ExpierienceLevelId { get; set; }
    public ExpierienceLevel? ExpierienceLevel { get; set; }

    // Many-to-Many relationship
    public List<OtherSkill>? OtherSkills { get; set; }  // Other required skills/languages
}
