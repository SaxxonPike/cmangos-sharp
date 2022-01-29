using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("npc_gossip")]
public class NpcGossip
{
    [Column("npc_guid", TypeName="int")]
    public virtual uint NpcGuid { get; set; }

    [Column("textid", TypeName="mediumint")]
    public virtual uint Textid { get; set; }

}