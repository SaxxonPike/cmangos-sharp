using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("locales_npc_text")]
public class LocalesNpcText
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("Text0_0_loc1", TypeName="longtext")]
    public virtual string Text00Loc1 { get; set; }

    [Column("Text0_0_loc2", TypeName="longtext")]
    public virtual string Text00Loc2 { get; set; }

    [Column("Text0_0_loc3", TypeName="longtext")]
    public virtual string Text00Loc3 { get; set; }

    [Column("Text0_0_loc4", TypeName="longtext")]
    public virtual string Text00Loc4 { get; set; }

    [Column("Text0_0_loc5", TypeName="longtext")]
    public virtual string Text00Loc5 { get; set; }

    [Column("Text0_0_loc6", TypeName="longtext")]
    public virtual string Text00Loc6 { get; set; }

    [Column("Text0_0_loc7", TypeName="longtext")]
    public virtual string Text00Loc7 { get; set; }

    [Column("Text0_0_loc8", TypeName="longtext")]
    public virtual string Text00Loc8 { get; set; }

    [Column("Text0_1_loc1", TypeName="longtext")]
    public virtual string Text01Loc1 { get; set; }

    [Column("Text0_1_loc2", TypeName="longtext")]
    public virtual string Text01Loc2 { get; set; }

    [Column("Text0_1_loc3", TypeName="longtext")]
    public virtual string Text01Loc3 { get; set; }

    [Column("Text0_1_loc4", TypeName="longtext")]
    public virtual string Text01Loc4 { get; set; }

    [Column("Text0_1_loc5", TypeName="longtext")]
    public virtual string Text01Loc5 { get; set; }

    [Column("Text0_1_loc6", TypeName="longtext")]
    public virtual string Text01Loc6 { get; set; }

    [Column("Text0_1_loc7", TypeName="longtext")]
    public virtual string Text01Loc7 { get; set; }

    [Column("Text0_1_loc8", TypeName="longtext")]
    public virtual string Text01Loc8 { get; set; }

    [Column("Text1_0_loc1", TypeName="longtext")]
    public virtual string Text10Loc1 { get; set; }

    [Column("Text1_0_loc2", TypeName="longtext")]
    public virtual string Text10Loc2 { get; set; }

    [Column("Text1_0_loc3", TypeName="longtext")]
    public virtual string Text10Loc3 { get; set; }

    [Column("Text1_0_loc4", TypeName="longtext")]
    public virtual string Text10Loc4 { get; set; }

    [Column("Text1_0_loc5", TypeName="longtext")]
    public virtual string Text10Loc5 { get; set; }

    [Column("Text1_0_loc6", TypeName="longtext")]
    public virtual string Text10Loc6 { get; set; }

    [Column("Text1_0_loc7", TypeName="longtext")]
    public virtual string Text10Loc7 { get; set; }

    [Column("Text1_0_loc8", TypeName="longtext")]
    public virtual string Text10Loc8 { get; set; }

    [Column("Text1_1_loc1", TypeName="longtext")]
    public virtual string Text11Loc1 { get; set; }

    [Column("Text1_1_loc2", TypeName="longtext")]
    public virtual string Text11Loc2 { get; set; }

    [Column("Text1_1_loc3", TypeName="longtext")]
    public virtual string Text11Loc3 { get; set; }

    [Column("Text1_1_loc4", TypeName="longtext")]
    public virtual string Text11Loc4 { get; set; }

    [Column("Text1_1_loc5", TypeName="longtext")]
    public virtual string Text11Loc5 { get; set; }

    [Column("Text1_1_loc6", TypeName="longtext")]
    public virtual string Text11Loc6 { get; set; }

    [Column("Text1_1_loc7", TypeName="longtext")]
    public virtual string Text11Loc7 { get; set; }

    [Column("Text1_1_loc8", TypeName="longtext")]
    public virtual string Text11Loc8 { get; set; }

    [Column("Text2_0_loc1", TypeName="longtext")]
    public virtual string Text20Loc1 { get; set; }

    [Column("Text2_0_loc2", TypeName="longtext")]
    public virtual string Text20Loc2 { get; set; }

    [Column("Text2_0_loc3", TypeName="longtext")]
    public virtual string Text20Loc3 { get; set; }

    [Column("Text2_0_loc4", TypeName="longtext")]
    public virtual string Text20Loc4 { get; set; }

    [Column("Text2_0_loc5", TypeName="longtext")]
    public virtual string Text20Loc5 { get; set; }

    [Column("Text2_0_loc6", TypeName="longtext")]
    public virtual string Text20Loc6 { get; set; }

    [Column("Text2_0_loc7", TypeName="longtext")]
    public virtual string Text20Loc7 { get; set; }

    [Column("Text2_0_loc8", TypeName="longtext")]
    public virtual string Text20Loc8 { get; set; }

    [Column("Text2_1_loc1", TypeName="longtext")]
    public virtual string Text21Loc1 { get; set; }

    [Column("Text2_1_loc2", TypeName="longtext")]
    public virtual string Text21Loc2 { get; set; }

    [Column("Text2_1_loc3", TypeName="longtext")]
    public virtual string Text21Loc3 { get; set; }

    [Column("Text2_1_loc4", TypeName="longtext")]
    public virtual string Text21Loc4 { get; set; }

    [Column("Text2_1_loc5", TypeName="longtext")]
    public virtual string Text21Loc5 { get; set; }

    [Column("Text2_1_loc6", TypeName="longtext")]
    public virtual string Text21Loc6 { get; set; }

    [Column("Text2_1_loc7", TypeName="longtext")]
    public virtual string Text21Loc7 { get; set; }

    [Column("Text2_1_loc8", TypeName="longtext")]
    public virtual string Text21Loc8 { get; set; }

    [Column("Text3_0_loc1", TypeName="longtext")]
    public virtual string Text30Loc1 { get; set; }

    [Column("Text3_0_loc2", TypeName="longtext")]
    public virtual string Text30Loc2 { get; set; }

    [Column("Text3_0_loc3", TypeName="longtext")]
    public virtual string Text30Loc3 { get; set; }

    [Column("Text3_0_loc4", TypeName="longtext")]
    public virtual string Text30Loc4 { get; set; }

    [Column("Text3_0_loc5", TypeName="longtext")]
    public virtual string Text30Loc5 { get; set; }

    [Column("Text3_0_loc6", TypeName="longtext")]
    public virtual string Text30Loc6 { get; set; }

    [Column("Text3_0_loc7", TypeName="longtext")]
    public virtual string Text30Loc7 { get; set; }

    [Column("Text3_0_loc8", TypeName="longtext")]
    public virtual string Text30Loc8 { get; set; }

    [Column("Text3_1_loc1", TypeName="longtext")]
    public virtual string Text31Loc1 { get; set; }

    [Column("Text3_1_loc2", TypeName="longtext")]
    public virtual string Text31Loc2 { get; set; }

    [Column("Text3_1_loc3", TypeName="longtext")]
    public virtual string Text31Loc3 { get; set; }

    [Column("Text3_1_loc4", TypeName="longtext")]
    public virtual string Text31Loc4 { get; set; }

    [Column("Text3_1_loc5", TypeName="longtext")]
    public virtual string Text31Loc5 { get; set; }

    [Column("Text3_1_loc6", TypeName="longtext")]
    public virtual string Text31Loc6 { get; set; }

    [Column("Text3_1_loc7", TypeName="longtext")]
    public virtual string Text31Loc7 { get; set; }

    [Column("Text3_1_loc8", TypeName="longtext")]
    public virtual string Text31Loc8 { get; set; }

    [Column("Text4_0_loc1", TypeName="longtext")]
    public virtual string Text40Loc1 { get; set; }

    [Column("Text4_0_loc2", TypeName="longtext")]
    public virtual string Text40Loc2 { get; set; }

    [Column("Text4_0_loc3", TypeName="longtext")]
    public virtual string Text40Loc3 { get; set; }

    [Column("Text4_0_loc4", TypeName="longtext")]
    public virtual string Text40Loc4 { get; set; }

    [Column("Text4_0_loc5", TypeName="longtext")]
    public virtual string Text40Loc5 { get; set; }

    [Column("Text4_0_loc6", TypeName="longtext")]
    public virtual string Text40Loc6 { get; set; }

    [Column("Text4_0_loc7", TypeName="longtext")]
    public virtual string Text40Loc7 { get; set; }

    [Column("Text4_0_loc8", TypeName="longtext")]
    public virtual string Text40Loc8 { get; set; }

    [Column("Text4_1_loc1", TypeName="longtext")]
    public virtual string Text41Loc1 { get; set; }

    [Column("Text4_1_loc2", TypeName="longtext")]
    public virtual string Text41Loc2 { get; set; }

    [Column("Text4_1_loc3", TypeName="longtext")]
    public virtual string Text41Loc3 { get; set; }

    [Column("Text4_1_loc4", TypeName="longtext")]
    public virtual string Text41Loc4 { get; set; }

    [Column("Text4_1_loc5", TypeName="longtext")]
    public virtual string Text41Loc5 { get; set; }

    [Column("Text4_1_loc6", TypeName="longtext")]
    public virtual string Text41Loc6 { get; set; }

    [Column("Text4_1_loc7", TypeName="longtext")]
    public virtual string Text41Loc7 { get; set; }

    [Column("Text4_1_loc8", TypeName="longtext")]
    public virtual string Text41Loc8 { get; set; }

    [Column("Text5_0_loc1", TypeName="longtext")]
    public virtual string Text50Loc1 { get; set; }

    [Column("Text5_0_loc2", TypeName="longtext")]
    public virtual string Text50Loc2 { get; set; }

    [Column("Text5_0_loc3", TypeName="longtext")]
    public virtual string Text50Loc3 { get; set; }

    [Column("Text5_0_loc4", TypeName="longtext")]
    public virtual string Text50Loc4 { get; set; }

    [Column("Text5_0_loc5", TypeName="longtext")]
    public virtual string Text50Loc5 { get; set; }

    [Column("Text5_0_loc6", TypeName="longtext")]
    public virtual string Text50Loc6 { get; set; }

    [Column("Text5_0_loc7", TypeName="longtext")]
    public virtual string Text50Loc7 { get; set; }

    [Column("Text5_0_loc8", TypeName="longtext")]
    public virtual string Text50Loc8 { get; set; }

    [Column("Text5_1_loc1", TypeName="longtext")]
    public virtual string Text51Loc1 { get; set; }

    [Column("Text5_1_loc2", TypeName="longtext")]
    public virtual string Text51Loc2 { get; set; }

    [Column("Text5_1_loc3", TypeName="longtext")]
    public virtual string Text51Loc3 { get; set; }

    [Column("Text5_1_loc4", TypeName="longtext")]
    public virtual string Text51Loc4 { get; set; }

    [Column("Text5_1_loc5", TypeName="longtext")]
    public virtual string Text51Loc5 { get; set; }

    [Column("Text5_1_loc6", TypeName="longtext")]
    public virtual string Text51Loc6 { get; set; }

    [Column("Text5_1_loc7", TypeName="longtext")]
    public virtual string Text51Loc7 { get; set; }

    [Column("Text5_1_loc8", TypeName="longtext")]
    public virtual string Text51Loc8 { get; set; }

    [Column("Text6_0_loc1", TypeName="longtext")]
    public virtual string Text60Loc1 { get; set; }

    [Column("Text6_0_loc2", TypeName="longtext")]
    public virtual string Text60Loc2 { get; set; }

    [Column("Text6_0_loc3", TypeName="longtext")]
    public virtual string Text60Loc3 { get; set; }

    [Column("Text6_0_loc4", TypeName="longtext")]
    public virtual string Text60Loc4 { get; set; }

    [Column("Text6_0_loc5", TypeName="longtext")]
    public virtual string Text60Loc5 { get; set; }

    [Column("Text6_0_loc6", TypeName="longtext")]
    public virtual string Text60Loc6 { get; set; }

    [Column("Text6_0_loc7", TypeName="longtext")]
    public virtual string Text60Loc7 { get; set; }

    [Column("Text6_0_loc8", TypeName="longtext")]
    public virtual string Text60Loc8 { get; set; }

    [Column("Text6_1_loc1", TypeName="longtext")]
    public virtual string Text61Loc1 { get; set; }

    [Column("Text6_1_loc2", TypeName="longtext")]
    public virtual string Text61Loc2 { get; set; }

    [Column("Text6_1_loc3", TypeName="longtext")]
    public virtual string Text61Loc3 { get; set; }

    [Column("Text6_1_loc4", TypeName="longtext")]
    public virtual string Text61Loc4 { get; set; }

    [Column("Text6_1_loc5", TypeName="longtext")]
    public virtual string Text61Loc5 { get; set; }

    [Column("Text6_1_loc6", TypeName="longtext")]
    public virtual string Text61Loc6 { get; set; }

    [Column("Text6_1_loc7", TypeName="longtext")]
    public virtual string Text61Loc7 { get; set; }

    [Column("Text6_1_loc8", TypeName="longtext")]
    public virtual string Text61Loc8 { get; set; }

    [Column("Text7_0_loc1", TypeName="longtext")]
    public virtual string Text70Loc1 { get; set; }

    [Column("Text7_0_loc2", TypeName="longtext")]
    public virtual string Text70Loc2 { get; set; }

    [Column("Text7_0_loc3", TypeName="longtext")]
    public virtual string Text70Loc3 { get; set; }

    [Column("Text7_0_loc4", TypeName="longtext")]
    public virtual string Text70Loc4 { get; set; }

    [Column("Text7_0_loc5", TypeName="longtext")]
    public virtual string Text70Loc5 { get; set; }

    [Column("Text7_0_loc6", TypeName="longtext")]
    public virtual string Text70Loc6 { get; set; }

    [Column("Text7_0_loc7", TypeName="longtext")]
    public virtual string Text70Loc7 { get; set; }

    [Column("Text7_0_loc8", TypeName="longtext")]
    public virtual string Text70Loc8 { get; set; }

    [Column("Text7_1_loc1", TypeName="longtext")]
    public virtual string Text71Loc1 { get; set; }

    [Column("Text7_1_loc2", TypeName="longtext")]
    public virtual string Text71Loc2 { get; set; }

    [Column("Text7_1_loc3", TypeName="longtext")]
    public virtual string Text71Loc3 { get; set; }

    [Column("Text7_1_loc4", TypeName="longtext")]
    public virtual string Text71Loc4 { get; set; }

    [Column("Text7_1_loc5", TypeName="longtext")]
    public virtual string Text71Loc5 { get; set; }

    [Column("Text7_1_loc6", TypeName="longtext")]
    public virtual string Text71Loc6 { get; set; }

    [Column("Text7_1_loc7", TypeName="longtext")]
    public virtual string Text71Loc7 { get; set; }

    [Column("Text7_1_loc8", TypeName="longtext")]
    public virtual string Text71Loc8 { get; set; }

}