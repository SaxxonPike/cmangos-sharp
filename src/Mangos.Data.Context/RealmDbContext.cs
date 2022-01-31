using Mangos.Data.Entities.RealmDatabase;
using Microsoft.EntityFrameworkCore;

namespace Mangos.Data.Context;

public class RealmDbContext : DbContext
{
    public RealmDbContext()
    {
    }

    public RealmDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<RealmdDbVersion>().HasKey(e => new { required_z2778_01_realmd_anticheat = e.RequiredZ277801RealmdAnticheat });
        builder.Entity<Account>().HasKey(e => new { id = e.Id });
        builder.Entity<AccountBan>().HasKey(e => new { id = e.Id });
        builder.Entity<AccountLogon>().HasKey(e => new { id = e.Id });
        builder.Entity<AccountRaf>().HasKey(e => new { referrer = e.Referrer, referred = e.Referred });
        builder.Entity<IpBan>().HasKey(e => new { ip = e.Ip, banned_at = e.BannedAt });
        builder.Entity<RealmCharacters>().HasKey(e => new { realmid = e.Realmid, acctid = e.Acctid });
        builder.Entity<RealmList>().HasKey(e => new { id = e.Id });
        builder.Entity<Uptime>().HasKey(e => new { realmid = e.Realmid, starttime = e.Starttime });
        builder.Entity<SystemFingerprintUsage>().HasKey(e => new { id = e.Id });
        builder.Entity<AntispamReplacement>().HasKey(e => new { from = e.From });
        builder.Entity<AntispamUnicodeReplacement>().HasKey(e => new { from = e.From });
        builder.Entity<AntispamBlacklist>().HasKey(e => new { e.String });
    }

    public DbSet<RealmdDbVersion> RealmdDbVersions { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountBan> AccountBans { get; set; }
    public DbSet<AccountLogon> AccountLogons { get; set; }
    public DbSet<AccountRaf> AccountRafs { get; set; }
    public DbSet<IpBan> IpBans { get; set; }
    public DbSet<RealmCharacters> Realmcharacterss { get; set; }
    public DbSet<RealmList> Realmlists { get; set; }
    public DbSet<Uptime> Uptimes { get; set; }
    public DbSet<SystemFingerprintUsage> SystemFingerprintUsages { get; set; }
    public DbSet<AntispamReplacement> AntispamReplacements { get; set; }
    public DbSet<AntispamUnicodeReplacement> AntispamUnicodeReplacements { get; set; }
    public DbSet<AntispamBlacklist> AntispamBlacklists { get; set; }
}