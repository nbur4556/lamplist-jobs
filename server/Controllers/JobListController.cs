using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using server.Db;
using server.Models;

namespace server.Controllers;

//TODO: Account ownership of job entries
public class JobEntryRequest
{
  public string? company { get; set; }
  public string? contact { get; set; }
  public int? interest { get; set; }
  public string? posting { get; set; }
}

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class JobListController : ControllerBase
{
  private readonly DataContext _context;

  public JobListController(DataContext context)
  {
    _context = context;
  }

  // /api/JobList
  [HttpGet]
  public ActionResult<JobEntry[]> GetJobList()
  {
    IOrderedQueryable<JobEntry>? jobEntries = _context.JobEntries?.OrderBy(entry => entry.Id);
    if (jobEntries == null)
    {
      return NotFound();
    }
    return jobEntries.ToArray<JobEntry>();
  }

  // /api/JobList
  [HttpPost]
  public IActionResult CreateJobEntry(JobEntryRequest request)
  {
    if (request.company is null)
    {
      return BadRequest("Company name is required.");
    }

    JobEntry jobEntry = new JobEntry(request.company);
    _context.Add(jobEntry);
    _context.SaveChanges();
    return CreatedAtAction(nameof(CreateJobEntry), jobEntry);
  }

  // /api/JobList/{id}
  [HttpPatch("{id}")]
  public ActionResult<JobEntry> PatchJobEntry(Guid id, JobEntryRequest request)
  {
    JobEntry? jobEntry = _context.Find<JobEntry>(id);
    if (jobEntry is null) { return NotFound(); }

    if (request.company != null)
    {
      jobEntry.Company = request.company;
    }
    if (request.contact != null)
    {
      jobEntry.Contact = request.contact;
    }
    if (request.interest != null)
    {
      jobEntry.Interest = request.interest;
    }
    if (request.posting != null)
    {
      jobEntry.Posting = request.posting;
    }

    _context.SaveChanges();
    return jobEntry;
  }

  // /api/JobList/{id}
  [HttpDelete("{id}")]
  public IActionResult DeleteJobEntry(Guid id)
  {
    JobEntry? jobEntry = _context.Find<JobEntry>(id);
    if (jobEntry is null)
    {
      return NotFound();
    }

    _context.Remove<JobEntry>(jobEntry);
    _context.SaveChanges();
    return Ok("Job entry id: " + id + " removed.");
  }
}
