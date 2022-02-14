using MangosSharp.Data.Context;
using MangosSharp.Data.Entities.CharacterDatabase;
using MangosSharp.Data.Entities.RealmDatabase;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Services;

public interface IAccountService
{
    Account CreateAccount(ClassicrealmdDbContext db, string username, string password, string email);
    bool DeleteAccount(ClassicrealmdDbContext db, string username);
    AccountBanned GetActiveAccountBan(ClassicrealmdDbContext db, long id);
    IpBanned GetActiveIpBan(ClassicrealmdDbContext db, string endpoint);
    Account GetAccount(ClassicrealmdDbContext db, string username);
    Account GetActiveAccount(ClassicrealmdDbContext db, string username);
    bool IsAccountAuthorized(ClassicrealmdDbContext db, long id, AccountType minimum);
    void LogAccountLogin(ClassicrealmdDbContext db, long id, string endpoint, LoginType loginType);
    int GetGlobalCharacterCount(ClassicrealmdDbContext db, long id);
    int GetRealmCharacterCount(ClassiccharactersDbContext db, long id);
    Characters GetCharacter(ClassiccharactersDbContext db, string name);
}