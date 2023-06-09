using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using server.Models;
using server.Services;

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
  private readonly IAccountService _accountService;
  private readonly IConfiguration _configuration;
  private readonly UserManager<ApplicationUser> _userManager;

  public AuthController(
    IAccountService accountService,
    IConfiguration configuration,
    UserManager<ApplicationUser> userManager)
  {
    _accountService = accountService;
    _configuration = configuration;
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

      SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));
      JwtSecurityToken token = new JwtSecurityToken(
        issuer: _configuration["AuthSettings:Issuer"],
        audience: _configuration["AuthSettings:Audience"],
        claims: claims,
        expires: DateTime.Now.AddDays(1),
        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

      string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
      return CreatedAtAction(nameof(Login), tokenAsString);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.ToString());
    }
  }

  //TODO: JWT Authentication

  //TODO: Logout

  //TODO: Forgot Password
}