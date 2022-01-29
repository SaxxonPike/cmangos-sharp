using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("world_template")]
public class WorldTemplate
{
    [Column("map", TypeName="smallint")]
    public virtual uint Map { get; set; }

    [Column("ScriptName", TypeName="varchar")]
    [MaxLength(128)]
    public virtual string ScriptName { get; set; }

}