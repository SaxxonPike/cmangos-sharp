using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("instance_reset")]
public class InstanceReset
{
    [Column("mapid", TypeName="int")]
    public virtual uint Mapid { get; set; }

    [Column("resettime", TypeName="bigint")]
    public virtual ulong Resettime { get; set; }

}