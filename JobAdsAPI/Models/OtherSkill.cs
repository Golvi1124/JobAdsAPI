using System.Text.Json.Serialization;

namespace JobAdsAPI.Models;

public class OtherSkill
{
    public int Id { get; set; }
    public required string Name { get; set; }

    [JsonIgnore] // Prevent circular reference
    public List<JobAd>? JobAds { get; set; } // needed? = new List<JobAd>();
}
