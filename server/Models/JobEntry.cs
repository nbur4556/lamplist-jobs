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

  public Guid AccountId { get; set; }
  public Account Account { get; set; }
}