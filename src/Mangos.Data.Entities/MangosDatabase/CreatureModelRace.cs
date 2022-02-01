using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_model_race")]
public class CreatureModelRace
{
    /* option 1, modelid_N from creature_template */
    [Column("creature_entry", TypeName="mediumint")]
    public virtual uint CreatureEntry { get; set; }

    [Column("modelid", TypeName="mediumint")]
    public virtual uint Modelid { get; set; }

    /* option 2, explicit modelid */
    [Column("modelid_racial", TypeName="mediumint")]
    public virtual uint ModelidRacial { get; set; }

    [Column("racemask", TypeName="mediumint")]
    public virtual uint Racemask { get; set; }

}