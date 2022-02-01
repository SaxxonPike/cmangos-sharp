using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_linking")]
public class CreatureLinking
{
    /* flag - describing what should happen when */
    [Column("flag", TypeName="mediumint")]
    public virtual uint Flag { get; set; }

    /* creature.guid of the slave mob that is linked */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* master to trigger events */
    [Column("master_guid", TypeName="int")]
    public virtual uint MasterGuid { get; set; }

}