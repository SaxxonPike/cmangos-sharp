using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("npc_text_broadcast_text")]
public class NpcTextBroadcastText
{
    /* Identifier */
    [Column("Id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    [Column("Prob0", TypeName="float")]
    public virtual float Prob0 { get; set; }

    [Column("Prob1", TypeName="float")]
    public virtual float Prob1 { get; set; }

    [Column("Prob2", TypeName="float")]
    public virtual float Prob2 { get; set; }

    [Column("Prob3", TypeName="float")]
    public virtual float Prob3 { get; set; }

    [Column("Prob4", TypeName="float")]
    public virtual float Prob4 { get; set; }

    [Column("Prob5", TypeName="float")]
    public virtual float Prob5 { get; set; }

    [Column("Prob6", TypeName="float")]
    public virtual float Prob6 { get; set; }

    [Column("Prob7", TypeName="float")]
    public virtual float Prob7 { get; set; }

    [Column("BroadcastTextId0", TypeName="int")]
    public virtual int BroadcastTextId0 { get; set; }

    [Column("BroadcastTextId1", TypeName="int")]
    public virtual int BroadcastTextId1 { get; set; }

    [Column("BroadcastTextId2", TypeName="int")]
    public virtual int BroadcastTextId2 { get; set; }

    [Column("BroadcastTextId3", TypeName="int")]
    public virtual int BroadcastTextId3 { get; set; }

    [Column("BroadcastTextId4", TypeName="int")]
    public virtual int BroadcastTextId4 { get; set; }

    [Column("BroadcastTextId5", TypeName="int")]
    public virtual int BroadcastTextId5 { get; set; }

    [Column("BroadcastTextId6", TypeName="int")]
    public virtual int BroadcastTextId6 { get; set; }

    [Column("BroadcastTextId7", TypeName="int")]
    public virtual int BroadcastTextId7 { get; set; }

}