using System;
using System.Linq;
using MangosSharp.Core;
using MangosSharp.Core.Security;
using MangosSharp.Data.Context;
using MangosSharp.Data.Entities.RealmDatabase;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Services;

public class AccountService : IAccountService
{
    private readonly IAuthService _authService;

    public AccountService(IAuthService authService)
    {
        _authService = authService;
    }

    public Account CreateAccount(ClassicrealmdDbContext db, string username, string password, string email)
    {
        var s = _authService.GenerateSalt();
        var v = _authService.CalculatePasswordVerifier(username, password, s.Span);

        var account = new Account
        {
            Username = username,
            Sessionkey = string.Empty,
            V = Convert.ToHexString(v.Reversed()),
            S = Convert.ToHexString(s.Reversed()),
            Email = email
        };

        db.Accounts.Add(account);
        return account;
    }

    public bool DeleteAccount(ClassicrealmdDbContext db, string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            return false;

        var upperUsername = username.ToUpperInvariant();
        var account = db.Accounts.FirstOrDefault(a => a.Username == upperUsername);
        if (account == default)
            return false;

        db.Accounts.Remove(account);
        return true;
    }

    public AccountBanned GetActiveAccountBan(ClassicrealmdDbContext db, long id)
    {
        var now = DateTimeOffset.Now.ToUnixTimeSeconds();
        var xid = (int)id;
        return db.AccountBanneds
            .FirstOrDefault(x => x.AccountId == xid &&
                                 x.Active == 1 &&
                                 (x.ExpiresAt > now || x.ExpiresAt == x.BannedAt));
    }

    public IpBanned GetActiveIpBan(ClassicrealmdDbContext db, string endpoint)
    {
        var now = DateTimeOffset.Now.ToUnixTimeSeconds();
        var ip = endpoint.Split(':')[0];
        return db.IpBanneds
            .FirstOrDefault(x => (x.ExpiresAt == x.BannedAt || x.ExpiresAt > now) && x.Ip == ip);
    }

    public Account GetActiveAccount(ClassicrealmdDbContext db, string username)
    {
        return db.Accounts.FirstOrDefault(x => x.Username == username);
    }

    public bool IsAccountAuthorized(ClassicrealmdDbContext db, long id, AccountType minimum)
    {
        if (minimum <= AccountType.PLAYER)
            return true;

        var xid = (uint)id;
        var gmLevel = (byte)minimum;
        return db.Accounts.Any(x => x.Id == xid && x.Gmlevel >= gmLevel);
    }

    public void LogAccountLogin(ClassicrealmdDbContext db, long id, string endpoint, LoginType loginType)
    {
        db.AccountLogons.Add(new AccountLogons
        {
            AccountId = (uint)id,
            Ip = endpoint.Split(':')[0],
            LoginTime = DateTime.Now,
            LoginSource = (uint)loginType
        });
    }
}