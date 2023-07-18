using Moq;

using server.Db;
using server.Models;
using server.Services;

namespace server.Tests;

public class IAccountServiceTests
{
  //TODO: Mock data context so that it will return an account with a matching account ID, and properly throw an expection with an invalid id
  private readonly Mock<DataContext> _mockContext;
  private readonly AccountService _accountService;

  public IAccountServiceTests()
  {
    _mockContext = new Mock<DataContext>();
    _accountService = new AccountService(_mockContext.Object);
  }

  [Fact]
  public void GetAccountByUserId_ShouldGetAccountWithValidUserId()
  {
    Account accountExpected = new Account();
    Account accountResult = _accountService.GetAccountByUserId(accountExpected.Id);
    Assert.Equal(accountExpected, accountResult);
  }

  // public void GetAccountbyUserId_ShouldThrowExceptionWithInvalidUserId()
  // {

  // }
}