using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("saved_variables")]
public class SavedVariable
{
    [Column("NextWeeklyQuestResetTime", TypeName="bigint")]
    public virtual ulong NextWeeklyQuestResetTime { get; set; }

    [Column("NextMaintenanceDate", TypeName="int")]
    public virtual uint NextMaintenanceDate { get; set; }

    [Column("cleaning_flags", TypeName="int")]
    public virtual uint CleaningFlags { get; set; }

}