using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("scripted_areatrigger")]
public class ScriptedAreaTrigger
{
    [Column("entry", TypeName="mediumint")]
    public virtual int Entry { get; set; }

    [Column("ScriptName", TypeName="char")]
    [MaxLength(64)]
    public virtual string ScriptName { get; set; }

}