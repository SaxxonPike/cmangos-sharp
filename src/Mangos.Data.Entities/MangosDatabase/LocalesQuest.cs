using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("locales_quest")]
public class LocalesQuest
{
    [Column("Details_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string DetailsLoc1 { get; set; }

    [Column("Details_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string DetailsLoc2 { get; set; }

    [Column("Details_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string DetailsLoc3 { get; set; }

    [Column("Details_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string DetailsLoc4 { get; set; }

    [Column("Details_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string DetailsLoc5 { get; set; }

    [Column("Details_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string DetailsLoc6 { get; set; }

    [Column("Details_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string DetailsLoc7 { get; set; }

    [Column("Details_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string DetailsLoc8 { get; set; }

    [Column("EndText_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EndTextLoc1 { get; set; }

    [Column("EndText_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EndTextLoc2 { get; set; }

    [Column("EndText_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EndTextLoc3 { get; set; }

    [Column("EndText_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EndTextLoc4 { get; set; }

    [Column("EndText_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EndTextLoc5 { get; set; }

    [Column("EndText_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EndTextLoc6 { get; set; }

    [Column("EndText_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EndTextLoc7 { get; set; }

    [Column("EndText_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EndTextLoc8 { get; set; }

    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("Objectives_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectivesLoc1 { get; set; }

    [Column("Objectives_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectivesLoc2 { get; set; }

    [Column("Objectives_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectivesLoc3 { get; set; }

    [Column("Objectives_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectivesLoc4 { get; set; }

    [Column("Objectives_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectivesLoc5 { get; set; }

    [Column("Objectives_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectivesLoc6 { get; set; }

    [Column("Objectives_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectivesLoc7 { get; set; }

    [Column("Objectives_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectivesLoc8 { get; set; }

    [Column("ObjectiveText1_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText1Loc1 { get; set; }

    [Column("ObjectiveText1_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText1Loc2 { get; set; }

    [Column("ObjectiveText1_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText1Loc3 { get; set; }

    [Column("ObjectiveText1_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText1Loc4 { get; set; }

    [Column("ObjectiveText1_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText1Loc5 { get; set; }

    [Column("ObjectiveText1_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText1Loc6 { get; set; }

    [Column("ObjectiveText1_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText1Loc7 { get; set; }

    [Column("ObjectiveText1_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText1Loc8 { get; set; }

    [Column("ObjectiveText2_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText2Loc1 { get; set; }

    [Column("ObjectiveText2_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText2Loc2 { get; set; }

    [Column("ObjectiveText2_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText2Loc3 { get; set; }

    [Column("ObjectiveText2_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText2Loc4 { get; set; }

    [Column("ObjectiveText2_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText2Loc5 { get; set; }

    [Column("ObjectiveText2_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText2Loc6 { get; set; }

    [Column("ObjectiveText2_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText2Loc7 { get; set; }

    [Column("ObjectiveText2_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText2Loc8 { get; set; }

    [Column("ObjectiveText3_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText3Loc1 { get; set; }

    [Column("ObjectiveText3_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText3Loc2 { get; set; }

    [Column("ObjectiveText3_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText3Loc3 { get; set; }

    [Column("ObjectiveText3_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText3Loc4 { get; set; }

    [Column("ObjectiveText3_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText3Loc5 { get; set; }

    [Column("ObjectiveText3_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText3Loc6 { get; set; }

    [Column("ObjectiveText3_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText3Loc7 { get; set; }

    [Column("ObjectiveText3_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText3Loc8 { get; set; }

    [Column("ObjectiveText4_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText4Loc1 { get; set; }

    [Column("ObjectiveText4_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText4Loc2 { get; set; }

    [Column("ObjectiveText4_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText4Loc3 { get; set; }

    [Column("ObjectiveText4_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText4Loc4 { get; set; }

    [Column("ObjectiveText4_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText4Loc5 { get; set; }

    [Column("ObjectiveText4_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText4Loc6 { get; set; }

    [Column("ObjectiveText4_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText4Loc7 { get; set; }

    [Column("ObjectiveText4_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText4Loc8 { get; set; }

    [Column("OfferRewardText_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OfferRewardTextLoc1 { get; set; }

    [Column("OfferRewardText_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OfferRewardTextLoc2 { get; set; }

    [Column("OfferRewardText_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OfferRewardTextLoc3 { get; set; }

    [Column("OfferRewardText_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OfferRewardTextLoc4 { get; set; }

    [Column("OfferRewardText_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OfferRewardTextLoc5 { get; set; }

    [Column("OfferRewardText_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OfferRewardTextLoc6 { get; set; }

    [Column("OfferRewardText_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OfferRewardTextLoc7 { get; set; }

    [Column("OfferRewardText_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OfferRewardTextLoc8 { get; set; }

    [Column("RequestItemsText_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string RequestItemsTextLoc1 { get; set; }

    [Column("RequestItemsText_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string RequestItemsTextLoc2 { get; set; }

    [Column("RequestItemsText_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string RequestItemsTextLoc3 { get; set; }

    [Column("RequestItemsText_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string RequestItemsTextLoc4 { get; set; }

    [Column("RequestItemsText_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string RequestItemsTextLoc5 { get; set; }

    [Column("RequestItemsText_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string RequestItemsTextLoc6 { get; set; }

    [Column("RequestItemsText_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string RequestItemsTextLoc7 { get; set; }

    [Column("RequestItemsText_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string RequestItemsTextLoc8 { get; set; }

    [Column("Title_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string TitleLoc1 { get; set; }

    [Column("Title_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string TitleLoc2 { get; set; }

    [Column("Title_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string TitleLoc3 { get; set; }

    [Column("Title_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string TitleLoc4 { get; set; }

    [Column("Title_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string TitleLoc5 { get; set; }

    [Column("Title_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string TitleLoc6 { get; set; }

    [Column("Title_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string TitleLoc7 { get; set; }

    [Column("Title_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string TitleLoc8 { get; set; }

}