using Microsoft.EntityFrameworkCore;
using Moq;

using server.Db;
using server.Models;
using server.Services;

namespace server.Tests;

public class IAccountServiceTests
{
  private readonly List<Account> _accountEntities;
  private readonly AccountService _accountService;

  public IAccountServiceTests()
  {
    var mockContext = new Mock<DataContext>();
    var mockSet = new Mock<DbSet<Account>>();

    //TODO: Refactor to a reusable database
    // Create mock data
    _accountEntities = new List<Account>() {
      new Account() {ApplicationUserId = Guid.NewGuid()},
      new Account() {ApplicationUserId = Guid.NewGuid()},
      new Account() {ApplicationUserId = Guid.NewGuid()},
    };
    var queryable = _accountEntities.AsQueryable();

    //TODO: Refactor as a create mock set factory
    // Apply mock data to mockSet
    mockSet.As<IQueryable<Account>>().Setup(moq => moq.Provider).Returns(queryable.Provider);
    mockSet.As<IQueryable<Account>>().Setup(moq => moq.Expression).Returns(queryable.Expression);
    mockSet.As<IQueryable<Account>>().Setup(moq => moq.ElementType).Returns(queryable.ElementType);
    mockSet.As<IQueryable<Account>>().Setup(moq => moq.GetEnumerator()).Returns(() => queryable.GetEnumerator());

    // Provide mockSet to mockContext
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