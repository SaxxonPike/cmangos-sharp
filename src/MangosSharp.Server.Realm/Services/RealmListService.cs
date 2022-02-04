using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangosSharp.Server.Core.Enums;
using MangosSharp.Server.Core.Services;
using MangosSharp.Server.Realm.Enums;
using MangosSharp.Server.Realm.Records;
using Microsoft.Extensions.Configuration;

namespace MangosSharp.Server.Realm.Services;

public class RealmListService : IRealmListService
{
    private readonly IDatabase _database;
    private readonly IConfiguration _configuration;

    private DateTimeOffset? _nextUpdateTime = DateTimeOffset.Now;
    private List<RealmEntry> _realms = new();

    public RealmListService(IDatabase database, IConfiguration configuration)
    {
        _database = database;
        _configuration = configuration;
        Task.Run(() => UpdateRealms(true));
    }


    public IReadOnlyList<RealmEntry> Realms => _realms.ToList();

    public IEnumerable<RealmEntry> LoadRealmList(int accountId, AccountType securityLevel) => _realms;

    public void UpdateIfNeed()
    {
        if (DateTimeOffset.Now >= _nextUpdateTime)
            UpdateRealms(false);
    }

    public void UpdateRealms(bool init)
    {
        var newRealms = new List<RealmEntry>();
        foreach (var realm in _database.UseLogin(db => db.Realmlists.ToList()))
        {
            newRealms.Add(new RealmEntry
            {
                Id = realm.Id,
                Name = realm.Name,
                Endpoint = $"{realm.Address}:{realm.Port}",
                Icon = realm.Icon,
                Flags = (RealmFlag)realm.Realmflags,
                TimeZone = realm.Timezone,
                AllowedSecurityLevel = realm.AllowedSecurityLevel,
                PopulationLevel = realm.Population,
                Builds = realm.Realmbuilds
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => int.TryParse(i, out var v) ? v : int.MinValue)
                    .Where(i => i >= 0)
                    .ToArray()
            });
        }
        _realms.Clear();
        _realms.AddRange(newRealms);
    }
}