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
    //? Single may not be the best to use here? Keeps throwing errors if multiple or none found
    Account? account = _context?.Account
      ?.Single(e => e.ApplicationUserId.Equals(userId));

    //? Should we just except the default InvalidOperationException thrown? Or should we throw our own?
    if (account == null)
    {
      throw new Exception("Can not find account");
    }

    return account;
  }
}