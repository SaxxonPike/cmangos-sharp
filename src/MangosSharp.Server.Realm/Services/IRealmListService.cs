using System.Collections.Generic;
using MangosSharp.Server.Core.Enums;
using MangosSharp.Server.Core.Services;
using MangosSharp.Server.Realm.Enums;
using MangosSharp.Server.Realm.Records;

namespace MangosSharp.Server.Realm.Services;

public interface IRealmListService
{
    IEnumerable<RealmEntry> LoadRealmList(int accountId, AccountType securityLevel);
    void UpdateIfNeed();
    void UpdateRealms(bool init);
}