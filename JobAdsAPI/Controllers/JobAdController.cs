using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobAdsAPI.Models;

namespace JobAdsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobAdController : ControllerBase
{
    static private List<JobAd> jobAds = new List<JobAd> // static because we will add data to it and will want to show all
    {
        new JobAd
        {
            Id = 1,
            PublishedAt = new DateTime(2023, 1, 30), // Correctly initializing DateTime
            CompanyName = "Tech Company",
            JobTitle = "Software Engineer",
            Location = "Remote",
            JobRole = "Fullstack",
            WorkType = "Remote",
            ExpierienceLevel = "Mid",
            IsCSharpMentioned = true,
            IsDotNetMentioned = true,
            IsSQLMentioned = true,
            OtherSkills = "JavaScript, React"
        },

        new JobAd
        {
            Id = 2,
            PublishedAt = new DateTime(2023, 4, 12),
            CompanyName = "Another Tech Company",
            JobTitle = "Backend Developer",
            Location = "Hybrid",
            JobRole = "Backend",
            WorkType = "Hybrid",
            ExpierienceLevel = "Senior",
            IsCSharpMentioned = true,
            IsDotNetMentioned = false,
            IsSQLMentioned = true,
            OtherSkills = "Node.js, Express"
        },
        new JobAd
        {
            Id = 3,
            PublishedAt = new DateTime(2023, 6, 15),
            CompanyName = "Web Solutions",
            JobTitle = "Frontend Developer",
            Location = "Onsite",
            JobRole = "Frontend",
            WorkType = "Onsite",
            ExpierienceLevel = "Junior",
            IsCSharpMentioned = false,
            IsDotNetMentioned = false,
            IsSQLMentioned = false,
            OtherSkills = "HTML, CSS, JavaScript"
        }
    };
    [HttpGet]
    public ActionResult<List<JobAd>> GetAllJobAds()
    {
        return Ok(jobAds);
    }

    [HttpGet("{id}")]
    public ActionResult<JobAd> GetJobAdById(int id)
    {
        var jobAd = jobAds.FirstOrDefault(j => j.Id == id);
        if (jobAd == null)
        {
            return NotFound();
        }
        return Ok(jobAd);
    }

    [HttpPost]
    public ActionResult<JobAd> AddJobAd(JobAd newAd)
    {
        if (newAd == null)
            return BadRequest();

        newAd.Id = jobAds.Max(j => j.Id) + 1;
        jobAds.Add(newAd);
        return CreatedAtAction(nameof(GetJobAdById), new { id = newAd.Id }, newAd);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateJobAd(int id, JobAd updatedAd)
    {
        var existingAd = jobAds.FirstOrDefault(j => j.Id == id);
        if (existingAd == null)
            return NotFound();

        existingAd.PublishedAt = updatedAd.PublishedAt;
        existingAd.CompanyName = updatedAd.CompanyName;
        existingAd.JobTitle = updatedAd.JobTitle;
        existingAd.Location = updatedAd.Location;
        existingAd.JobRole = updatedAd.JobRole;
        existingAd.WorkType = updatedAd.WorkType;
        existingAd.ExpierienceLevel = updatedAd.ExpierienceLevel;
        existingAd.IsCSharpMentioned = updatedAd.IsCSharpMentioned;
        existingAd.IsDotNetMentioned = updatedAd.IsDotNetMentioned;
        existingAd.IsSQLMentioned = updatedAd.IsSQLMentioned;
        existingAd.OtherSkills = updatedAd.OtherSkills;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteJobAd(int id)
    {
        var jobAd = jobAds.FirstOrDefault(j => j.Id == id);
        if (jobAd == null)
            return NotFound();

        jobAds.Remove(jobAd);
        return NoContent();
    }
}