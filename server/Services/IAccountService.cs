using server.Db;
using server.Models;

namespace server.Services;

public interface IAccountService
{
  Account GetAccountByUserId(Guid userId);
}

public class AccountService : IAccountService
{
  private readonly DataContext _context;

  public AccountService(DataContext context)
  {
    _context = context;
  }

  public Account GetAccountByUserId(Guid userId)
  {
    Account? account = _context?.Account
      ?.Single(e => e.ApplicationUserId.Equals(userId));

    if (account == null)
    {
      throw new Exception("Can not find account");
    }

    return account;
  }
}