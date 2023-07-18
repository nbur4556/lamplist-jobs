using Microsoft.Extensions.Configuration;
using Moq;
using System.Security.Claims;

using server.Services;

namespace server.Tests;

public class ITokenServiceTests
{
  private readonly Mock<IConfiguration> _configurationMock;

  public ITokenServiceTests()
  {
    _configurationMock = new Mock<IConfiguration>();
  }

  [Fact]
  public void CreateToken_ShouldReturnNewSecurityTokenAsString()
  {
    _configurationMock.SetupGet(x => x[It.Is<string>(s => s == "AuthSettings:Key")]).Returns("testPassphrase123");
    _configurationMock.SetupGet(x => x[It.Is<string>(s => s == "AuthSettings:Issuer")]).Returns("testIssuer");
    _configurationMock.SetupGet(x => x[It.Is<string>(s => s == "AuthSettings:Audience")]).Returns("testAudience");

    TokenService tokenService = new TokenService(_configurationMock.Object);
    Claim[] claims = new[]
    {
      new Claim(ClaimTypes.NameIdentifier, "testId"),
      new Claim("AccountIdentifier", "accountId"),
    };

    string tokenResult = tokenService.CreateToken(claims);
    //? What other JWT assertiong can be included?
    //? Can we assert that the tokenResult is in a valid JWT format?
    //? Can we assert that the tokenResult contains the JWT claims?
    Assert.IsType<string>(tokenResult);
    Assert.Equal(308, tokenResult.Length);
  }
}
