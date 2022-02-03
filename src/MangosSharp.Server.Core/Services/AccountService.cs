using System;
using System.Linq;
using MangosSharp.Core;
using MangosSharp.Core.Security;
using MangosSharp.Data.Entities.RealmDatabase;

namespace MangosSharp.Server.Core.Services;

public class AccountService : IAccountService
{
    private readonly IDatabase _database;
    private readonly IAuthService _authService;

    public AccountService(IDatabase database, IAuthService authService)
    {
        _database = database;
        _authService = authService;
    }
    
    public Account Create(string username, string password, string email)
    {
        var s = _authService.GenerateSalt();
        var v = _authService.CalculatePasswordVerifier(username, password, s.Span);

        return _database.UseLogin(db =>
        {
            var account = new Account
            {
                Username = username,
                Sessionkey = string.Empty,
                V = Convert.ToHexString(v.Reversed()),
                S = Convert.ToHexString(s.Reversed()),
                Email = email
            };

            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        });
    }

    public bool Delete(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            return false;
        
        return _database.UseLogin(db =>
        {
            var upperUsername = username.ToUpperInvariant();
            var account = db.Accounts.FirstOrDefault(a => a.Username == upperUsername);
            if (account == default)
                return false;

            db.Accounts.Remove(account);
            db.SaveChanges();
            return true;
        });
    }
}