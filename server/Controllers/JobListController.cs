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
      return BadRequest("company name is required.");
    }

    JobEntry jobEntry = new JobEntry(request.company);
    JobEntryData.Add(jobEntry);
    return CreatedAtAction(nameof(CreateJobEntry), jobEntry);
  }

  //TODO: Update job entry route/

  //TODO: Delete job entry route
}
