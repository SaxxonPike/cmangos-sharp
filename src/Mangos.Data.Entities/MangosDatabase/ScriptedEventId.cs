using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("scripted_event_id")]
public class ScriptedEventId
{
    [Column("id", TypeName="mediumint")]
    public virtual int Id { get; set; }

    [Column("ScriptName", TypeName="char")]
    [MaxLength(64)]
    public virtual string ScriptName { get; set; }

}