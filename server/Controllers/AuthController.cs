using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
  private readonly UserManager<User> _userManager;
  private readonly SignInManager<User> _signInManager;

  public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
  {
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

    User user = new User() { UserName = request.userName };
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

    var result = await _signInManager.PasswordSignInAsync(
      request.userName, request.password, false, false
    );
    return CreatedAtAction(nameof(Login), result);
  }

  //TODO: JWT Authentication

  //TODO: Logout

  //TODO: Forgot Password
}