using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

[PrimaryKey(nameof(Id))]
public class ApplicationUser : IdentityUser<Guid>
{
  public Account? Account { get; set; }
}

public class ApplicationUserRole : IdentityRole<Guid>
{

}