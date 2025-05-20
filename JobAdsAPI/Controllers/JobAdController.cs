using Microsoft.AspNetCore.Mvc;
using JobAdsAPI.Models;
using JobAdsAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace JobAdsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobAdController(JobAdDbContext context) : ControllerBase
{
    private readonly JobAdDbContext _context = context;    //indepndency injection

    [HttpGet]
    public async Task<ActionResult<List<JobAd>>> GetJobAds()
    {
        var jobAds = await _context.JobAds
            .Include(j => j.JobAdDescription)
            .Include(j => j.Location)
            .Include(j => j.WorkType)
            .Include(j => j.ExpierienceLevel)
            .Include(j => j.OtherSkills) // Include the OtherSkills relationship
            .ToListAsync();

        return Ok(jobAds);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobAd>> GetJobAdById(int id)
    {
        var jobAd = await _context.JobAds
            .Include(j => j.JobAdDescription)
            .Include(j => j.Location)
            .Include(j => j.WorkType)
            .Include(j => j.ExpierienceLevel)
            .Include(j => j.OtherSkills)
            .FirstOrDefaultAsync(j => j.Id == id);

        if (jobAd == null)
            return NotFound();

        return Ok(jobAd);
    }

    [HttpPost]
    public async Task<ActionResult<JobAd>> AddJobAd(JobAd newAd)
    {
        if (newAd == null)
            return BadRequest();

        // Ensure navigation properties are not re-attached as new entities
        if (newAd.Location != null)
        {
            _context.Entry(newAd.Location).State = EntityState.Unchanged;
        }
        if (newAd.WorkType != null)
        {
            _context.Entry(newAd.WorkType).State = EntityState.Unchanged;
        }
        if (newAd.ExpierienceLevel != null)
        {
            _context.Entry(newAd.ExpierienceLevel).State = EntityState.Unchanged;
        }
        if (newAd.OtherSkills != null)
        {
            foreach (var skill in newAd.OtherSkills)
            {
                _context.Entry(skill).State = EntityState.Unchanged;
            }
        }

        _context.JobAds.Add(newAd);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetJobAdById), new { id = newAd.Id }, newAd);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJobAd(int id, JobAd updatedAd)
    {
        var existingAd = await _context.JobAds
            .Include(j => j.OtherSkills)
            .Include(j => j.JobAdDescription)
            .FirstOrDefaultAsync(j => j.Id == id);

        if (existingAd == null)
            return NotFound();

        // Update scalar properties
        existingAd.PublishedAt = updatedAd.PublishedAt;
        existingAd.CompanyName = updatedAd.CompanyName;
        existingAd.JobTitle = updatedAd.JobTitle;
        existingAd.IsCSharpMentioned = updatedAd.IsCSharpMentioned;
        existingAd.IsDotNetMentioned = updatedAd.IsDotNetMentioned;
        existingAd.IsSQLMentioned = updatedAd.IsSQLMentioned;

        // Update navigation properties by ID
        if (updatedAd.LocationId != null)
            existingAd.LocationId = updatedAd.LocationId;
        if (updatedAd.WorkTypeId != null)
            existingAd.WorkTypeId = updatedAd.WorkTypeId;
        if (updatedAd.ExpierienceLevelId != null)
            existingAd.ExpierienceLevelId = updatedAd.ExpierienceLevelId;

        // Update JobAdDescription
        if (existingAd.JobAdDescription != null && updatedAd.JobAdDescription != null)
        {
            existingAd.JobAdDescription.JobDescription = updatedAd.JobAdDescription.JobDescription;
            existingAd.JobAdDescription.EmployerDescription = updatedAd.JobAdDescription.EmployerDescription;
        }

        // Update OtherSkills (many-to-many)
        if (updatedAd.OtherSkills != null)
        {
            existingAd.OtherSkills?.Clear();
            foreach (var skill in updatedAd.OtherSkills)
            {
                _context.Entry(skill).State = EntityState.Unchanged;
                existingAd.OtherSkills?.Add(skill);
            }
        }

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJobAd(int id)
    {
        // Fix for CS0128: Renamed the second 'jobAd' variable to 'jobAdToDelete' to avoid conflict.
        var jobAd = await _context.JobAds
            .Include(j => j.JobAdDescription)
            .Include(j => j.OtherSkills)
            .FirstOrDefaultAsync(j => j.Id == id);

        if (jobAd == null)
            return NotFound();

        // Optionally remove related entities if not handled by cascade delete
        if (jobAd.JobAdDescription != null)
            _context.JobAdDescriptions.Remove(jobAd.JobAdDescription);

        _context.JobAds.Remove(jobAd);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Just to check
    [HttpGet("ping")]
    public async Task<IActionResult> PingDb()
    {
        var canConnect = await _context.Database.CanConnectAsync();
        return Ok(canConnect ? "Database is connected." : "Database is not connected.");
    }
}