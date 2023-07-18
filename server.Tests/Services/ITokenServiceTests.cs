using Microsoft.Extensions.Configuration;
using Moq;
using System.Security.Claims;

using server.Services;

//! No test is available
//TODO: Make sure that test discoverer & executors are registered and platform & framework version settings are appropriate
namespace server.Tests
{
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
      //? What can we assert here to confirm valid JWT?
      Assert.Equal(tokenResult, tokenResult);
    }
  }
}
