using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("npc_text")]
public class NpcText
{
    [Column("ID", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    [Column("text0_0", TypeName="longtext")]
    public virtual string Text00 { get; set; }

    [Column("text0_1", TypeName="longtext")]
    public virtual string Text01 { get; set; }

    [Column("lang0", TypeName="tinyint")]
    public virtual byte Lang0 { get; set; }

    [Column("prob0", TypeName="float")]
    public virtual float Prob0 { get; set; }

    [Column("em0_0", TypeName="smallint")]
    public virtual uint Em00 { get; set; }

    [Column("em0_1", TypeName="smallint")]
    public virtual uint Em01 { get; set; }

    [Column("em0_2", TypeName="smallint")]
    public virtual uint Em02 { get; set; }

    [Column("em0_3", TypeName="smallint")]
    public virtual uint Em03 { get; set; }

    [Column("em0_4", TypeName="smallint")]
    public virtual uint Em04 { get; set; }

    [Column("em0_5", TypeName="smallint")]
    public virtual uint Em05 { get; set; }

    [Column("text1_0", TypeName="longtext")]
    public virtual string Text10 { get; set; }

    [Column("text1_1", TypeName="longtext")]
    public virtual string Text11 { get; set; }

    [Column("lang1", TypeName="tinyint")]
    public virtual byte Lang1 { get; set; }

    [Column("prob1", TypeName="float")]
    public virtual float Prob1 { get; set; }

    [Column("em1_0", TypeName="smallint")]
    public virtual uint Em10 { get; set; }

    [Column("em1_1", TypeName="smallint")]
    public virtual uint Em11 { get; set; }

    [Column("em1_2", TypeName="smallint")]
    public virtual uint Em12 { get; set; }

    [Column("em1_3", TypeName="smallint")]
    public virtual uint Em13 { get; set; }

    [Column("em1_4", TypeName="smallint")]
    public virtual uint Em14 { get; set; }

    [Column("em1_5", TypeName="smallint")]
    public virtual uint Em15 { get; set; }

    [Column("text2_0", TypeName="longtext")]
    public virtual string Text20 { get; set; }

    [Column("text2_1", TypeName="longtext")]
    public virtual string Text21 { get; set; }

    [Column("lang2", TypeName="tinyint")]
    public virtual byte Lang2 { get; set; }

    [Column("prob2", TypeName="float")]
    public virtual float Prob2 { get; set; }

    [Column("em2_0", TypeName="smallint")]
    public virtual uint Em20 { get; set; }

    [Column("em2_1", TypeName="smallint")]
    public virtual uint Em21 { get; set; }

    [Column("em2_2", TypeName="smallint")]
    public virtual uint Em22 { get; set; }

    [Column("em2_3", TypeName="smallint")]
    public virtual uint Em23 { get; set; }

    [Column("em2_4", TypeName="smallint")]
    public virtual uint Em24 { get; set; }

    [Column("em2_5", TypeName="smallint")]
    public virtual uint Em25 { get; set; }

    [Column("text3_0", TypeName="longtext")]
    public virtual string Text30 { get; set; }

    [Column("text3_1", TypeName="longtext")]
    public virtual string Text31 { get; set; }

    [Column("lang3", TypeName="tinyint")]
    public virtual byte Lang3 { get; set; }

    [Column("prob3", TypeName="float")]
    public virtual float Prob3 { get; set; }

    [Column("em3_0", TypeName="smallint")]
    public virtual uint Em30 { get; set; }

    [Column("em3_1", TypeName="smallint")]
    public virtual uint Em31 { get; set; }

    [Column("em3_2", TypeName="smallint")]
    public virtual uint Em32 { get; set; }

    [Column("em3_3", TypeName="smallint")]
    public virtual uint Em33 { get; set; }

    [Column("em3_4", TypeName="smallint")]
    public virtual uint Em34 { get; set; }

    [Column("em3_5", TypeName="smallint")]
    public virtual uint Em35 { get; set; }

    [Column("text4_0", TypeName="longtext")]
    public virtual string Text40 { get; set; }

    [Column("text4_1", TypeName="longtext")]
    public virtual string Text41 { get; set; }

    [Column("lang4", TypeName="tinyint")]
    public virtual byte Lang4 { get; set; }

    [Column("prob4", TypeName="float")]
    public virtual float Prob4 { get; set; }

    [Column("em4_0", TypeName="smallint")]
    public virtual uint Em40 { get; set; }

    [Column("em4_1", TypeName="smallint")]
    public virtual uint Em41 { get; set; }

    [Column("em4_2", TypeName="smallint")]
    public virtual uint Em42 { get; set; }

    [Column("em4_3", TypeName="smallint")]
    public virtual uint Em43 { get; set; }

    [Column("em4_4", TypeName="smallint")]
    public virtual uint Em44 { get; set; }

    [Column("em4_5", TypeName="smallint")]
    public virtual uint Em45 { get; set; }

    [Column("text5_0", TypeName="longtext")]
    public virtual string Text50 { get; set; }

    [Column("text5_1", TypeName="longtext")]
    public virtual string Text51 { get; set; }

    [Column("lang5", TypeName="tinyint")]
    public virtual byte Lang5 { get; set; }

    [Column("prob5", TypeName="float")]
    public virtual float Prob5 { get; set; }

    [Column("em5_0", TypeName="smallint")]
    public virtual uint Em50 { get; set; }

    [Column("em5_1", TypeName="smallint")]
    public virtual uint Em51 { get; set; }

    [Column("em5_2", TypeName="smallint")]
    public virtual uint Em52 { get; set; }

    [Column("em5_3", TypeName="smallint")]
    public virtual uint Em53 { get; set; }

    [Column("em5_4", TypeName="smallint")]
    public virtual uint Em54 { get; set; }

    [Column("em5_5", TypeName="smallint")]
    public virtual uint Em55 { get; set; }

    [Column("text6_0", TypeName="longtext")]
    public virtual string Text60 { get; set; }

    [Column("text6_1", TypeName="longtext")]
    public virtual string Text61 { get; set; }

    [Column("lang6", TypeName="tinyint")]
    public virtual byte Lang6 { get; set; }

    [Column("prob6", TypeName="float")]
    public virtual float Prob6 { get; set; }

    [Column("em6_0", TypeName="smallint")]
    public virtual uint Em60 { get; set; }

    [Column("em6_1", TypeName="smallint")]
    public virtual uint Em61 { get; set; }

    [Column("em6_2", TypeName="smallint")]
    public virtual uint Em62 { get; set; }

    [Column("em6_3", TypeName="smallint")]
    public virtual uint Em63 { get; set; }

    [Column("em6_4", TypeName="smallint")]
    public virtual uint Em64 { get; set; }

    [Column("em6_5", TypeName="smallint")]
    public virtual uint Em65 { get; set; }

    [Column("text7_0", TypeName="longtext")]
    public virtual string Text70 { get; set; }

    [Column("text7_1", TypeName="longtext")]
    public virtual string Text71 { get; set; }

    [Column("lang7", TypeName="tinyint")]
    public virtual byte Lang7 { get; set; }

    [Column("prob7", TypeName="float")]
    public virtual float Prob7 { get; set; }

    [Column("em7_0", TypeName="smallint")]
    public virtual uint Em70 { get; set; }

    [Column("em7_1", TypeName="smallint")]
    public virtual uint Em71 { get; set; }

    [Column("em7_2", TypeName="smallint")]
    public virtual uint Em72 { get; set; }

    [Column("em7_3", TypeName="smallint")]
    public virtual uint Em73 { get; set; }

    [Column("em7_4", TypeName="smallint")]
    public virtual uint Em74 { get; set; }

    [Column("em7_5", TypeName="smallint")]
    public virtual uint Em75 { get; set; }

}