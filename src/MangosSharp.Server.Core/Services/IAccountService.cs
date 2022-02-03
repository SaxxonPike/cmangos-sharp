using MangosSharp.Data.Entities.RealmDatabase;

namespace MangosSharp.Server.Core.Services;

public interface IAccountService
{
    Account Create(string username, string password, string email);
    bool Delete(string username);
}