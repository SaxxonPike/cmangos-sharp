using Mangos.Data.Entities.LogsDatabase;
using Microsoft.EntityFrameworkCore;

namespace Mangos.Data.Context;

public class ClassiclogsDbContext : DbContext
{
    public ClassiclogsDbContext() {}
    public ClassiclogsDbContext(DbContextOptions options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<LogsAnticheat>().HasKey(e => new { e.Id });
        builder.Entity<LogsSpamdetect>().HasKey(e => new { e.Id });
    }

    public virtual DbSet<LogsAnticheat> LogsAnticheats { get; set; }
    public virtual DbSet<LogsSpamdetect> LogsSpamdetects { get; set; }
}