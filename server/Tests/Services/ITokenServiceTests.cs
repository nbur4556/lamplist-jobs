using Moq;
using System.Security.Claims;
using Xunit;

using server.Services;

//! No test is available
//TODO: Make sure that test discoverer & executors are registered and platform & framework version settings are appropriate
namespace server.Tests
{
  public class ITokenServiceTests
  {
    [Fact]
    public void CreateToken_ShouldReturnNewSecurityTokenAsString()
    {
      // Arrange
      Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();
      TokenService _tokenService = new TokenService(configurationMock.Object);
      Claim[] claims = new[]
      {
        new Claim(ClaimTypes.NameIdentifier, "testId"),
        new Claim("AccountIdentifier", "accountId"),
      };

      // Act
      string tokenResult = _tokenService.CreateToken(claims);

      // Assert
      Assert.Equal(tokenResult, tokenResult);
    }
  }
}
