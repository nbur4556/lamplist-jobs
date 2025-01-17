using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using server.Models;
using server.Services;

namespace server.Controllers;

public struct AuthRequest
{
  public string? userName { get; set; }
  public string? password { get; set; }
}

public struct LoginResponse
{
  public string authToken { get; set; }
  public bool succeeded { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IAccountService _accountService;
  private readonly ITokenService _tokenService;
  private readonly UserManager<ApplicationUser> _userManager;

  public AuthController(
    IAccountService accountService,
    ITokenService tokenService,
    UserManager<ApplicationUser> userManager)
  {
    _accountService = accountService;
    _tokenService = tokenService;
    _userManager = userManager;
  }

  // /api/Auth/register
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

  // /api/Auth/login
  [HttpPost("login")]
  public async Task<IActionResult> Login(AuthRequest request)
  {
    if (request.userName is null || request.password is null)
    {
      return BadRequest("UserName and Password are required");
    }

    ApplicationUser? user = await _userManager.FindByNameAsync(request.userName);
    if (user == null)
    {
      return Unauthorized();
    }

    bool isAuthorized = await _userManager.CheckPasswordAsync(user, request.password);
    if (isAuthorized == false)
    {
      return Unauthorized();
    }

    try
    {
      Account account = _accountService.GetAccountByUserId(user.Id);
      Claim[] claims = new[]
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim("AccountIdentifier", account.Id.ToString()),
      };
      string authToken = _tokenService.CreateToken(claims);
      return Ok(new LoginResponse() { succeeded = true, authToken = authToken });
    }
    catch (Exception exception)
    {
      return BadRequest(exception.ToString());
    }
  }
}
