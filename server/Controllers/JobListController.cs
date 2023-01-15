using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using server.Models;

namespace server.Controllers;

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
  public ActionResult<JobEntry> PostJobEntryToList()
  {
    JobEntry jobEntry = new JobEntry("Test Company 5");
    JobEntryData.Add(jobEntry);
    return jobEntry;
  }

  //TODO: Update job entry route/

  //TODO: Delete job entry route
}
