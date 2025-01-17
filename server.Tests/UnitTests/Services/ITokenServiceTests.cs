using Microsoft.Extensions.Configuration;
using Moq;
using System.Security.Claims;

using server.Services;

namespace server.Tests;

// FIX: lots of linter errors on this file after package update. App builds fine, but should check out these errors
public class ITokenServiceTests
{
  private readonly TokenService _tokenService;

  public ITokenServiceTests()
  {
    Mock<IConfiguration> mockConfiguration = new Mock<IConfiguration>();
    mockConfiguration
      .SetupGet(moq => moq[It.Is<string>(param => param == "AuthSettings:Key")])
      .Returns("testPassphrase123");
    mockConfiguration
      .SetupGet(moq => moq[It.Is<string>(param => param == "AuthSettings:Issuer")])
      .Returns("testIssuer");
    mockConfiguration
      .SetupGet(moq => moq[It.Is<string>(param => param == "AuthSettings:Audience")])
      .Returns("testAudience");
    _tokenService = new TokenService(mockConfiguration.Object);
  }

  [Theory]
  [InlineData("id", "account", 300)]
  [InlineData("testId", "testAccount", 311)]
  public void CreateToken_ShouldReturnNewSecurityTokenAsString(string id, string account, int expectedLength)
  {
    Claim[] claims = new[]
    {
      new Claim(ClaimTypes.NameIdentifier, id),
      new Claim("AccountIdentifier", account),
    };

    string tokenResult = _tokenService.CreateToken(claims);

    // TODO: What other JWT assertions can be included?
    // TODO: Can we assert that the tokenResult is in a valid JWT format?
    // TODO: Can we assert that the tokenResult contains the JWT claims?
    Assert.IsType<string>(tokenResult);
    Assert.Equal(expectedLength, tokenResult.Length);
  }
}
