using Microsoft.EntityFrameworkCore;

namespace server.Models;

[PrimaryKey(nameof(Id))]
public class User
{
  public Guid Id { get; set; }
  public string Username { get; set; }

  public User(string username)
  {
    Username = username;
  }
}