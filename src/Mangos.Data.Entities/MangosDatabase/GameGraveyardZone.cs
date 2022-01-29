using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("game_graveyard_zone")]
public class GameGraveyardZone
{
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    [Column("ghost_loc", TypeName="mediumint")]
    public virtual uint GhostLoc { get; set; }

    [Column("link_kind", TypeName="tinyint")]
    public virtual byte LinkKind { get; set; }

    [Column("faction", TypeName="smallint")]
    public virtual uint Faction { get; set; }

}