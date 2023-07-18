namespace server.Tests.Fixtures;

using server.Models;

public class AccountEntitiesFixture
{
  private List<Account> _accountEntities;

  public AccountEntitiesFixture()
  {
    _accountEntities = new List<Account>() {
      new Account() {ApplicationUserId = Guid.NewGuid()},
      new Account() {ApplicationUserId = Guid.NewGuid()},
      new Account() {ApplicationUserId = Guid.NewGuid()},
    };
  }

  public List<Account> GetAccountEntities()
  {
    return _accountEntities;
  }
}