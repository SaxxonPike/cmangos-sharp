using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spawn_group_formation")]
public class SpawnGroupFormation
{
    [Column("Id", TypeName="int")]
    public virtual int Id { get; set; }

    /* Formation shape 0..6 */
    [Column("FormationType", TypeName="tinyint")]
    public virtual int FormationType { get; set; }

    /* Distance between formation members */
    [Column("FormationSpread", TypeName="float")]
    public virtual float FormationSpread { get; set; }

    /* Keep formation compact (bit 1) */
    [Column("FormationOptions", TypeName="int")]
    public virtual int FormationOptions { get; set; }

    [Column("PathId", TypeName="int")]
    public virtual int PathId { get; set; }

    /* Same as creature table */
    [Column("MovementType", TypeName="tinyint")]
    public virtual int MovementType { get; set; }

    [Column("Comment", TypeName="varchar")]
    [MaxLength(255)]
    public virtual string Comment { get; set; }

}