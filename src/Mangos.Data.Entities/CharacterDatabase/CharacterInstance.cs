using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_instance")]
public class CharacterInstance
{
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("instance", TypeName="int")]
    public virtual uint Instance { get; set; }

    [Column("permanent", TypeName="tinyint")]
    public virtual byte Permanent { get; set; }

}