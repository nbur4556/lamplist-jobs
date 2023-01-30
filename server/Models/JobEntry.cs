using Microsoft.EntityFrameworkCore;

namespace server.Models;

[PrimaryKey(nameof(Id))]
public class JobEntry
{
  public Guid Id { get; set; }
  public string Company { get; set; }
  public string? Contact { get; set; }
  public int? Interest { get; set; }
  public string? Posting { get; set; }

  public JobEntry(
    string company,
    string? contact = null,
    int? interest = null,
    string? posting = null
  )
  {
    Company = company;
    Contact = contact;
    Interest = interest;
    Posting = posting;
  }
}