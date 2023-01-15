using Microsoft.AspNetCore.Mvc;

using server.Models;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobListController : ControllerBase
{
  JobEntry[] JobEntryList = {
    new JobEntry("Test Company 1"),
    new JobEntry("Test Company 2", contact: "Test Contact"),
    new JobEntry("Test Company 3", interest: 3),
    new JobEntry("Test Company 4", posting: "Test Posting")
  };

  [HttpGet]
  public ActionResult<JobEntry[]> GetJobList()
  {
    return JobEntryList;
  }
}
