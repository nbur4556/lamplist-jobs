using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace server.Services;

public interface ITokenService
{
  string CreateToken(Claim[] claims);
}

public class TokenService : ITokenService
{
  private readonly IConfiguration _configuration;

  public TokenService(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public string CreateToken(Claim[] claims)
  {
    SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));
    JwtSecurityToken token = new JwtSecurityToken(
      issuer: _configuration["AuthSettings:Issuer"],
      audience: _configuration["AuthSettings:Audience"],
      claims: claims,
      expires: DateTime.Now.AddDays(1),
      signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

    string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
    return tokenAsString;
  }
}