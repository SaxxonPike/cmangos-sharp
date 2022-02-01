using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("world_template")]
public class WorldTemplate
{
    [Column("map", TypeName="smallint")]
    public virtual ushort Map { get; set; }

    [Column("ScriptName")]
    [MaxLength(128)]
    public virtual string ScriptName { get; set; }

}