using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("gossip_menu")]
public class GossipMenu
{
    [Column("condition_id", TypeName="mediumint")]
    public virtual uint ConditionId { get; set; }

    [Column("entry", TypeName="smallint")]
    public virtual ushort Entry { get; set; }

    /* script in `gossip_scripts` - will be executed on GossipHello */
    [Column("script_id", TypeName="mediumint")]
    public virtual uint ScriptId { get; set; }

    [Column("text_id", TypeName="mediumint")]
    public virtual uint TextId { get; set; }

}