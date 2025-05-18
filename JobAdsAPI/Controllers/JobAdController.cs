using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobAdsAPI.Models;
using JobAdsAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JobAdsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobAdController(JobAdDbContext context) : ControllerBase
{
    private readonly JobAdDbContext _context = context;    //indepndency injection

    [HttpGet]
    public async Task<ActionResult<List<JobAd>>> GetJobAds()
    {
        return Ok(await _context.JobAds.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobAd>> GetJobAdById(int id)
    {
        var jobAd = await _context.JobAds.FindAsync(id);
        if (jobAd == null)
            return NotFound();
        
        return Ok(jobAd);
    }

    [HttpPost]
    public async Task<ActionResult<JobAd>> AddJobAd(JobAd newAd)
    {
        if (newAd == null)
            return BadRequest();

        _context.JobAds.Add(newAd);
        await _context.SaveChangesAsync(); // Save changes to the database

        return CreatedAtAction(nameof(GetJobAdById), new { id = newAd.Id }, newAd);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJobAd(int id, JobAd updatedAd)
    {
        var existingAd = await _context.JobAds.FindAsync(id);
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

        await _context.SaveChangesAsync(); 

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJobAd(int id)
    {
        var jobAd = await _context.JobAds.FindAsync(id);
        if (jobAd == null)
            return NotFound();

        _context.JobAds.Remove(jobAd);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}