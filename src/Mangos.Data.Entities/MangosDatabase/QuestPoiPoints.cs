using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("quest_poi_points")]
public class QuestPoiPoints
{
    [Column("questId", TypeName="mediumint")]
    public virtual uint QuestId { get; set; }

    [Column("poiId", TypeName="tinyint")]
    public virtual byte PoiId { get; set; }

    [Column("x", TypeName="int")]
    public virtual int X { get; set; }

    [Column("y", TypeName="int")]
    public virtual int Y { get; set; }

}