using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using server.Models;

namespace server.Db;

public class DataContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
{
  public DataContext(DbContextOptions options) : base(options) { }

  // Data Tables
  public DbSet<Account>? Account { get; set; }
  //? Should ApplicationUser be in the DataContext?
  public DbSet<ApplicationUser>? ApplicationUser { get; set; }
  public DbSet<JobEntry>? JobEntries { get; set; }
}