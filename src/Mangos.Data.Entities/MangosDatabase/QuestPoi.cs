using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("quest_poi")]
public class QuestPoi
{
    [Column("questId", TypeName="mediumint")]
    public virtual uint QuestId { get; set; }

    [Column("poiId", TypeName="tinyint")]
    public virtual byte PoiId { get; set; }

    [Column("objIndex", TypeName="int")]
    public virtual int ObjIndex { get; set; }

    [Column("mapId", TypeName="int")]
    public virtual uint MapId { get; set; }

    [Column("mapAreaId", TypeName="mediumint")]
    public virtual uint MapAreaId { get; set; }

    [Column("floorId", TypeName="tinyint")]
    public virtual byte FloorId { get; set; }

    [Column("unk3", TypeName="int")]
    public virtual uint Unk3 { get; set; }

    [Column("unk4", TypeName="int")]
    public virtual uint Unk4 { get; set; }

}