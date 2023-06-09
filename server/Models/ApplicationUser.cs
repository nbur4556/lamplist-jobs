using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

[PrimaryKey(nameof(Id))]
public class ApplicationUser : IdentityUser<Guid>
{
  //! Not finding related Account
  public Account? Account { get; set; }
}

public class ApplicationUserRole : IdentityRole<Guid>
{

}