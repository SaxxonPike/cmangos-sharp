using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_db_version")]
public class CharacterDbVersion
{
    [Column("required_z2775_01_characters_raf", TypeName="bit")]
    public virtual bool RequiredZ277501CharactersRaf { get; set; }

}