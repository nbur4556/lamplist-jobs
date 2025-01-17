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

// FIX: fix-api-end-of-json-error: BadRequest messages are not being received by client
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IAccountService _accountService;
  private readonly ITokenService _tokenService;
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly ILogger _logger;

  public AuthController(
    IAccountService accountService,
    ITokenService tokenService,
    ILoggerFactory loggerFactory,
    UserManager<ApplicationUser> userManager)
  {
    _accountService = accountService;
    _tokenService = tokenService;
    _userManager = userManager;
    _logger = loggerFactory.CreateLogger("AuthController");
  }

  // /api/Auth/register
  [HttpPost("register")]
  public async Task<IActionResult> Register(AuthRequest request)
  {
    if (request.userName is null || request.password is null)
    {
      _logger.LogError("Username and Password are required");
      return BadRequest("Username and Password are required");
    }

    ApplicationUser user = new ApplicationUser()
    {
      UserName = request.userName,
      Account = new Account(),
    };
    IdentityResult result = await _userManager.CreateAsync(user, request.password);
    return CreatedAtAction(nameof(Register), result);
  }

  // FIX: fix-api-end-of-json-error: increase length of JWT secret key
  // /api/Auth/login
  [HttpPost("login")]
  public async Task<IActionResult> Login(AuthRequest request)
  {
    if (request.userName is null || request.password is null)
    {
      _logger.LogError("Username and Password are required");
      return BadRequest("Username and Password are required");
    }

    ApplicationUser? user = await _userManager.FindByNameAsync(request.userName);
    if (user == null)
    {
      _logger.LogError("Unauthorized");
      return Unauthorized();
    }

    bool isAuthorized = await _userManager.CheckPasswordAsync(user, request.password);
    if (isAuthorized == false)
    {
      _logger.LogError("Unauthorized");
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
      _logger.LogError(exception.ToString());

      // FIX:: fix-api-end-of-json-error: This bad request message is not being displayed on client side
      // FIX : fix-api-end-of-json-error: Reproduce by shortening Authorization key (appsettings.Development.json) until user can not log with too short of an encryption key. See that the message never makes it to the client
      return BadRequest(exception.ToString());
    }
  }
}
