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
      //! Multiple accounts will use the same Guid. Need a way to randomize this...
      //TODO: Add multiple accounts to select from
      new Account(),
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

  [Fact]
  public void GetAccountByUserId_ShouldGetAccountWithValidUserId()
  {
    Account expected = _accountEntities[0];

    Account result = _accountService.GetAccountByUserId(expected.Id);

    Assert.Equal(expected, result);
  }

  // [Fact]
  // public void GetAccountbyUserId_ShouldThrowExceptionWithInvalidUserId()
  // {
  //   //TODO: expect not found exception
  //   Account expected = new Account();
  //   Guid guid = new Guid();

  //   Account result = _accountService.GetAccountByUserId(guid);

  //   Assert.Equal(expected, result);
  // }
}