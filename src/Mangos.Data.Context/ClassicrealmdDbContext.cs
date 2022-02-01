using Mangos.Data.Entities.RealmDatabase;
using Microsoft.EntityFrameworkCore;

namespace Mangos.Data.Context;

public class ClassicrealmdDbContext : DbContext
{
    public ClassicrealmdDbContext() {}
    public ClassicrealmdDbContext(DbContextOptions options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Account>().HasKey(e => new { e.Id });
        builder.Entity<AccountBanned>().HasKey(e => new { e.Id });
        builder.Entity<AccountLogons>().HasKey(e => new { e.Id });
        builder.Entity<AccountRaf>().HasKey(e => new { e.Referred, e.Referrer });
        builder.Entity<AntispamBlacklist>().HasKey(e => new { e.String });
        builder.Entity<AntispamReplacement>().HasKey(e => new { e.From });
        builder.Entity<AntispamUnicodeReplacement>().HasKey(e => new { e.From });
        builder.Entity<IpBanned>().HasKey(e => new { e.BannedAt, e.Ip });
        builder.Entity<Realmcharacters>().HasKey(e => new { e.Acctid, e.Realmid });
        builder.Entity<Realmlist>().HasKey(e => new { e.Id });
        builder.Entity<SystemFingerprintUsage>().HasKey(e => new { e.Id });
        builder.Entity<Uptime>().HasKey(e => new { e.Maxplayers, e.Realmid, e.Starttime });
    }

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<AccountBanned> AccountBanneds { get; set; }
    public virtual DbSet<AccountLogons> AccountLogonss { get; set; }
    public virtual DbSet<AccountRaf> AccountRafs { get; set; }
    public virtual DbSet<AntispamBlacklist> AntispamBlacklists { get; set; }
    public virtual DbSet<AntispamReplacement> AntispamReplacements { get; set; }
    public virtual DbSet<AntispamUnicodeReplacement> AntispamUnicodeReplacements { get; set; }
    public virtual DbSet<IpBanned> IpBanneds { get; set; }
    public virtual DbSet<Realmcharacters> Realmcharacterss { get; set; }
    public virtual DbSet<Realmlist> Realmlists { get; set; }
    public virtual DbSet<SystemFingerprintUsage> SystemFingerprintUsages { get; set; }
    public virtual DbSet<Uptime> Uptimes { get; set; }
}