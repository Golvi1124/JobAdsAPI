namespace JobAdsAPI.Models;

public class JobAdDescription
{
    public int Id { get; set; }
    public string? JobDescription { get; set; }
    public string? EmployerDescription { get; set; }
    public int JobAdId { get; set; }
}