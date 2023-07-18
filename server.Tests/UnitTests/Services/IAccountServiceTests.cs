using Microsoft.EntityFrameworkCore;
using Moq;

using server.Db;
using server.Models;
using server.Services;
using server.Tests.Fixtures;
using server.Tests.Services;

namespace server.Tests;

public class IAccountServiceTests
{
  private readonly List<Account> _accountEntities;
  private readonly AccountService _accountService;

  public IAccountServiceTests()
  {
    _accountEntities = new AccountEntitiesFixture().GetAccountEntities();
    var mockSet = MockDbSetFactory.Create<Account>(_accountEntities);
    var mockContext = new Mock<DataContext>();

    mockContext.Setup(moq => moq.Account).Returns(() => mockSet.Object);
    _accountService = new AccountService(mockContext.Object);
  }

  [Theory]
  [InlineData(0)]
  [InlineData(1)]
  [InlineData(2)]
  public void GetAccountByUserId_ShouldFindAccountWithValidUserId(int entityIndex)
  {
    Account expected = _accountEntities[entityIndex];

    Account result = _accountService.GetAccountByUserId(expected.ApplicationUserId);

    Assert.Equal(expected, result);
  }

  [Fact]
  public void GetAccountbyUserId_ShouldThrowExceptionWithInvalidUserId()
  {
    string expected = "Sequence contains no matching element";
    Guid guid = new Guid();

    Action action = () => _accountService.GetAccountByUserId(guid);

    InvalidOperationException exception = Assert.Throws<InvalidOperationException>(action);
    Assert.Equal(expected, exception.Message);
  }
}