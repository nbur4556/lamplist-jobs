using Microsoft.AspNetCore.Mvc;

using server.Models;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class JobListController : ControllerBase
{
  JobEntry[] JobEntryList = {
    new JobEntry("Test Company 1"),
    new JobEntry("Test Company 2", "Test Contact 2"),
    new JobEntry("Test Company 3", "Test Contact 3", 3),
    new JobEntry("Test Company 4", "Test Contact 4", 4, "Test Posting 4")
  };

  [HttpGet]
  public ActionResult<JobEntry[]> GetJobList()
  {
    return JobEntryList;
  }
}
