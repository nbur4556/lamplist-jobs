using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

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

    ApplicationUser user = new ApplicationUser()
    {
      UserName = request.userName,
      Account = new Account(),
    };
    IdentityResult result = await _userManager.CreateAsync(user, request.password);
    return CreatedAtAction(nameof(Register), result);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(AuthRequest request)
  {
    if (request.userName is null || request.password is null)
    {
      return BadRequest("UserName and Password are required");
    }

    SignInResult result = await _signInManager.PasswordSignInAsync(
      request.userName, request.password, false, false
    );

    // //! Debugging registered user unable to access account
    if (result == SignInResult.Success)
    {
      ApplicationUser? user = await _userManager.FindByNameAsync(request.userName);
      if (user == null)
      {
        Console.WriteLine("user is null");
        return CreatedAtAction(nameof(Login), result);
      }

      Account? account = _context?.Account?.Single(e => e.ApplicationUserId.Equals(user.Id));
      if (account == null)
      {
        Console.WriteLine("account is null");
        return CreatedAtAction(nameof(Login), result);
      }
      Console.WriteLine(account.Id);
      Console.WriteLine(account.ApplicationUserId);
      Console.WriteLine(account.ApplicationUser);
    }

    return CreatedAtAction(nameof(Login), result);
  }

  //TODO: JWT Authentication

  //TODO: Logout

  //TODO: Forgot Password
}