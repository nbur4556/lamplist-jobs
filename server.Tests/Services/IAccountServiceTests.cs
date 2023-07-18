using Moq;

using server.Db;
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

  // public void GetAccountByUserId_ShouldGetAccountWithValidUserId()
  // {

  // }

  // public void GetAccountbyUserId_ShouldThrowExceptionWithInvalidUserId()
  // {

  // }
}