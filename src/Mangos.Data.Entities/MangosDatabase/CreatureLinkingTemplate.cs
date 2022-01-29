using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_linking_template")]
public class CreatureLinkingTemplate
{
    /* creature_template.entry of the slave mob that is linked */
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    /* Id of map of the mobs */
    [Column("map", TypeName="smallint")]
    public virtual uint Map { get; set; }

    /* master to trigger events */
    [Column("master_entry", TypeName="mediumint")]
    public virtual uint MasterEntry { get; set; }

    /* flag - describing what should happen when */
    [Column("flag", TypeName="mediumint")]
    public virtual uint Flag { get; set; }

    [Column("search_range", TypeName="mediumint")]
    public virtual uint SearchRange { get; set; }

}