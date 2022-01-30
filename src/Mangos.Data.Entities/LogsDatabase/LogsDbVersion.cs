using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.LogsDatabase;

[Table("logs_db_version")]
public class LogsDbVersion
{
    [Column("required_z2778_01_logs_anticheat", TypeName="bit")]
    public virtual bool RequiredZ277801LogsAnticheat { get; set; }

}