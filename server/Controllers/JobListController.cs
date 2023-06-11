using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using server.Db;
using server.Models;
using server.Services;

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
[Authorize]
public class JobListController : ControllerBase
{
  private readonly DataContext _context;
  private readonly IAccountService _accountService;

  public JobListController(DataContext context, IAccountService accountService)
  {
    _accountService = accountService;
    _context = context;
  }

  private Account? FindAuthorizedAccount()
  {
    ClaimsPrincipal currentUser = this.User;
    Claim? userClaim = currentUser.FindFirst(ClaimTypes.NameIdentifier);

    if (userClaim == null)
    {
      return null;
    }

    Guid currentUserId = Guid.Parse(userClaim.Value);
    Account account = _accountService.GetAccountByUserId(currentUserId);
    return account;
  }

  // /api/JobList
  [HttpGet]
  public ActionResult<JobEntry[]> GetJobList()
  {
    Account? account = this.FindAuthorizedAccount();
    if (account == null)
    {
      return Unauthorized();
    }

    IOrderedQueryable<JobEntry> jobEntries = _context.JobEntries
      .Where(entry => entry.AccountId.Equals(account.Id))
      .OrderBy(entry => entry.Id);
    Console.WriteLine(jobEntries);
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
    Account? account = this.FindAuthorizedAccount();
    if (account == null)
    {
      return Unauthorized();
    }
    if (request.company is null)
    {
      return BadRequest("Company name is required.");
    }

    JobEntry jobEntry = new JobEntry()
    {
      Account = account,
      Company = request.company,
    };
    _context.Add(jobEntry);
    _context.SaveChanges();
    return CreatedAtAction(nameof(CreateJobEntry), jobEntry);
  }

  // /api/JobList/{id}
  [HttpPatch("{id}")]
  public ActionResult<JobEntry> PatchJobEntry(Guid id, JobEntryRequest request)
  {
    Account? account = this.FindAuthorizedAccount();
    JobEntry? jobEntry = _context.Find<JobEntry>(id);
    if (jobEntry is null)
    {
      return NotFound();
    }
    if (account?.Id == null || jobEntry.AccountId != account.Id)
    {
      return Unauthorized();
    }

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
    Account? account = this.FindAuthorizedAccount();
    JobEntry? jobEntry = _context.Find<JobEntry>(id);
    if (jobEntry is null)
    {
      return NotFound();
    }
    if (account?.Id == null || jobEntry.AccountId != account.Id)
    {
      return Unauthorized();
    }

    _context.Remove<JobEntry>(jobEntry);
    _context.SaveChanges();
    return Ok("Job entry id: " + id + " removed.");
  }
}
