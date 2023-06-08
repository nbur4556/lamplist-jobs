using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

[PrimaryKey(nameof(Id))]
public class User : IdentityUser<Guid>
{

}

public class UserRole : IdentityRole<Guid>
{

}