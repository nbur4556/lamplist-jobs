using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using server.Models;

namespace server.Db;

public class DataContext : IdentityDbContext<User, UserRole, Guid>
{
  public DataContext(DbContextOptions options) : base(options) { }

  // Data Tables
  public DbSet<JobEntry>? JobEntries { get; set; }
}