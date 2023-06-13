using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace server.Models;

[PrimaryKey(nameof(Id))]
public class Account
{
  public Guid Id { get; set; }
  public Guid ApplicationUserId { get; set; }

  public ApplicationUser ApplicationUser { get; set; }

  //? Is it possible to remove the JsonIgnore? https://stackoverflow.com/questions/60197270/jsonexception-a-possible-object-cycle-was-detected-which-is-not-supported-this
  [JsonIgnore]
  public ICollection<JobEntry> JobEntries { get; } = new List<JobEntry>();
}