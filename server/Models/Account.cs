using Microsoft.EntityFrameworkCore;

namespace server.Models;

[PrimaryKey(nameof(Id))]
public class Account
{
  public Guid Id { get; set; }
  public Guid ApplicationUserId { get; set; }
  public ApplicationUser ApplicationUser { get; set; }
}