using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Db;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions options) : base(options) { }

  // Data Tables
  public DbSet<JobEntry>? JobEntries { get; set; }
}