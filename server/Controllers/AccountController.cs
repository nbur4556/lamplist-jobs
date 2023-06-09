using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using server.Db;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController : ControllerBase
{
  private readonly DataContext _context;

  public AccountController(DataContext context)
  {
    _context = context;
  }

  //TODO: Refactor this to a service
  // /api/Account/{userId}
  [HttpGet("{userId}")]
  public ActionResult<Account> GetAccountByUserId(Guid userId)
  {
    Account? account = _context?.Account
      ?.Single(e => e.ApplicationUserId.Equals(userId));

    if (account == null)
    {
      return NotFound();
    }

    return account;
  }
}