using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("quest_template")]
public class QuestTemplate
{
    [Column("CompleteEmote", TypeName="smallint")]
    public virtual ushort CompleteEmote { get; set; }

    [Column("CompleteEmoteDelay", TypeName="int")]
    public virtual uint CompleteEmoteDelay { get; set; }

    [Column("CompleteScript", TypeName="mediumint")]
    public virtual uint CompleteScript { get; set; }

    [Column("Details", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Details { get; set; }

    [Column("DetailsEmote1", TypeName="smallint")]
    public virtual ushort DetailsEmote1 { get; set; }

    [Column("DetailsEmote2", TypeName="smallint")]
    public virtual ushort DetailsEmote2 { get; set; }

    [Column("DetailsEmote3", TypeName="smallint")]
    public virtual ushort DetailsEmote3 { get; set; }

    [Column("DetailsEmote4", TypeName="smallint")]
    public virtual ushort DetailsEmote4 { get; set; }

    [Column("DetailsEmoteDelay1", TypeName="int")]
    public virtual uint DetailsEmoteDelay1 { get; set; }

    [Column("DetailsEmoteDelay2", TypeName="int")]
    public virtual uint DetailsEmoteDelay2 { get; set; }

    [Column("DetailsEmoteDelay3", TypeName="int")]
    public virtual uint DetailsEmoteDelay3 { get; set; }

    [Column("DetailsEmoteDelay4", TypeName="int")]
    public virtual uint DetailsEmoteDelay4 { get; set; }

    [Column("EndText", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EndText { get; set; }

    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("ExclusiveGroup", TypeName="mediumint")]
    public virtual int ExclusiveGroup { get; set; }

    [Column("IncompleteEmote", TypeName="smallint")]
    public virtual ushort IncompleteEmote { get; set; }

    [Column("IncompleteEmoteDelay", TypeName="int")]
    public virtual uint IncompleteEmoteDelay { get; set; }

    [Column("LimitTime", TypeName="int")]
    public virtual uint LimitTime { get; set; }

    [Column("MaxLevel", TypeName="tinyint")]
    public virtual byte MaxLevel { get; set; }

    [Column("Method", TypeName="tinyint")]
    public virtual byte Method { get; set; }

    [Column("MinLevel", TypeName="tinyint")]
    public virtual byte MinLevel { get; set; }

    [Column("NextQuestId", TypeName="mediumint")]
    public virtual int NextQuestId { get; set; }

    [Column("NextQuestInChain", TypeName="mediumint")]
    public virtual uint NextQuestInChain { get; set; }

    [Column("Objectives", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Objectives { get; set; }

    [Column("ObjectiveText1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText1 { get; set; }

    [Column("ObjectiveText2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText2 { get; set; }

    [Column("ObjectiveText3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText3 { get; set; }

    [Column("ObjectiveText4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ObjectiveText4 { get; set; }

    [Column("OfferRewardEmote1", TypeName="smallint")]
    public virtual ushort OfferRewardEmote1 { get; set; }

    [Column("OfferRewardEmote2", TypeName="smallint")]
    public virtual ushort OfferRewardEmote2 { get; set; }

    [Column("OfferRewardEmote3", TypeName="smallint")]
    public virtual ushort OfferRewardEmote3 { get; set; }

    [Column("OfferRewardEmote4", TypeName="smallint")]
    public virtual ushort OfferRewardEmote4 { get; set; }

    [Column("OfferRewardEmoteDelay1", TypeName="int")]
    public virtual uint OfferRewardEmoteDelay1 { get; set; }

    [Column("OfferRewardEmoteDelay2", TypeName="int")]
    public virtual uint OfferRewardEmoteDelay2 { get; set; }

    [Column("OfferRewardEmoteDelay3", TypeName="int")]
    public virtual uint OfferRewardEmoteDelay3 { get; set; }

    [Column("OfferRewardEmoteDelay4", TypeName="int")]
    public virtual uint OfferRewardEmoteDelay4 { get; set; }

    [Column("OfferRewardText", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OfferRewardText { get; set; }

    [Column("PointMapId", TypeName="smallint")]
    public virtual ushort PointMapId { get; set; }

    [Column("PointOpt", TypeName="mediumint")]
    public virtual uint PointOpt { get; set; }

    [Column("PointX", TypeName="float")]
    public virtual float PointX { get; set; }

    [Column("PointY", TypeName="float")]
    public virtual float PointY { get; set; }

    [Column("PrevQuestId", TypeName="mediumint")]
    public virtual int PrevQuestId { get; set; }

    [Column("QuestFlags", TypeName="smallint")]
    public virtual ushort QuestFlags { get; set; }

    [Column("QuestLevel", TypeName="smallint")]
    public virtual short QuestLevel { get; set; }

    [Column("RepObjectiveFaction", TypeName="smallint")]
    public virtual ushort RepObjectiveFaction { get; set; }

    [Column("RepObjectiveValue", TypeName="mediumint")]
    public virtual int RepObjectiveValue { get; set; }

    [Column("ReqCreatureOrGOCount1", TypeName="smallint")]
    public virtual ushort ReqCreatureOrGOCount1 { get; set; }

    [Column("ReqCreatureOrGOCount2", TypeName="smallint")]
    public virtual ushort ReqCreatureOrGOCount2 { get; set; }

    [Column("ReqCreatureOrGOCount3", TypeName="smallint")]
    public virtual ushort ReqCreatureOrGOCount3 { get; set; }

    [Column("ReqCreatureOrGOCount4", TypeName="smallint")]
    public virtual ushort ReqCreatureOrGOCount4 { get; set; }

    [Column("ReqCreatureOrGOId1", TypeName="mediumint")]
    public virtual int ReqCreatureOrGOId1 { get; set; }

    [Column("ReqCreatureOrGOId2", TypeName="mediumint")]
    public virtual int ReqCreatureOrGOId2 { get; set; }

    [Column("ReqCreatureOrGOId3", TypeName="mediumint")]
    public virtual int ReqCreatureOrGOId3 { get; set; }

    [Column("ReqCreatureOrGOId4", TypeName="mediumint")]
    public virtual int ReqCreatureOrGOId4 { get; set; }

    [Column("ReqItemCount1", TypeName="smallint")]
    public virtual ushort ReqItemCount1 { get; set; }

    [Column("ReqItemCount2", TypeName="smallint")]
    public virtual ushort ReqItemCount2 { get; set; }

    [Column("ReqItemCount3", TypeName="smallint")]
    public virtual ushort ReqItemCount3 { get; set; }

    [Column("ReqItemCount4", TypeName="smallint")]
    public virtual ushort ReqItemCount4 { get; set; }

    [Column("ReqItemId1", TypeName="mediumint")]
    public virtual uint ReqItemId1 { get; set; }

    [Column("ReqItemId2", TypeName="mediumint")]
    public virtual uint ReqItemId2 { get; set; }

    [Column("ReqItemId3", TypeName="mediumint")]
    public virtual uint ReqItemId3 { get; set; }

    [Column("ReqItemId4", TypeName="mediumint")]
    public virtual uint ReqItemId4 { get; set; }

    [Column("ReqSourceCount1", TypeName="smallint")]
    public virtual ushort ReqSourceCount1 { get; set; }

    [Column("ReqSourceCount2", TypeName="smallint")]
    public virtual ushort ReqSourceCount2 { get; set; }

    [Column("ReqSourceCount3", TypeName="smallint")]
    public virtual ushort ReqSourceCount3 { get; set; }

    [Column("ReqSourceCount4", TypeName="smallint")]
    public virtual ushort ReqSourceCount4 { get; set; }

    [Column("ReqSourceId1", TypeName="mediumint")]
    public virtual uint ReqSourceId1 { get; set; }

    [Column("ReqSourceId2", TypeName="mediumint")]
    public virtual uint ReqSourceId2 { get; set; }

    [Column("ReqSourceId3", TypeName="mediumint")]
    public virtual uint ReqSourceId3 { get; set; }

    [Column("ReqSourceId4", TypeName="mediumint")]
    public virtual uint ReqSourceId4 { get; set; }

    [Column("ReqSpellCast1", TypeName="mediumint")]
    public virtual uint ReqSpellCast1 { get; set; }

    [Column("ReqSpellCast2", TypeName="mediumint")]
    public virtual uint ReqSpellCast2 { get; set; }

    [Column("ReqSpellCast3", TypeName="mediumint")]
    public virtual uint ReqSpellCast3 { get; set; }

    [Column("ReqSpellCast4", TypeName="mediumint")]
    public virtual uint ReqSpellCast4 { get; set; }

    [Column("RequestItemsText", TypeName="text")]
    [MaxLength(65535)]
    public virtual string RequestItemsText { get; set; }

    [Column("RequiredClasses", TypeName="smallint")]
    public virtual ushort RequiredClasses { get; set; }

    [Column("RequiredCondition", TypeName="int")]
    public virtual uint RequiredCondition { get; set; }

    [Column("RequiredMaxRepFaction", TypeName="smallint")]
    public virtual ushort RequiredMaxRepFaction { get; set; }

    [Column("RequiredMaxRepValue", TypeName="mediumint")]
    public virtual int RequiredMaxRepValue { get; set; }

    [Column("RequiredMinRepFaction", TypeName="smallint")]
    public virtual ushort RequiredMinRepFaction { get; set; }

    [Column("RequiredMinRepValue", TypeName="mediumint")]
    public virtual int RequiredMinRepValue { get; set; }

    [Column("RequiredRaces", TypeName="smallint")]
    public virtual ushort RequiredRaces { get; set; }

    [Column("RequiredSkill", TypeName="smallint")]
    public virtual ushort RequiredSkill { get; set; }

    [Column("RequiredSkillValue", TypeName="smallint")]
    public virtual ushort RequiredSkillValue { get; set; }

    [Column("RewChoiceItemCount1", TypeName="smallint")]
    public virtual ushort RewChoiceItemCount1 { get; set; }

    [Column("RewChoiceItemCount2", TypeName="smallint")]
    public virtual ushort RewChoiceItemCount2 { get; set; }

    [Column("RewChoiceItemCount3", TypeName="smallint")]
    public virtual ushort RewChoiceItemCount3 { get; set; }

    [Column("RewChoiceItemCount4", TypeName="smallint")]
    public virtual ushort RewChoiceItemCount4 { get; set; }

    [Column("RewChoiceItemCount5", TypeName="smallint")]
    public virtual ushort RewChoiceItemCount5 { get; set; }

    [Column("RewChoiceItemCount6", TypeName="smallint")]
    public virtual ushort RewChoiceItemCount6 { get; set; }

    [Column("RewChoiceItemId1", TypeName="mediumint")]
    public virtual uint RewChoiceItemId1 { get; set; }

    [Column("RewChoiceItemId2", TypeName="mediumint")]
    public virtual uint RewChoiceItemId2 { get; set; }

    [Column("RewChoiceItemId3", TypeName="mediumint")]
    public virtual uint RewChoiceItemId3 { get; set; }

    [Column("RewChoiceItemId4", TypeName="mediumint")]
    public virtual uint RewChoiceItemId4 { get; set; }

    [Column("RewChoiceItemId5", TypeName="mediumint")]
    public virtual uint RewChoiceItemId5 { get; set; }

    [Column("RewChoiceItemId6", TypeName="mediumint")]
    public virtual uint RewChoiceItemId6 { get; set; }

    [Column("RewItemCount1", TypeName="smallint")]
    public virtual ushort RewItemCount1 { get; set; }

    [Column("RewItemCount2", TypeName="smallint")]
    public virtual ushort RewItemCount2 { get; set; }

    [Column("RewItemCount3", TypeName="smallint")]
    public virtual ushort RewItemCount3 { get; set; }

    [Column("RewItemCount4", TypeName="smallint")]
    public virtual ushort RewItemCount4 { get; set; }

    [Column("RewItemId1", TypeName="mediumint")]
    public virtual uint RewItemId1 { get; set; }

    [Column("RewItemId2", TypeName="mediumint")]
    public virtual uint RewItemId2 { get; set; }

    [Column("RewItemId3", TypeName="mediumint")]
    public virtual uint RewItemId3 { get; set; }

    [Column("RewItemId4", TypeName="mediumint")]
    public virtual uint RewItemId4 { get; set; }

    [Column("RewMailDelaySecs", TypeName="int")]
    public virtual uint RewMailDelaySecs { get; set; }

    [Column("RewMailTemplateId", TypeName="mediumint")]
    public virtual uint RewMailTemplateId { get; set; }

    [Column("RewMoneyMaxLevel", TypeName="int")]
    public virtual uint RewMoneyMaxLevel { get; set; }

    [Column("RewOrReqMoney", TypeName="int")]
    public virtual int RewOrReqMoney { get; set; }

    /* faction id from Faction.dbc in this case */
    [Column("RewRepFaction1", TypeName="smallint")]
    public virtual ushort RewRepFaction1 { get; set; }

    /* faction id from Faction.dbc in this case */
    [Column("RewRepFaction2", TypeName="smallint")]
    public virtual ushort RewRepFaction2 { get; set; }

    /* faction id from Faction.dbc in this case */
    [Column("RewRepFaction3", TypeName="smallint")]
    public virtual ushort RewRepFaction3 { get; set; }

    /* faction id from Faction.dbc in this case */
    [Column("RewRepFaction4", TypeName="smallint")]
    public virtual ushort RewRepFaction4 { get; set; }

    /* faction id from Faction.dbc in this case */
    [Column("RewRepFaction5", TypeName="smallint")]
    public virtual ushort RewRepFaction5 { get; set; }

    [Column("RewRepValue1", TypeName="mediumint")]
    public virtual int RewRepValue1 { get; set; }

    [Column("RewRepValue2", TypeName="mediumint")]
    public virtual int RewRepValue2 { get; set; }

    [Column("RewRepValue3", TypeName="mediumint")]
    public virtual int RewRepValue3 { get; set; }

    [Column("RewRepValue4", TypeName="mediumint")]
    public virtual int RewRepValue4 { get; set; }

    [Column("RewRepValue5", TypeName="mediumint")]
    public virtual int RewRepValue5 { get; set; }

    [Column("RewSpell", TypeName="mediumint")]
    public virtual uint RewSpell { get; set; }

    [Column("RewSpellCast", TypeName="mediumint")]
    public virtual uint RewSpellCast { get; set; }

    [Column("SpecialFlags", TypeName="tinyint")]
    public virtual byte SpecialFlags { get; set; }

    [Column("SrcItemCount", TypeName="tinyint")]
    public virtual byte SrcItemCount { get; set; }

    [Column("SrcItemId", TypeName="mediumint")]
    public virtual uint SrcItemId { get; set; }

    [Column("SrcSpell", TypeName="mediumint")]
    public virtual uint SrcSpell { get; set; }

    [Column("StartScript", TypeName="mediumint")]
    public virtual uint StartScript { get; set; }

    [Column("SuggestedPlayers", TypeName="tinyint")]
    public virtual byte SuggestedPlayers { get; set; }

    [Column("Title", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Title { get; set; }

    [Column("Type", TypeName="smallint")]
    public virtual ushort Type { get; set; }

    [Column("ZoneOrSort", TypeName="smallint")]
    public virtual short ZoneOrSort { get; set; }

}