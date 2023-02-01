using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

[PrimaryKey(nameof(Id))]
public class User : IdentityUser<Guid>
{
  public string Username { get; set; }

  public User(string username)
  {
    Username = username;
  }
}

public class UserRole : IdentityRole<Guid>
{

}