using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("guild_eventlog")]
public class GuildEventLog
{
    /* Guild Identificator */
    [Column("guildid", TypeName="int")]
    public virtual uint Guildid { get; set; }

    /* Log record identificator - auxiliary column */
    [Column("LogGuid", TypeName="int")]
    public virtual uint LogGuid { get; set; }

    /* Event type */
    [Column("EventType", TypeName="tinyint")]
    public virtual byte EventType { get; set; }

    /* Player 1 */
    [Column("PlayerGuid1", TypeName="int")]
    public virtual uint PlayerGuid1 { get; set; }

    /* Player 2 */
    [Column("PlayerGuid2", TypeName="int")]
    public virtual uint PlayerGuid2 { get; set; }

    /* New rank(in case promotion/demotion) */
    [Column("NewRank", TypeName="tinyint")]
    public virtual byte NewRank { get; set; }

    /* Event UNIX time */
    [Column("TimeStamp", TypeName="bigint")]
    public virtual ulong TimeStamp { get; set; }

}