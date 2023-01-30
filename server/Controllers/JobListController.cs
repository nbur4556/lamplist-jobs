using Microsoft.AspNetCore.Mvc;

using server.Db;
using server.Models;

namespace server.Controllers;

public class JobEntryRequest
{
  public string? company { get; set; }
  public string? contact { get; set; }
  public int? interest { get; set; }
  public string? posting { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class JobListController : ControllerBase
{
  private readonly DataContext _context;
  List<JobEntry> JobEntryData = new List<JobEntry>();

  public JobListController(DataContext context)
  {
    JobEntryData.Add(new JobEntry("Test Company 1"));
    JobEntryData.Add(new JobEntry("Test Company 2", contact: "Test Contact"));
    JobEntryData.Add(new JobEntry("Test Company 3", interest: 3));
    JobEntryData.Add(new JobEntry("Test Company 4", posting: "Test Posting"));
    _context = context;
  }

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

  [HttpDelete("{id}")]
  public IActionResult DeleteJobEntry(int id)
  {
    if (id >= JobEntryData.Count() || id < 0)
    {
      return NotFound();
    }

    JobEntryData.RemoveAt(id);
    return Ok("Job entry id: " + id + " removed.");
  }
}
