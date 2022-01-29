using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("realmd_db_version")]
public class RealmdDbVersion
{
    [Column("required_z2778_01_realmd_anticheat", TypeName="bit")]
    public virtual bool RequiredZ277801RealmdAnticheat { get; set; }

}