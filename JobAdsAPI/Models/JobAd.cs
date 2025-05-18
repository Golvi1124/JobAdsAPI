using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace JobAdsAPI.Models;

public class JobAd
{
    public int Id { get; set; }
    public DateTime PublishedAt { get; set; } 
    public string? CompanyName { get; set; }
    public string? JobTitle { get; set; }
    public string? Location { get; set; } // Oslo, Bergen, Trondheim
    public string? JobRole { get; set; } // Frontend, Backend, Fullstack
    public string? WorkType { get; set; } // Remote, Hybrid, Onsite
    public string? ExpierienceLevel { get; set; } // Junior, Mid, Senior
    public bool IsCSharpMentioned { get; set; } = false;
    public bool IsDotNetMentioned { get; set; } = false;
    public bool IsSQLMentioned { get; set; } = false;
    public string? OtherSkills { get; set; } // Other required skills/languages

    public JobAdDescription? JobAdDescription { get; set; } // One-to-One relationship
}
