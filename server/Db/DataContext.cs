using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using server.Models;

namespace server.Db;

public class DataContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
{
  // TODO: Are there any side effects to having the empty constructor
  // Empty constructor used when creating DataContext mock in testing
  public DataContext() { }
  public DataContext(DbContextOptions options) : base(options) { }

  // TODO: Are there any side effects to declaring these DbSets virtual?
  // Data Tables
  public virtual DbSet<Account>? Account { get; set; }
  public virtual DbSet<JobEntry>? JobEntries { get; set; }
}
