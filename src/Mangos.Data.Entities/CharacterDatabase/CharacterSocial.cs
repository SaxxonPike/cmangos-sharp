using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_social")]
public class CharacterSocial
{
    /* Character Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Friend Global Unique Identifier */
    [Column("friend", TypeName="int")]
    public virtual uint Friend { get; set; }

    /* Friend Flags */
    [Column("flags", TypeName="tinyint")]
    public virtual byte Flags { get; set; }

}