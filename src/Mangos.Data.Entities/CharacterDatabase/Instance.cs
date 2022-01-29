using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("instance")]
public class Instance
{
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("map", TypeName="int")]
    public virtual uint Map { get; set; }

    [Column("resettime", TypeName="bigint")]
    public virtual ulong Resettime { get; set; }

    [Column("encountersMask", TypeName="int")]
    public virtual uint EncountersMask { get; set; }

    [Column("data", TypeName="longtext")]
    public virtual string Data { get; set; }

}