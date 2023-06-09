using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using server.Db;
using server.Models;

namespace server.Controllers;

public struct AuthRequest
{
  public string? userName { get; set; }
  public string? password { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly DataContext _context;
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly SignInManager<ApplicationUser> _signInManager;

  public AuthController(
    DataContext context,
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager)
  {
    _context = context;
    _userManager = userManager;
    _signInManager = signInManager;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(AuthRequest request)
  {
    if (request.userName is null || request.password is null)
    {
      return BadRequest("UserName and Password are required");
    }

    //! User is still created when account creation fails. Should have a way to rewind.
    ApplicationUser user = new ApplicationUser() { UserName = request.userName };
    IdentityResult result = await _userManager.CreateAsync(user, request.password);

    Account account = new Account()
    {
      ApplicationUser = user,
      ApplicationUserId = user.Id,
    };
    _context.Add(account);
    _context.SaveChanges();
    return CreatedAtAction(nameof(Register), result);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(AuthRequest request)
  {
    if (request.userName is null || request.password is null)
    {
      return BadRequest("UserName and Password are required");
    }

    var result = await _signInManager.PasswordSignInAsync(
      request.userName, request.password, false, false
    );
    return CreatedAtAction(nameof(Login), result);
  }

  //TODO: JWT Authentication

  //TODO: Logout

  //TODO: Forgot Password
}