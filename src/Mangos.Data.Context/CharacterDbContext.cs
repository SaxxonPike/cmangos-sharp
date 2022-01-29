using Mangos.Data.Entities.CharacterDatabase;
using Microsoft.EntityFrameworkCore;
using Auction = Mangos.Data.Entities.CharacterDatabase.Auction;
using BugReport = Mangos.Data.Entities.CharacterDatabase.BugReport;

namespace Mangos.Data.Context;

public class ClassiccharactersDbContext : DbContext
{
    public ClassiccharactersDbContext() {}
    public ClassiccharactersDbContext(DbContextOptions options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CharacterDbVersion>().HasKey(e => new { required_z2775_01_characters_raf = e.RequiredZ277501CharactersRaf });
        builder.Entity<AhBotItems>().HasKey(e => new { item = e.Item });
        builder.Entity<AccountInstanceEntered>().HasKey(e => new { e.AccountId, e.InstanceId });
        builder.Entity<Auction>().HasKey(e => new { id = e.Id });
        builder.Entity<BugReport>().HasKey(e => new { id = e.Id });
        builder.Entity<CharacterAction>().HasKey(e => new { guid = e.Guid, button = e.Button });
        builder.Entity<CharacterAura>().HasKey(e => new { guid = e.Guid, caster_guid = e.CasterGuid, item_guid = e.ItemGuid, spell = e.Spell });
        builder.Entity<CharacterBattlegroundData>().HasKey(e => new { guid = e.Guid });
        builder.Entity<CharacterGift>().HasKey(e => new { guid = e.Guid, item_guid = e.ItemGuid });
        builder.Entity<CharacterHomebind>().HasKey(e => new { guid = e.Guid });
        builder.Entity<CharacterHonorCp>().HasKey(e => new { guid = e.Guid });
        builder.Entity<CharacterInstance>().HasKey(e => new { guid = e.Guid, instance = e.Instance });
        builder.Entity<CharacterInventory>().HasKey(e => new { guid = e.Guid, item = e.Item });
        builder.Entity<CharacterPet>().HasKey(e => new { id = e.Id });
        builder.Entity<CharacterQuestStatus>().HasKey(e => new { guid = e.Guid, quest = e.Quest });
        builder.Entity<CharacterQuestStatusWeekly>().HasKey(e => new { guid = e.Guid, quest = e.Quest });
        builder.Entity<CharacterReputation>().HasKey(e => new { guid = e.Guid, faction = e.Faction });
        builder.Entity<CharacterSkill>().HasKey(e => new { guid = e.Guid, skill = e.Skill });
        builder.Entity<CharacterSocial>().HasKey(e => new { guid = e.Guid, friend = e.Friend, flags = e.Flags });
        builder.Entity<CharacterSpell>().HasKey(e => new { guid = e.Guid, spell = e.Spell });
        builder.Entity<CharacterSpellCooldown>().HasKey(e => new { guid = e.Guid, e.SpellId });
        builder.Entity<CharacterStat>().HasKey(e => new { guid = e.Guid });
        builder.Entity<CharacterTutorial>().HasKey(e => new { account = e.Account });
        builder.Entity<Character>().HasKey(e => new { guid = e.Guid });
        builder.Entity<Corpse>().HasKey(e => new { guid = e.Guid });
        builder.Entity<CreatureRespawn>().HasKey(e => new { guid = e.Guid, instance = e.Instance });
        builder.Entity<GameEventStatus>().HasKey(e => new { e.Event });
        builder.Entity<GmTicket>().HasKey(e => new { id = e.Id });
        builder.Entity<GmSurvey>().HasKey(e => new { ticketid = e.Ticketid });
        builder.Entity<GameObjectRespawn>().HasKey(e => new { guid = e.Guid, instance = e.Instance });
        builder.Entity<GroupInstance>().HasKey(e => new { leaderGuid = e.LeaderGuid, instance = e.Instance });
        builder.Entity<GroupMember>().HasKey(e => new { groupId = e.GroupId, memberGuid = e.MemberGuid });
        builder.Entity<Group>().HasKey(e => new { groupId = e.GroupId });
        builder.Entity<Guild>().HasKey(e => new { guildid = e.Guildid });
        builder.Entity<GuildEventLog>().HasKey(e => new { guildid = e.Guildid, e.LogGuid });
        builder.Entity<GuildMember>().HasKey(e => new { guildid = e.Guildid, guid = e.Guid });
        builder.Entity<GuildRank>().HasKey(e => new { guildid = e.Guildid, rid = e.Rid });
        builder.Entity<Instance>().HasKey(e => new { id = e.Id });
        builder.Entity<InstanceReset>().HasKey(e => new { mapid = e.Mapid });
        builder.Entity<ItemInstance>().HasKey(e => new { guid = e.Guid });
        builder.Entity<ItemLoot>().HasKey(e => new { guid = e.Guid, itemid = e.Itemid });
        builder.Entity<ItemText>().HasKey(e => new { id = e.Id });
        builder.Entity<Mail>().HasKey(e => new { id = e.Id });
        builder.Entity<MailItems>().HasKey(e => new { mail_id = e.MailId, item_guid = e.ItemGuid });
        builder.Entity<PetAura>().HasKey(e => new { guid = e.Guid, caster_guid = e.CasterGuid, item_guid = e.ItemGuid, spell = e.Spell });
        builder.Entity<PetSpell>().HasKey(e => new { guid = e.Guid, spell = e.Spell });
        builder.Entity<PetSpellCooldown>().HasKey(e => new { guid = e.Guid, spell = e.Spell });
        builder.Entity<Petition>().HasKey(e => new { ownerguid = e.Ownerguid });
        builder.Entity<PetitionSign>().HasKey(e => new { ownerguid = e.Ownerguid, petitionguid = e.Petitionguid, playerguid = e.Playerguid });
        builder.Entity<PlayerBotSavedData>().HasKey(e => new { guid = e.Guid });
        builder.Entity<PvpStatBattleground>().HasKey(e => new { id = e.Id });
        builder.Entity<PvpStatPlayer>().HasKey(e => new { battleground_id = e.BattlegroundId, character_guid = e.CharacterGuid });
        builder.Entity<SavedVariable>().HasKey(e => new { e.NextWeeklyQuestResetTime });
        builder.Entity<World>().HasKey(e => new { map = e.Map });
        builder.Entity<WorldState>().HasKey(e => new { e.Id });
    }

    public DbSet<CharacterDbVersion> CharacterDbVersions { get; set; }
    public DbSet<AhBotItems> AhbotItemss { get; set; }
    public DbSet<AccountInstanceEntered> AccountInstancesEntereds { get; set; }
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<BugReport> Bugreports { get; set; }
    public DbSet<CharacterAction> CharacterActions { get; set; }
    public DbSet<CharacterAura> CharacterAuras { get; set; }
    public DbSet<CharacterBattlegroundData> CharacterBattlegroundDatas { get; set; }
    public DbSet<CharacterGift> CharacterGiftss { get; set; }
    public DbSet<CharacterHomebind> CharacterHomebinds { get; set; }
    public DbSet<CharacterHonorCp> CharacterHonorCps { get; set; }
    public DbSet<CharacterInstance> CharacterInstances { get; set; }
    public DbSet<CharacterInventory> CharacterInventorys { get; set; }
    public DbSet<CharacterPet> CharacterPets { get; set; }
    public DbSet<CharacterQuestStatus> CharacterQueststatuss { get; set; }
    public DbSet<CharacterQuestStatusWeekly> CharacterQueststatusWeeklys { get; set; }
    public DbSet<CharacterReputation> CharacterReputations { get; set; }
    public DbSet<CharacterSkill> CharacterSkillss { get; set; }
    public DbSet<CharacterSocial> CharacterSocials { get; set; }
    public DbSet<CharacterSpell> CharacterSpells { get; set; }
    public DbSet<CharacterSpellCooldown> CharacterSpellCooldowns { get; set; }
    public DbSet<CharacterStat> CharacterStatss { get; set; }
    public DbSet<CharacterTutorial> CharacterTutorials { get; set; }
    public DbSet<Character> Characterss { get; set; }
    public DbSet<Corpse> Corpses { get; set; }
    public DbSet<CreatureRespawn> CreatureRespawns { get; set; }
    public DbSet<GameEventStatus> GameEventStatuss { get; set; }
    public DbSet<GmTicket> GmTicketss { get; set; }
    public DbSet<GmSurvey> GmSurveyss { get; set; }
    public DbSet<GameObjectRespawn> GameobjectRespawns { get; set; }
    public DbSet<GroupInstance> GroupInstances { get; set; }
    public DbSet<GroupMember> GroupMembers { get; set; }
    public DbSet<Group> Groupss { get; set; }
    public DbSet<Guild> Guilds { get; set; }
    public DbSet<GuildEventLog> GuildEventlogs { get; set; }
    public DbSet<GuildMember> GuildMembers { get; set; }
    public DbSet<GuildRank> GuildRanks { get; set; }
    public DbSet<Instance> Instances { get; set; }
    public DbSet<InstanceReset> InstanceResets { get; set; }
    public DbSet<ItemInstance> ItemInstances { get; set; }
    public DbSet<ItemLoot> ItemLoots { get; set; }
    public DbSet<ItemText> ItemTexts { get; set; }
    public DbSet<Mail> Mails { get; set; }
    public DbSet<MailItems> MailItemss { get; set; }
    public DbSet<PetAura> PetAuras { get; set; }
    public DbSet<PetSpell> PetSpells { get; set; }
    public DbSet<PetSpellCooldown> PetSpellCooldowns { get; set; }
    public DbSet<Petition> Petitions { get; set; }
    public DbSet<PetitionSign> PetitionSigns { get; set; }
    public DbSet<PlayerBotSavedData> PlayerbotSavedDatas { get; set; }
    public DbSet<PvpStatBattleground> PvpstatsBattlegroundss { get; set; }
    public DbSet<PvpStatPlayer> PvpstatsPlayerss { get; set; }
    public DbSet<SavedVariable> SavedVariabless { get; set; }
    public DbSet<World> Worlds { get; set; }
    public DbSet<WorldState> WorldStates { get; set; }
}
