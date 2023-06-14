using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace server.Models;

[PrimaryKey(nameof(Id))]
public class Account
{
  public Guid Id { get; set; }
  public Guid ApplicationUserId { get; set; }

  public ApplicationUser? ApplicationUser { get; set; }

  [JsonIgnore]
  public ICollection<JobEntry> JobEntries { get; } = new List<JobEntry>();
}