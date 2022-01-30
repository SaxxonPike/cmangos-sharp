using Mangos.Data.Entities.LogsDatabase;
using Microsoft.EntityFrameworkCore;

namespace Mangos.Data.Context;

public class LogsDbContext : DbContext
{
    public LogsDbContext()
    {
    }

    public LogsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<LogsDbVersion>().HasKey(e => new { e.RequiredZ277801LogsAnticheat });
        builder.Entity<LogsAnticheat>().HasKey(e => new { e.Id });
        builder.Entity<LogsSpamdetect>().HasKey(e => new { e.Id });
    }

    public DbSet<LogsDbVersion> LogsDbVersions { get; set; }
    public DbSet<LogsAnticheat> LogsAnticheats { get; set; }
    public DbSet<LogsSpamdetect> LogsSpamdetects { get; set; }
}