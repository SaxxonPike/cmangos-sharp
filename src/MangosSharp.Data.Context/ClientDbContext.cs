using System;
using System.IO;
using System.Linq;
using System.Reflection;
using MangosSharp.Data.Entities;
using MangosSharp.Data.Entities.ClientDatabase;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

#pragma warning disable CA1822
// ReSharper disable ReturnTypeCanBeEnumerable.Global
// ReSharper disable MemberCanBeMadeStatic.Global

namespace MangosSharp.Data.Context;

/// <summary>
/// Database where DBC tables are stored.
/// 
/// ClientDbContext is not actually derivative of DbContext at all, because it does not use Entity Framework in order
/// to perform operations. We parse DBC on our own and fully cache the tables we load.
/// </summary>
public sealed class ClientDbContext : IDisposable
{
    private readonly ILogger _logger;
    private readonly IMemoryCache _memoryCache;

    public ClientDbContext(ILogger logger, IMemoryCache memoryCache)
    {
        _logger = logger;
        _memoryCache = memoryCache;
    }
    
    private IQueryable<TEntity> Set<TEntity>()
    {
        return _memoryCache.GetOrCreate(typeof(TEntity), _ =>
        {
            var file = typeof(TEntity).GetCustomAttribute<DbcTableAttribute>();
            if (file == default)
                return new EnumerableQuery<TEntity>(Enumerable.Empty<TEntity>());

            var filePath = Path.Combine("dbc", $"{file.Name}.dbc");
            _logger.LogInformation("Caching DBC name={} path={}", file.Name, filePath);
            using var stream = File.OpenRead(filePath);

            var data = new DbcFile(stream).ToList<TEntity>();
            var result = new EnumerableQuery<TEntity>(data);
            return result;
        });
    }

    public IQueryable<Area> Areas => Set<Area>();
    public IQueryable<AreaTrigger> AreaTriggers => Set<AreaTrigger>();
    public IQueryable<AuctionHouse> AuctionHouses => Set<AuctionHouse>();
    public IQueryable<BankBagSlotPrice> BankBagSlotPrices => Set<BankBagSlotPrice>();
    public IQueryable<CharacterClass> CharacterClasses => Set<CharacterClass>();
    public IQueryable<CharacterRace> CharacterRaces => Set<CharacterRace>();
    public IQueryable<CharacterSection> CharacterSections => Set<CharacterSection>();
    public IQueryable<CharacterStartingOutfit> CharacterStartingOutfits => Set<CharacterStartingOutfit>();
    public IQueryable<ChatChannel> ChatChannels => Set<ChatChannel>();
    public IQueryable<CinematicSequence> CinematicSequences => Set<CinematicSequence>();
    public IQueryable<CreatureDisplayInfo> CreatureDisplayInfos => Set<CreatureDisplayInfo>();
    public IQueryable<CreatureDisplayInfoExtra> CreatureDisplayInfoExtras => Set<CreatureDisplayInfoExtra>();
    public IQueryable<CreatureFamily> CreatureFamilies => Set<CreatureFamily>();
    public IQueryable<CreatureSpellData> CreatureSpellDatas => Set<CreatureSpellData>();
    public IQueryable<CreatureType> CreatureTypes => Set<CreatureType>();
    public IQueryable<DurabilityCost> DurabilityCosts => Set<DurabilityCost>();
    public IQueryable<DurabilityQuality> DurabilityQualities => Set<DurabilityQuality>();
    public IQueryable<Emote> Emotes => Set<Emote>();
    public IQueryable<EmoteText> EmoteTexts => Set<EmoteText>();
    public IQueryable<Faction> Factions => Set<Faction>();
    public IQueryable<FactionTemplate> FactionTemplates => Set<FactionTemplate>();
    public IQueryable<GameObjectDisplayInfo> GameObjectDisplayInfos => Set<GameObjectDisplayInfo>();
    public IQueryable<ItemBagFamily> ItemBagFamilies => Set<ItemBagFamily>();
    public IQueryable<ItemClass> ItemClasses => Set<ItemClass>();
    public IQueryable<ItemDisplayInfo> ItemDisplayInfos => Set<ItemDisplayInfo>();
    public IQueryable<ItemRandomProperty> ItemRandomProperties => Set<ItemRandomProperty>();
    public IQueryable<ItemSet> ItemSets => Set<ItemSet>();
    public IQueryable<LiquidType> LiquidTypes => Set<LiquidType>();
    public IQueryable<Lock> Locks => Set<Lock>();
    public IQueryable<MailTemplate> MailTemplates => Set<MailTemplate>();
    public IQueryable<Map> Maps => Set<Map>();
    public IQueryable<QuestSort> QuestSorts => Set<QuestSort>();
    public IQueryable<SkillLine> SkillLines => Set<SkillLine>();
    public IQueryable<SkillLineAbility> SkillLineAbilities => Set<SkillLineAbility>();
    public IQueryable<SkillRaceClass> SkillRaceClasses => Set<SkillRaceClass>();
    public IQueryable<SoundEntry> SoundEntries => Set<SoundEntry>();
    public IQueryable<Spell> Spells => Set<Spell>();
    public IQueryable<SpellCastTime> SpellCastTimes => Set<SpellCastTime>();
    public IQueryable<SpellDuration> SpellDurations => Set<SpellDuration>();
    public IQueryable<SpellFocusObject> SpellFocusObjects => Set<SpellFocusObject>();
    public IQueryable<SpellItemEnchantment> SpellItemEnchantments => Set<SpellItemEnchantment>();
    public IQueryable<SpellRadius> SpellRadii => Set<SpellRadius>();
    public IQueryable<SpellRange> SpellRanges => Set<SpellRange>();
    public IQueryable<SpellShapeshiftForm> SpellShapeshiftForms => Set<SpellShapeshiftForm>();
    public IQueryable<StableSlotPrice> StableSlotPrices => Set<StableSlotPrice>();
    public IQueryable<Talent> Talents => Set<Talent>();
    public IQueryable<TalentTab> TalentTabs => Set<TalentTab>();
    public IQueryable<TaxiNode> TaxiNodes => Set<TaxiNode>();
    public IQueryable<TaxiPath> TaxiPaths => Set<TaxiPath>();
    public IQueryable<TaxiPathNode> TaxiPathNodes => Set<TaxiPathNode>();
    public IQueryable<WmoArea> WmoAreas => Set<WmoArea>();
    public IQueryable<WorldMapArea> WorldMapAreas => Set<WorldMapArea>();
    public IQueryable<WorldSafeLoc> WorldSafeLocs => Set<WorldSafeLoc>();

    public void Dispose()
    {
        // Nothing needed here yet.
    }
}