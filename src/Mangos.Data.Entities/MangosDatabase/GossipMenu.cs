using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("gossip_menu")]
public class GossipMenu
{
    [Column("entry", TypeName="smallint")]
    public virtual uint Entry { get; set; }

    [Column("text_id", TypeName="mediumint")]
    public virtual uint TextId { get; set; }

    /* script in `gossip_scripts` - will be executed on GossipHello */
    [Column("script_id", TypeName="mediumint")]
    public virtual uint ScriptId { get; set; }

    [Column("condition_id", TypeName="mediumint")]
    public virtual uint ConditionId { get; set; }

}