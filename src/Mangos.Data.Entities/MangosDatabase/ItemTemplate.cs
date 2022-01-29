using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("item_template")]
public class ItemTemplate
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("class", TypeName="tinyint")]
    public virtual byte Class { get; set; }

    [Column("subclass", TypeName="tinyint")]
    public virtual byte Subclass { get; set; }

    [Column("name")]
    [MaxLength(255)]
    public virtual string Name { get; set; }

    [Column("displayid", TypeName="mediumint")]
    public virtual uint Displayid { get; set; }

    [Column("Quality", TypeName="tinyint")]
    public virtual byte Quality { get; set; }

    [Column("Flags", TypeName="int")]
    public virtual uint Flags { get; set; }

    [Column("BuyCount", TypeName="tinyint")]
    public virtual byte BuyCount { get; set; }

    [Column("BuyPrice", TypeName="int")]
    public virtual uint BuyPrice { get; set; }

    [Column("SellPrice", TypeName="int")]
    public virtual uint SellPrice { get; set; }

    [Column("InventoryType", TypeName="tinyint")]
    public virtual byte InventoryType { get; set; }

    [Column("AllowableClass", TypeName="mediumint")]
    public virtual int AllowableClass { get; set; }

    [Column("AllowableRace", TypeName="mediumint")]
    public virtual int AllowableRace { get; set; }

    [Column("ItemLevel", TypeName="tinyint")]
    public virtual byte ItemLevel { get; set; }

    [Column("RequiredLevel", TypeName="tinyint")]
    public virtual byte RequiredLevel { get; set; }

    [Column("RequiredSkill", TypeName="smallint")]
    public virtual uint RequiredSkill { get; set; }

    [Column("RequiredSkillRank", TypeName="smallint")]
    public virtual uint RequiredSkillRank { get; set; }

    [Column("requiredspell", TypeName="mediumint")]
    public virtual uint Requiredspell { get; set; }

    [Column("requiredhonorrank", TypeName="mediumint")]
    public virtual uint Requiredhonorrank { get; set; }

    [Column("RequiredCityRank", TypeName="mediumint")]
    public virtual uint RequiredCityRank { get; set; }

    [Column("RequiredReputationFaction", TypeName="smallint")]
    public virtual uint RequiredReputationFaction { get; set; }

    [Column("RequiredReputationRank", TypeName="smallint")]
    public virtual uint RequiredReputationRank { get; set; }

    [Column("maxcount", TypeName="smallint")]
    public virtual uint Maxcount { get; set; }

    [Column("stackable", TypeName="smallint")]
    public virtual uint Stackable { get; set; }

    [Column("ContainerSlots", TypeName="tinyint")]
    public virtual byte ContainerSlots { get; set; }

    [Column("stat_type1", TypeName="tinyint")]
    public virtual byte StatType1 { get; set; }

    [Column("stat_value1", TypeName="smallint")]
    public virtual int StatValue1 { get; set; }

    [Column("stat_type2", TypeName="tinyint")]
    public virtual byte StatType2 { get; set; }

    [Column("stat_value2", TypeName="smallint")]
    public virtual int StatValue2 { get; set; }

    [Column("stat_type3", TypeName="tinyint")]
    public virtual byte StatType3 { get; set; }

    [Column("stat_value3", TypeName="smallint")]
    public virtual int StatValue3 { get; set; }

    [Column("stat_type4", TypeName="tinyint")]
    public virtual byte StatType4 { get; set; }

    [Column("stat_value4", TypeName="smallint")]
    public virtual int StatValue4 { get; set; }

    [Column("stat_type5", TypeName="tinyint")]
    public virtual byte StatType5 { get; set; }

    [Column("stat_value5", TypeName="smallint")]
    public virtual int StatValue5 { get; set; }

    [Column("stat_type6", TypeName="tinyint")]
    public virtual byte StatType6 { get; set; }

    [Column("stat_value6", TypeName="smallint")]
    public virtual int StatValue6 { get; set; }

    [Column("stat_type7", TypeName="tinyint")]
    public virtual byte StatType7 { get; set; }

    [Column("stat_value7", TypeName="smallint")]
    public virtual int StatValue7 { get; set; }

    [Column("stat_type8", TypeName="tinyint")]
    public virtual byte StatType8 { get; set; }

    [Column("stat_value8", TypeName="smallint")]
    public virtual int StatValue8 { get; set; }

    [Column("stat_type9", TypeName="tinyint")]
    public virtual byte StatType9 { get; set; }

    [Column("stat_value9", TypeName="smallint")]
    public virtual int StatValue9 { get; set; }

    [Column("stat_type10", TypeName="tinyint")]
    public virtual byte StatType10 { get; set; }

    [Column("stat_value10", TypeName="smallint")]
    public virtual int StatValue10 { get; set; }

    [Column("dmg_min1", TypeName="float")]
    public virtual float DmgMin1 { get; set; }

    [Column("dmg_max1", TypeName="float")]
    public virtual float DmgMax1 { get; set; }

    [Column("dmg_type1", TypeName="tinyint")]
    public virtual byte DmgType1 { get; set; }

    [Column("dmg_min2", TypeName="float")]
    public virtual float DmgMin2 { get; set; }

    [Column("dmg_max2", TypeName="float")]
    public virtual float DmgMax2 { get; set; }

    [Column("dmg_type2", TypeName="tinyint")]
    public virtual byte DmgType2 { get; set; }

    [Column("dmg_min3", TypeName="float")]
    public virtual float DmgMin3 { get; set; }

    [Column("dmg_max3", TypeName="float")]
    public virtual float DmgMax3 { get; set; }

    [Column("dmg_type3", TypeName="tinyint")]
    public virtual byte DmgType3 { get; set; }

    [Column("dmg_min4", TypeName="float")]
    public virtual float DmgMin4 { get; set; }

    [Column("dmg_max4", TypeName="float")]
    public virtual float DmgMax4 { get; set; }

    [Column("dmg_type4", TypeName="tinyint")]
    public virtual byte DmgType4 { get; set; }

    [Column("dmg_min5", TypeName="float")]
    public virtual float DmgMin5 { get; set; }

    [Column("dmg_max5", TypeName="float")]
    public virtual float DmgMax5 { get; set; }

    [Column("dmg_type5", TypeName="tinyint")]
    public virtual byte DmgType5 { get; set; }

    [Column("armor", TypeName="smallint")]
    public virtual uint Armor { get; set; }

    [Column("holy_res", TypeName="tinyint")]
    public virtual byte HolyRes { get; set; }

    [Column("fire_res", TypeName="tinyint")]
    public virtual byte FireRes { get; set; }

    [Column("nature_res", TypeName="tinyint")]
    public virtual byte NatureRes { get; set; }

    [Column("frost_res", TypeName="tinyint")]
    public virtual byte FrostRes { get; set; }

    [Column("shadow_res", TypeName="tinyint")]
    public virtual byte ShadowRes { get; set; }

    [Column("arcane_res", TypeName="tinyint")]
    public virtual byte ArcaneRes { get; set; }

    [Column("delay", TypeName="smallint")]
    public virtual uint Delay { get; set; }

    [Column("ammo_type", TypeName="tinyint")]
    public virtual byte AmmoType { get; set; }

    [Column("RangedModRange", TypeName="float")]
    public virtual float RangedModRange { get; set; }

    [Column("spellid_1", TypeName="mediumint")]
    public virtual uint SpellId1 { get; set; }

    [Column("spelltrigger_1", TypeName="tinyint")]
    public virtual byte SpellTrigger1 { get; set; }

    [Column("spellcharges_1", TypeName="tinyint")]
    public virtual int SpellCharges1 { get; set; }

    [Column("spellppmRate_1", TypeName="float")]
    public virtual float SpellPpmRate1 { get; set; }

    [Column("spellcooldown_1", TypeName="int")]
    public virtual int SpellCooldown1 { get; set; }

    [Column("spellcategory_1", TypeName="smallint")]
    public virtual uint SpellCategory1 { get; set; }

    [Column("spellcategorycooldown_1", TypeName="int")]
    public virtual int SpellCategoryCooldown1 { get; set; }

    [Column("spellid_2", TypeName="mediumint")]
    public virtual uint Spellid2 { get; set; }

    [Column("spelltrigger_2", TypeName="tinyint")]
    public virtual byte Spelltrigger2 { get; set; }

    [Column("spellcharges_2", TypeName="tinyint")]
    public virtual int Spellcharges2 { get; set; }

    [Column("spellppmRate_2", TypeName="float")]
    public virtual float SpellppmRate2 { get; set; }

    [Column("spellcooldown_2", TypeName="int")]
    public virtual int Spellcooldown2 { get; set; }

    [Column("spellcategory_2", TypeName="smallint")]
    public virtual uint Spellcategory2 { get; set; }

    [Column("spellcategorycooldown_2", TypeName="int")]
    public virtual int Spellcategorycooldown2 { get; set; }

    [Column("spellid_3", TypeName="mediumint")]
    public virtual uint Spellid3 { get; set; }

    [Column("spelltrigger_3", TypeName="tinyint")]
    public virtual byte Spelltrigger3 { get; set; }

    [Column("spellcharges_3", TypeName="tinyint")]
    public virtual int Spellcharges3 { get; set; }

    [Column("spellppmRate_3", TypeName="float")]
    public virtual float SpellppmRate3 { get; set; }

    [Column("spellcooldown_3", TypeName="int")]
    public virtual int Spellcooldown3 { get; set; }

    [Column("spellcategory_3", TypeName="smallint")]
    public virtual uint Spellcategory3 { get; set; }

    [Column("spellcategorycooldown_3", TypeName="int")]
    public virtual int Spellcategorycooldown3 { get; set; }

    [Column("spellid_4", TypeName="mediumint")]
    public virtual uint Spellid4 { get; set; }

    [Column("spelltrigger_4", TypeName="tinyint")]
    public virtual byte Spelltrigger4 { get; set; }

    [Column("spellcharges_4", TypeName="tinyint")]
    public virtual int Spellcharges4 { get; set; }

    [Column("spellppmRate_4", TypeName="float")]
    public virtual float SpellppmRate4 { get; set; }

    [Column("spellcooldown_4", TypeName="int")]
    public virtual int Spellcooldown4 { get; set; }

    [Column("spellcategory_4", TypeName="smallint")]
    public virtual uint Spellcategory4 { get; set; }

    [Column("spellcategorycooldown_4", TypeName="int")]
    public virtual int Spellcategorycooldown4 { get; set; }

    [Column("spellid_5", TypeName="mediumint")]
    public virtual uint Spellid5 { get; set; }

    [Column("spelltrigger_5", TypeName="tinyint")]
    public virtual byte Spelltrigger5 { get; set; }

    [Column("spellcharges_5", TypeName="tinyint")]
    public virtual int Spellcharges5 { get; set; }

    [Column("spellppmRate_5", TypeName="float")]
    public virtual float SpellppmRate5 { get; set; }

    [Column("spellcooldown_5", TypeName="int")]
    public virtual int Spellcooldown5 { get; set; }

    [Column("spellcategory_5", TypeName="smallint")]
    public virtual uint Spellcategory5 { get; set; }

    [Column("spellcategorycooldown_5", TypeName="int")]
    public virtual int Spellcategorycooldown5 { get; set; }

    [Column("bonding", TypeName="tinyint")]
    public virtual byte Bonding { get; set; }

    [Column("description")]
    [MaxLength(255)]
    public virtual string Description { get; set; }

    [Column("PageText", TypeName="mediumint")]
    public virtual uint PageText { get; set; }

    [Column("LanguageID", TypeName="tinyint")]
    public virtual byte LanguageId { get; set; }

    [Column("PageMaterial", TypeName="tinyint")]
    public virtual byte PageMaterial { get; set; }

    [Column("startquest", TypeName="mediumint")]
    public virtual uint StartQuest { get; set; }

    [Column("lockid", TypeName="mediumint")]
    public virtual uint Lockid { get; set; }

    [Column("Material", TypeName="tinyint")]
    public virtual int Material { get; set; }

    [Column("sheath", TypeName="tinyint")]
    public virtual byte Sheath { get; set; }

    [Column("RandomProperty", TypeName="mediumint")]
    public virtual uint RandomProperty { get; set; }

    [Column("block", TypeName="mediumint")]
    public virtual uint Block { get; set; }

    [Column("itemset", TypeName="mediumint")]
    public virtual uint Itemset { get; set; }

    [Column("MaxDurability", TypeName="smallint")]
    public virtual uint MaxDurability { get; set; }

    [Column("area", TypeName="mediumint")]
    public virtual uint Area { get; set; }

    [Column("Map", TypeName="smallint")]
    public virtual int Map { get; set; }

    [Column("BagFamily", TypeName="mediumint")]
    public virtual int BagFamily { get; set; }

    [Column("ScriptName")]
    [MaxLength(64)]
    public virtual string ScriptName { get; set; }

    [Column("DisenchantID", TypeName="mediumint")]
    public virtual uint DisenchantId { get; set; }

    [Column("FoodType", TypeName="tinyint")]
    public virtual byte FoodType { get; set; }

    [Column("minMoneyLoot", TypeName="int")]
    public virtual uint MinMoneyLoot { get; set; }

    [Column("maxMoneyLoot", TypeName="int")]
    public virtual uint MaxMoneyLoot { get; set; }

    /* Duration in seconds */
    [Column("Duration", TypeName="int")]
    public virtual uint Duration { get; set; }

    [Column("ExtraFlags", TypeName="tinyint")]
    public virtual byte ExtraFlags { get; set; }

}