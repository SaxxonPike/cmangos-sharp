using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_battleground_data")]
public class CharacterBattlegroundData
{
    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("instance_id", TypeName="int")]
    public virtual uint InstanceId { get; set; }

    [Column("join_map", TypeName="int")]
    public virtual int JoinMap { get; set; }

    [Column("join_o", TypeName="float")]
    public virtual float JoinO { get; set; }

    [Column("join_x", TypeName="float")]
    public virtual float JoinX { get; set; }

    [Column("join_y", TypeName="float")]
    public virtual float JoinY { get; set; }

    [Column("join_z", TypeName="float")]
    public virtual float JoinZ { get; set; }

    [Column("team", TypeName="int")]
    public virtual uint Team { get; set; }

}