using Microsoft.AspNetCore.Mvc;

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
  List<JobEntry> JobEntryData = new List<JobEntry>();

  public JobListController()
  {
    JobEntryData.Add(new JobEntry("Test Company 1"));
    JobEntryData.Add(new JobEntry("Test Company 2", contact: "Test Contact"));
    JobEntryData.Add(new JobEntry("Test Company 3", interest: 3));
    JobEntryData.Add(new JobEntry("Test Company 4", posting: "Test Posting"));
  }

  [HttpGet]
  public ActionResult<JobEntry[]> GetJobList()
  {
    return JobEntryData.ToArray<JobEntry>();
  }

  [HttpPost]
  public IActionResult CreateJobEntry(JobEntryRequest request)
  {
    if (request.company is null)
    {
      return BadRequest("Company name is required.");
    }

    JobEntry jobEntry = new JobEntry(request.company);
    JobEntryData.Add(jobEntry);
    return CreatedAtAction(nameof(CreateJobEntry), jobEntry);
  }

  [HttpPatch("{id}")]
  public ActionResult<JobEntry> PatchJobEntry(int id, JobEntryRequest request)
  {
    if (id >= JobEntryData.Count() || id < 0)
    {
      return NotFound();
    }

    if (request.company != null)
    {
      JobEntryData[id].Company = request.company;
    }
    if (request.contact != null)
    {
      JobEntryData[id].Contact = request.contact;
    }
    if (request.interest != null)
    {
      JobEntryData[id].Interest = request.interest;
    }
    if (request.posting != null)
    {
      JobEntryData[id].Posting = request.posting;
    }

    return JobEntryData[id];
  }

  //TODO: Delete job entry route
}
