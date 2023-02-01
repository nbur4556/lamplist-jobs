using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using server.Db;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly DataContext _context;
  private readonly UserManager<User> _userManager;

  public AuthController(DataContext context, UserManager<User> userManager)
  {
    _context = context;
    _userManager = userManager;
  }

  //TODO: Use username and password input
  [HttpPost]
  public async Task<IActionResult> Register()
  {
    User user = new User() { UserName = "" };
    var result = await _userManager.CreateAsync(user, "");

    return CreatedAtAction(nameof(Register), result);
  }
}