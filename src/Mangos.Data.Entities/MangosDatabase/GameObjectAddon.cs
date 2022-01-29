using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("gameobject_addon")]
public class GameObjectAddon
{
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("path_rotation0", TypeName="float")]
    public virtual float PathRotation0 { get; set; }

    [Column("path_rotation1", TypeName="float")]
    public virtual float PathRotation1 { get; set; }

    [Column("path_rotation2", TypeName="float")]
    public virtual float PathRotation2 { get; set; }

    [Column("path_rotation3", TypeName="float")]
    public virtual float PathRotation3 { get; set; }

}