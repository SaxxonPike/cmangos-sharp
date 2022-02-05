using MangosSharp.Data.Context;
using MangosSharp.Data.Entities.RealmDatabase;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Services;

public interface IAccountService
{
    Account CreateAccount(ClassicrealmdDbContext db, string username, string password, string email);
    bool DeleteAccount(ClassicrealmdDbContext db, string username);
    AccountBanned GetActiveAccountBan(ClassicrealmdDbContext db, long id);
    IpBanned GetActiveIpBan(ClassicrealmdDbContext db, string endpoint);
    Account GetActiveAccount(ClassicrealmdDbContext db, string username);
    bool IsAccountAuthorized(ClassicrealmdDbContext db, long id, AccountType minimum);
    void LogAccountLogin(ClassicrealmdDbContext db, long id, string endpoint, LoginType loginType);
}