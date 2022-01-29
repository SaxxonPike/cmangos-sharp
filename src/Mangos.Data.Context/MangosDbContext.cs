using Mangos.Data.Entities.MangosDatabase;
using Microsoft.EntityFrameworkCore;

namespace Mangos.Data.Context;

public class ClassicmangosDbContext : DbContext
{
    public ClassicmangosDbContext()
    {
    }

    public ClassicmangosDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AreaTriggerInvolvedRelation>().HasKey(e => new { id = e.Id });
        builder.Entity<AreaTriggerTavern>().HasKey(e => new { id = e.Id });
        builder.Entity<AreaTriggerTeleport>().HasKey(e => new { id = e.Id });
        builder.Entity<Auction>().HasKey(e => new { id = e.Id });
        builder.Entity<BattlegroundEvents>().HasKey(e => new { map = e.Map, event1 = e.Event1, event2 = e.Event2 });
        builder.Entity<BattlegroundTemplate>().HasKey(e => new { id = e.Id });
        builder.Entity<BattlemasterEntry>().HasKey(e => new { entry = e.Entry });
        builder.Entity<BugReport>().HasKey(e => new { id = e.Id });
        builder.Entity<Command>().HasKey(e => new { name = e.Name });
        builder.Entity<CreatureAddon>().HasKey(e => new { guid = e.Guid });
        builder.Entity<CreatureAiScript>().HasKey(e => new { id = e.Id });
        builder.Entity<CreatureAiSummon>().HasKey(e => new { id = e.Id });
        builder.Entity<CreatureAiText>().HasKey(e => new { entry = e.Entry });
        builder.Entity<CreatureBattleground>().HasKey(e => new { guid = e.Guid });
        builder.Entity<CreatureConditionalSpawn>().HasKey(e => new { e.Guid });
        builder.Entity<CreatureCooldown>().HasKey(e => new { e.Entry, e.SpellId });
        builder.Entity<CreatureEquipTemplate>().HasKey(e => new { entry = e.Entry });
        builder.Entity<CreatureInvolvedRelation>().HasKey(e => new { id = e.Id, quest = e.Quest });
        builder.Entity<CreatureLinking>().HasKey(e => new { guid = e.Guid });
        builder.Entity<CreatureLinkingTemplate>().HasKey(e => new { entry = e.Entry, map = e.Map });
        builder.Entity<CreatureLootTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<CreatureModelInfo>().HasKey(e => new { modelid = e.Modelid });
        builder.Entity<CreatureModelRace>().HasKey(e => new { modelid = e.Modelid, racemask = e.Racemask });
        builder.Entity<CreatureOnKillReputation>().HasKey(e => new { creature_id = e.CreatureId });
        builder.Entity<CreatureQuestRelation>().HasKey(e => new { id = e.Id, quest = e.Quest });
        builder.Entity<CreatureSpawnEntry>().HasKey(e => new { guid = e.Guid, entry = e.Entry });
        builder.Entity<CreatureTemplateAddon>().HasKey(e => new { entry = e.Entry });
        builder.Entity<CreatureTemplateArmor>().HasKey(e => new { e.Entry });
        builder.Entity<CreatureTemplateClassLevelStats>().HasKey(e => new { e.Level, e.Class });
        builder.Entity<CustomTexts>().HasKey(e => new { entry = e.Entry });
        builder.Entity<DbScriptRandomTemplate>().HasKey(e => new { id = e.Id, type = e.Type, target_id = e.TargetId });
        builder.Entity<DbScriptString>().HasKey(e => new { entry = e.Entry });
        builder.Entity<DisenchantLootTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<ExplorationBaseXp>().HasKey(e => new { level = e.Level });
        builder.Entity<FishingLootTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<GameEvent>().HasKey(e => new { entry = e.Entry });
        builder.Entity<GameEventCreature>().HasKey(e => new { guid = e.Guid, e.Event });
        builder.Entity<GameEventCreatureData>().HasKey(e => new { guid = e.Guid, e.Event });
        builder.Entity<GameEventGameObject>().HasKey(e => new { guid = e.Guid, e.Event });
        builder.Entity<GameEventMail>().HasKey(e => new { e.Event, raceMask = e.RaceMask, quest = e.Quest });
        builder.Entity<GameEventQuest>().HasKey(e => new { quest = e.Quest, e.Event });
        builder.Entity<GameEventTime>().HasKey(e => new { entry = e.Entry });
        builder.Entity<GameGraveyardZone>()
            .HasKey(e => new { id = e.Id, ghost_loc = e.GhostLoc, link_kind = e.LinkKind });
        builder.Entity<GameTele>().HasKey(e => new { id = e.Id });
        builder.Entity<GameWeather>().HasKey(e => new { zone = e.Zone });
        builder.Entity<GameObjectAddon>().HasKey(e => new { guid = e.Guid });
        builder.Entity<GameObjectBattleground>().HasKey(e => new { guid = e.Guid });
        builder.Entity<GameObjectInvolvedrelation>().HasKey(e => new { id = e.Id, quest = e.Quest });
        builder.Entity<GameObjectLootTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<GameObjectQuestrelation>().HasKey(e => new { id = e.Id, quest = e.Quest });
        builder.Entity<GossipMenu>().HasKey(e => new { entry = e.Entry, text_id = e.TextId, script_id = e.ScriptId });
        builder.Entity<GossipMenuOption>().HasKey(e => new { menu_id = e.MenuId, id = e.Id });
        builder.Entity<GossipTexts>().HasKey(e => new { entry = e.Entry });
        builder.Entity<InstanceDungeonEncounter>().HasKey(e => new { e.Id });
        builder.Entity<InstanceEncounter>().HasKey(e => new { entry = e.Entry });
        builder.Entity<InstanceTemplate>().HasKey(e => new { map = e.Map });
        builder.Entity<ItemConvert>().HasKey(e => new { entry = e.Entry });
        builder.Entity<ItemEnchantmentTemplate>().HasKey(e => new { entry = e.Entry, ench = e.Ench });
        builder.Entity<ItemExpireConvert>().HasKey(e => new { entry = e.Entry });
        builder.Entity<ItemLootTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<ItemRequiredTarget>()
            .HasKey(e => new { entry = e.Entry, type = e.Type, targetEntry = e.TargetEntry });
        builder.Entity<ItemTemplate>().HasKey(e => new { entry = e.Entry });
        builder.Entity<MailLevelReward>().HasKey(e => new { level = e.Level, raceMask = e.RaceMask });
        builder.Entity<MailLootTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<MangosString>().HasKey(e => new { entry = e.Entry });
        builder.Entity<NpcGossip>().HasKey(e => new { npc_guid = e.NpcGuid });
        builder.Entity<NpcSpellclickSpells>().HasKey(e => new { npc_entry = e.NpcEntry });
        builder.Entity<NpcText>().HasKey(e => new { ID = e.Id });
        builder.Entity<NpcTextBroadcastText>().HasKey(e => new { e.Id });
        builder.Entity<NpcTrainer>().HasKey(e => new { entry = e.Entry, spell = e.Spell });
        builder.Entity<NpcTrainerTemplate>().HasKey(e => new { entry = e.Entry, spell = e.Spell });
        builder.Entity<NpcVendor>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<NpcVendorTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<PageText>().HasKey(e => new { entry = e.Entry });
        builder.Entity<PetFamilyStats>().HasKey(e => new { family = e.Family });
        builder.Entity<PetLevelStats>().HasKey(e => new { creature_entry = e.CreatureEntry, level = e.Level });
        builder.Entity<PetLevelStatsCopy>().HasKey(e => new { creature_entry = e.CreatureEntry, level = e.Level });
        builder.Entity<PetNameGeneration>().HasKey(e => new { id = e.Id });
        builder.Entity<PetCreateInfoSpell>().HasKey(e => new { entry = e.Entry });
        builder.Entity<PickpocketingLootTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<PlayerClassLevelStat>().HasKey(e => new { e.Class, level = e.Level });
        builder.Entity<PlayerLevelStat>().HasKey(e => new { race = e.Race, e.Class, level = e.Level });
        builder.Entity<PlayerXpForLevel>().HasKey(e => new { lvl = e.Lvl });
        builder.Entity<PlayerCreateInfo>().HasKey(e => new { race = e.Race, e.Class });
        builder.Entity<PlayerCreateInfoAction>().HasKey(e => new { race = e.Race, e.Class, button = e.Button });
        builder.Entity<PlayerCreateInfoItem>().HasKey(e => new { race = e.Race });
        builder.Entity<PlayerCreateInfoSkills>()
            .HasKey(e => new { raceMask = e.RaceMask, classMask = e.ClassMask, skill = e.Skill });
        builder.Entity<PlayerCreateInfoSpell>().HasKey(e => new { race = e.Race, e.Class, e.Spell });
        builder.Entity<PointsOfInterest>().HasKey(e => new { entry = e.Entry });
        builder.Entity<PoolCreature>().HasKey(e => new { guid = e.Guid });
        builder.Entity<PoolCreatureTemplate>().HasKey(e => new { id = e.Id });
        builder.Entity<PoolGameObject>().HasKey(e => new { guid = e.Guid });
        builder.Entity<PoolGameObjectTemplate>().HasKey(e => new { id = e.Id });
        builder.Entity<PoolPool>().HasKey(e => new { pool_id = e.PoolId });
        builder.Entity<PoolTemplate>().HasKey(e => new { entry = e.Entry });
        builder.Entity<ProspectingLootTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<QuestPoi>().HasKey(e => new { questId = e.QuestId, poiId = e.PoiId });
        builder.Entity<QuestPoiPoints>().HasKey(e => new { questId = e.QuestId });
        builder.Entity<QuestTemplate>().HasKey(e => new { entry = e.Entry });
        builder.Entity<QuestGiverGreeting>().HasKey(e => new { e.Entry, e.Type });
        builder.Entity<ReferenceLootTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<ReferenceLootTemplateNames>().HasKey(e => new { entry = e.Entry });
        builder.Entity<ReputationRewardRate>().HasKey(e => new { faction = e.Faction });
        builder.Entity<ReputationSpilloverTemplate>().HasKey(e => new { faction = e.Faction });
        builder.Entity<ReservedName>().HasKey(e => new { name = e.Name });
        builder.Entity<ScriptTexts>().HasKey(e => new { entry = e.Entry });
        builder.Entity<ScriptedAreaTrigger>().HasKey(e => new { entry = e.Entry });
        builder.Entity<ScriptedEventId>().HasKey(e => new { id = e.Id });
        builder.Entity<SkillDiscoveryTemplate>().HasKey(e => new { spellId = e.SpellId, reqSpell = e.ReqSpell });
        builder.Entity<SkillExtraItemTemplate>().HasKey(e => new { spellId = e.SpellId });
        builder.Entity<SkillFishingBaseLevel>().HasKey(e => new { entry = e.Entry });
        builder.Entity<SkinningLootTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<SpamRecords>().HasKey(e => new { id = e.Id });
        builder.Entity<SpellEffect>().HasKey(e => new { entry = e.Entry, effectId = e.EffectId });
        builder.Entity<SpellArea>().HasKey(e => new
        {
            spell = e.Spell, area = e.Area, quest_start = e.QuestStart, quest_start_active = e.QuestStartActive,
            aura_spell = e.AuraSpell, racemask = e.Racemask, gender = e.Gender
        });
        builder.Entity<SpellBonusData>().HasKey(e => new { entry = e.Entry });
        builder.Entity<SpellChain>().HasKey(e => new { spell_id = e.SpellId });
        builder.Entity<SpellCone>().HasKey(e => new { e.Id });
        builder.Entity<SpellElixir>().HasKey(e => new { entry = e.Entry });
        builder.Entity<SpellFacing>().HasKey(e => new { entry = e.Entry });
        builder.Entity<SpellLearnSpell>().HasKey(e => new { entry = e.Entry, SpellID = e.SpellId });
        builder.Entity<SpellLootTemplate>().HasKey(e => new { entry = e.Entry, item = e.Item });
        builder.Entity<SpellPetAuras>().HasKey(e => new { spell = e.Spell, pet = e.Pet });
        builder.Entity<SpellProcEvent>().HasKey(e => new { entry = e.Entry });
        builder.Entity<SpellProcItemEnchant>().HasKey(e => new { entry = e.Entry });
        builder.Entity<SpellScriptTarget>()
            .HasKey(e => new { entry = e.Entry, type = e.Type, targetEntry = e.TargetEntry });
        builder.Entity<SpellScripts>().HasKey(e => new { e.Id });
        builder.Entity<SpellTargetPosition>().HasKey(e => new { id = e.Id });
        builder.Entity<SpellTemplate>().HasKey(e => new { e.Id });
        builder.Entity<SpellThreat>().HasKey(e => new { entry = e.Entry });
        builder.Entity<TaxiShortcut>().HasKey(e => new { pathid = e.Pathid });
        builder.Entity<TrainerGreeting>().HasKey(e => new { e.Entry });
        builder.Entity<Transport>().HasKey(e => new { entry = e.Entry });
        builder.Entity<VehicleAccessory>().HasKey(e => new { vehicle_entry = e.VehicleEntry, seat = e.Seat });
        builder.Entity<WorldSafeLoc>().HasKey(e => new { id = e.Id });
        builder.Entity<WorldTemplate>().HasKey(e => new { map = e.Map });
        builder.Entity<Conditions>().HasKey(e => new { condition_entry = e.ConditionEntry });
        builder.Entity<GameObjectTemplate>().HasKey(e => new { entry = e.Entry });
        builder.Entity<CreatureTemplateSpells>().HasKey(e => new { entry = e.Entry, setId = e.SetId });
        builder.Entity<CreatureSpawnData>().HasKey(e => new { e.Guid });
        builder.Entity<CreatureImmunities>().HasKey(e => new { e.Entry, e.SetId, e.Type, e.Value });
        builder.Entity<WardenScans>().HasKey(e => new { id = e.Id });
        builder.Entity<GameObjectSpawnEntry>().HasKey(e => new { guid = e.Guid, entry = e.Entry });
        builder.Entity<BroadcastTextLocale>().HasKey(e => new { e.Id, e.Locale });
        builder.Entity<BroadcastText>().HasKey(e => new { e.Id });
        builder.Entity<DbScriptsOnRelay>().HasKey(e => new { id = e.Id });
        builder.Entity<DbScriptsOnSpell>().HasKey(e => new { id = e.Id });
        builder.Entity<CreatureSpellListEntry>().HasKey(e => new { e.Id });
        builder.Entity<CreatureSpellList>().HasKey(e => new { e.Id, e.Position });
        builder.Entity<CreatureSpellTargeting>().HasKey(e => new { e.Id });
        builder.Entity<CreatureTemplate>().HasKey(e => new { e.Entry });
        builder.Entity<DbscriptsOnCreatureMovement>().HasKey(e => new { id = e.Id });
        builder.Entity<DbscriptsOnEvent>().HasKey(e => new { id = e.Id });
        builder.Entity<DbscriptsOnGoUse>().HasKey(e => new { id = e.Id });
        builder.Entity<DbscriptsOnGoTemplateUse>().HasKey(e => new { id = e.Id });
        builder.Entity<DbscriptsOnGossip>().HasKey(e => new { id = e.Id });
        builder.Entity<DbscriptsOnQuestEnd>().HasKey(e => new { id = e.Id });
        builder.Entity<DbscriptsOnQuestStart>().HasKey(e => new { id = e.Id });
        builder.Entity<DbscriptsOnCreatureDeath>().HasKey(e => new { id = e.Id });
        builder.Entity<CreatureSpawnDataTemplate>().HasKey(e => new
            { e.Entry, e.UnitFlags, e.ModelId, e.EquipmentId, e.CurHealth, e.CurMana, e.SpawnFlags });
        builder.Entity<SpawnGroup>().HasKey(e => new { e.Id });
        builder.Entity<SpawnGroupEntry>().HasKey(e => new { e.Id, e.Entry });
        builder.Entity<SpawnGroupLinkedGroup>().HasKey(e => new { e.Id, e.LinkedId });
        builder.Entity<Creature>().HasKey(e => new { guid = e.Guid });
        builder.Entity<GameObject>().HasKey(e => new { guid = e.Guid });
        builder.Entity<SpawnGroupSpawn>().HasKey(e => new { e.Id, e.Guid });
        builder.Entity<DbVersion>().HasKey(e => new { version = e.Version });
        builder.Entity<SpawnGroupFormation>().HasKey(e => new { e.Id });
        builder.Entity<WaypointPath>().HasKey(e => new { e.PathId, e.Point });
        builder.Entity<CreatureMovement>().HasKey(e => new { e.Id, e.Point });
        builder.Entity<CreatureMovementTemplate>().HasKey(e => new { e.Entry, e.PathId, e.Point });
        builder.Entity<ScriptWaypoint>().HasKey(e => new { e.Entry, e.PathId, e.Point });
    }

    public DbSet<AreaTriggerInvolvedRelation> AreatriggerInvolvedrelations { get; set; }
    public DbSet<AreaTriggerTavern> AreatriggerTaverns { get; set; }
    public DbSet<AreaTriggerTeleport> AreatriggerTeleports { get; set; }
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<BattlegroundEvents> BattlegroundEventss { get; set; }
    public DbSet<BattlegroundTemplate> BattlegroundTemplates { get; set; }
    public DbSet<BattlemasterEntry> BattlemasterEntrys { get; set; }
    public DbSet<BugReport> Bugreports { get; set; }
    public DbSet<Command> Commands { get; set; }
    public DbSet<CreatureAddon> CreatureAddons { get; set; }
    public DbSet<CreatureAiScript> CreatureAiScriptss { get; set; }
    public DbSet<CreatureAiSummon> CreatureAiSummonss { get; set; }
    public DbSet<CreatureAiText> CreatureAiTextss { get; set; }
    public DbSet<CreatureBattleground> CreatureBattlegrounds { get; set; }
    public DbSet<CreatureConditionalSpawn> CreatureConditionalSpawns { get; set; }
    public DbSet<CreatureCooldown> CreatureCooldownss { get; set; }
    public DbSet<CreatureEquipTemplate> CreatureEquipTemplates { get; set; }
    public DbSet<CreatureInvolvedRelation> CreatureInvolvedrelations { get; set; }
    public DbSet<CreatureLinking> CreatureLinkings { get; set; }
    public DbSet<CreatureLinkingTemplate> CreatureLinkingTemplates { get; set; }
    public DbSet<CreatureLootTemplate> CreatureLootTemplates { get; set; }
    public DbSet<CreatureModelInfo> CreatureModelInfos { get; set; }
    public DbSet<CreatureModelRace> CreatureModelRaces { get; set; }
    public DbSet<CreatureOnKillReputation> CreatureOnkillReputations { get; set; }
    public DbSet<CreatureQuestRelation> CreatureQuestrelations { get; set; }
    public DbSet<CreatureSpawnEntry> CreatureSpawnEntrys { get; set; }
    public DbSet<CreatureTemplateAddon> CreatureTemplateAddons { get; set; }
    public DbSet<CreatureTemplateArmor> CreatureTemplateArmors { get; set; }
    public DbSet<CreatureTemplateClassLevelStats> CreatureTemplateClasslevelstatss { get; set; }
    public DbSet<CustomTexts> CustomTextss { get; set; }
    public DbSet<DbScriptRandomTemplate> DbscriptRandomTemplatess { get; set; }
    public DbSet<DbScriptString> DbscriptStrings { get; set; }
    public DbSet<DisenchantLootTemplate> DisenchantLootTemplates { get; set; }
    public DbSet<ExplorationBaseXp> ExplorationBasexps { get; set; }
    public DbSet<FishingLootTemplate> FishingLootTemplates { get; set; }
    public DbSet<GameEvent> GameEvents { get; set; }
    public DbSet<GameEventCreature> GameEventCreatures { get; set; }
    public DbSet<GameEventCreatureData> GameEventCreatureDatas { get; set; }
    public DbSet<GameEventGameObject> GameEventGameobjects { get; set; }
    public DbSet<GameEventMail> GameEventMails { get; set; }
    public DbSet<GameEventQuest> GameEventQuests { get; set; }
    public DbSet<GameEventTime> GameEventTimes { get; set; }
    public DbSet<GameGraveyardZone> GameGraveyardZones { get; set; }
    public DbSet<GameTele> GameTeles { get; set; }
    public DbSet<GameWeather> GameWeathers { get; set; }
    public DbSet<GameObjectAddon> GameobjectAddons { get; set; }
    public DbSet<GameObjectBattleground> GameobjectBattlegrounds { get; set; }
    public DbSet<GameObjectInvolvedrelation> GameobjectInvolvedrelations { get; set; }
    public DbSet<GameObjectLootTemplate> GameobjectLootTemplates { get; set; }
    public DbSet<GameObjectQuestrelation> GameobjectQuestrelations { get; set; }
    public DbSet<GossipMenu> GossipMenus { get; set; }
    public DbSet<GossipMenuOption> GossipMenuOptions { get; set; }
    public DbSet<GossipTexts> GossipTextss { get; set; }
    public DbSet<InstanceDungeonEncounter> InstanceDungeonEncounterss { get; set; }
    public DbSet<InstanceEncounter> InstanceEncounterss { get; set; }
    public DbSet<InstanceTemplate> InstanceTemplates { get; set; }
    public DbSet<ItemConvert> ItemConverts { get; set; }
    public DbSet<ItemEnchantmentTemplate> ItemEnchantmentTemplates { get; set; }
    public DbSet<ItemExpireConvert> ItemExpireConverts { get; set; }
    public DbSet<ItemLootTemplate> ItemLootTemplates { get; set; }
    public DbSet<ItemRequiredTarget> ItemRequiredTargets { get; set; }
    public DbSet<ItemTemplate> ItemTemplates { get; set; }
    public DbSet<MailLevelReward> MailLevelRewards { get; set; }
    public DbSet<MailLootTemplate> MailLootTemplates { get; set; }
    public DbSet<MangosString> MangosStrings { get; set; }
    public DbSet<NpcGossip> NpcGossips { get; set; }
    public DbSet<NpcSpellclickSpells> NpcSpellclickSpellss { get; set; }
    public DbSet<NpcText> NpcTexts { get; set; }
    public DbSet<NpcTextBroadcastText> NpcTextBroadcastTexts { get; set; }
    public DbSet<NpcTrainer> NpcTrainers { get; set; }
    public DbSet<NpcTrainerTemplate> NpcTrainerTemplates { get; set; }
    public DbSet<NpcVendor> NpcVendors { get; set; }
    public DbSet<NpcVendorTemplate> NpcVendorTemplates { get; set; }
    public DbSet<PageText> PageTexts { get; set; }
    public DbSet<PetFamilyStats> PetFamilystatss { get; set; }
    public DbSet<PetLevelStats> PetLevelstatss { get; set; }
    public DbSet<PetLevelStatsCopy> PetLevelstatsCopys { get; set; }
    public DbSet<PetNameGeneration> PetNameGenerations { get; set; }
    public DbSet<PetCreateInfoSpell> PetcreateinfoSpells { get; set; }
    public DbSet<PickpocketingLootTemplate> PickpocketingLootTemplates { get; set; }
    public DbSet<PlayerClassLevelStat> PlayerClasslevelstatss { get; set; }
    public DbSet<PlayerLevelStat> PlayerLevelstatss { get; set; }
    public DbSet<PlayerXpForLevel> PlayerXpForLevels { get; set; }
    public DbSet<PlayerCreateInfo> Playercreateinfos { get; set; }
    public DbSet<PlayerCreateInfoAction> PlayercreateinfoActions { get; set; }
    public DbSet<PlayerCreateInfoItem> PlayercreateinfoItems { get; set; }
    public DbSet<PlayerCreateInfoSkills> PlayercreateinfoSkillss { get; set; }
    public DbSet<PlayerCreateInfoSpell> PlayercreateinfoSpells { get; set; }
    public DbSet<PointsOfInterest> PointsOfInterests { get; set; }
    public DbSet<PoolCreature> PoolCreatures { get; set; }
    public DbSet<PoolCreatureTemplate> PoolCreatureTemplates { get; set; }
    public DbSet<PoolGameObject> PoolGameobjects { get; set; }
    public DbSet<PoolGameObjectTemplate> PoolGameobjectTemplates { get; set; }
    public DbSet<PoolPool> PoolPools { get; set; }
    public DbSet<PoolTemplate> PoolTemplates { get; set; }
    public DbSet<ProspectingLootTemplate> ProspectingLootTemplates { get; set; }
    public DbSet<QuestPoi> QuestPois { get; set; }
    public DbSet<QuestPoiPoints> QuestPoiPointss { get; set; }
    public DbSet<QuestTemplate> QuestTemplates { get; set; }
    public DbSet<QuestGiverGreeting> QuestgiverGreetings { get; set; }
    public DbSet<ReferenceLootTemplate> ReferenceLootTemplates { get; set; }
    public DbSet<ReferenceLootTemplateNames> ReferenceLootTemplateNamess { get; set; }
    public DbSet<ReputationRewardRate> ReputationRewardRates { get; set; }
    public DbSet<ReputationSpilloverTemplate> ReputationSpilloverTemplates { get; set; }
    public DbSet<ReservedName> ReservedNames { get; set; }
    public DbSet<ScriptTexts> ScriptTextss { get; set; }
    public DbSet<ScriptedAreaTrigger> ScriptedAreatriggers { get; set; }
    public DbSet<ScriptedEventId> ScriptedEventIds { get; set; }
    public DbSet<SkillDiscoveryTemplate> SkillDiscoveryTemplates { get; set; }
    public DbSet<SkillExtraItemTemplate> SkillExtraItemTemplates { get; set; }
    public DbSet<SkillFishingBaseLevel> SkillFishingBaseLevels { get; set; }
    public DbSet<SkinningLootTemplate> SkinningLootTemplates { get; set; }
    public DbSet<SpamRecords> SpamRecordss { get; set; }
    public DbSet<SpellEffect> SpellAffects { get; set; }
    public DbSet<SpellArea> SpellAreas { get; set; }
    public DbSet<SpellBonusData> SpellBonusDatas { get; set; }
    public DbSet<SpellChain> SpellChains { get; set; }
    public DbSet<SpellCone> SpellCones { get; set; }
    public DbSet<SpellElixir> SpellElixirs { get; set; }
    public DbSet<SpellFacing> SpellFacings { get; set; }
    public DbSet<SpellLearnSpell> SpellLearnSpells { get; set; }
    public DbSet<SpellLootTemplate> SpellLootTemplates { get; set; }
    public DbSet<SpellPetAuras> SpellPetAurass { get; set; }
    public DbSet<SpellProcEvent> SpellProcEvents { get; set; }
    public DbSet<SpellProcItemEnchant> SpellProcItemEnchants { get; set; }
    public DbSet<SpellScriptTarget> SpellScriptTargets { get; set; }
    public DbSet<SpellScripts> SpellScriptss { get; set; }
    public DbSet<SpellTargetPosition> SpellTargetPositions { get; set; }
    public DbSet<SpellTemplate> SpellTemplates { get; set; }
    public DbSet<SpellThreat> SpellThreats { get; set; }
    public DbSet<TaxiShortcut> TaxiShortcutss { get; set; }
    public DbSet<TrainerGreeting> TrainerGreetings { get; set; }
    public DbSet<Transport> Transportss { get; set; }
    public DbSet<VehicleAccessory> VehicleAccessorys { get; set; }
    public DbSet<WorldSafeLoc> WorldSafeLocss { get; set; }
    public DbSet<WorldTemplate> WorldTemplates { get; set; }
    public DbSet<Conditions> Conditionss { get; set; }
    public DbSet<GameObjectTemplate> GameobjectTemplates { get; set; }
    public DbSet<CreatureTemplateSpells> CreatureTemplateSpellss { get; set; }
    public DbSet<CreatureSpawnData> CreatureSpawnDatas { get; set; }
    public DbSet<CreatureImmunities> CreatureImmunitiess { get; set; }
    public DbSet<WardenScans> WardenScanss { get; set; }
    public DbSet<GameObjectSpawnEntry> GameobjectSpawnEntrys { get; set; }
    public DbSet<BroadcastTextLocale> BroadcastTextLocales { get; set; }
    public DbSet<BroadcastText> BroadcastTexts { get; set; }
    public DbSet<DbScriptsOnRelay> DbscriptsOnRelays { get; set; }
    public DbSet<DbScriptsOnSpell> DbscriptsOnSpells { get; set; }
    public DbSet<CreatureSpellListEntry> CreatureSpellListEntrys { get; set; }
    public DbSet<CreatureSpellList> CreatureSpellLists { get; set; }
    public DbSet<CreatureSpellTargeting> CreatureSpellTargetings { get; set; }
    public DbSet<CreatureTemplate> CreatureTemplates { get; set; }
    public DbSet<DbscriptsOnCreatureMovement> DbscriptsOnCreatureMovements { get; set; }
    public DbSet<DbscriptsOnEvent> DbscriptsOnEvents { get; set; }
    public DbSet<DbscriptsOnGoUse> DbscriptsOnGoUses { get; set; }
    public DbSet<DbscriptsOnGoTemplateUse> DbscriptsOnGoTemplateUses { get; set; }
    public DbSet<DbscriptsOnGossip> DbscriptsOnGossips { get; set; }
    public DbSet<DbscriptsOnQuestEnd> DbscriptsOnQuestEnds { get; set; }
    public DbSet<DbscriptsOnQuestStart> DbscriptsOnQuestStarts { get; set; }
    public DbSet<DbscriptsOnCreatureDeath> DbscriptsOnCreatureDeaths { get; set; }
    public DbSet<CreatureSpawnDataTemplate> CreatureSpawnDataTemplates { get; set; }
    public DbSet<SpawnGroup> SpawnGroups { get; set; }
    public DbSet<SpawnGroupEntry> SpawnGroupEntrys { get; set; }
    public DbSet<SpawnGroupLinkedGroup> SpawnGroupLinkedGroups { get; set; }
    public DbSet<Creature> Creatures { get; set; }
    public DbSet<GameObject> Gameobjects { get; set; }
    public DbSet<SpawnGroupSpawn> SpawnGroupSpawns { get; set; }
    public DbSet<DbVersion> DbVersions { get; set; }
    public DbSet<SpawnGroupFormation> SpawnGroupFormations { get; set; }
    public DbSet<WaypointPath> WaypointPaths { get; set; }
    public DbSet<CreatureMovement> CreatureMovements { get; set; }
    public DbSet<CreatureMovementTemplate> CreatureMovementTemplates { get; set; }
    public DbSet<ScriptWaypoint> ScriptWaypoints { get; set; }
}