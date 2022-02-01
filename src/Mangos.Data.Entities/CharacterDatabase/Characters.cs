using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("characters")]
public class Characters
{
    /* Account Identifier */
    [Column("account", TypeName="int")]
    public virtual uint Account { get; set; }

    [Column("actionBars", TypeName="tinyint")]
    public virtual byte ActionBars { get; set; }

    [Column("ammoId", TypeName="int")]
    public virtual uint AmmoId { get; set; }

    [Column("at_login", TypeName="int")]
    public virtual uint AtLogin { get; set; }

    [Column("cinematic", TypeName="tinyint")]
    public virtual byte Cinematic { get; set; }

    [Column("Class", TypeName="tinyint")]
    public virtual byte Class { get; set; }

    [Column("death_expire_time", TypeName="bigint")]
    public virtual ulong DeathExpireTime { get; set; }

    [Column("deleteDate", TypeName="bigint")]
    public virtual ulong DeleteDate { get; set; }

    [Column("deleteInfos_Account", TypeName="int")]
    public virtual uint DeleteInfosAccount { get; set; }

    [Column("deleteInfos_Name")]
    [MaxLength(12)]
    public virtual string DeleteInfosName { get; set; }

    [Column("drunk", TypeName="smallint")]
    public virtual ushort Drunk { get; set; }

    [Column("equipmentCache", TypeName="longtext")]
    public virtual string EquipmentCache { get; set; }

    [Column("exploredZones", TypeName="longtext")]
    public virtual string ExploredZones { get; set; }

    [Column("extra_flags", TypeName="int")]
    public virtual uint ExtraFlags { get; set; }

    [Column("gender", TypeName="tinyint")]
    public virtual byte Gender { get; set; }

    [Column("grantableLevels", TypeName="int")]
    public virtual uint GrantableLevels { get; set; }

    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("health", TypeName="int")]
    public virtual uint Health { get; set; }

    [Column("honor_highest_rank", TypeName="int")]
    public virtual uint HonorHighestRank { get; set; }

    [Column("honor_standing", TypeName="int")]
    public virtual uint HonorStanding { get; set; }

    [Column("is_logout_resting", TypeName="tinyint")]
    public virtual byte IsLogoutResting { get; set; }

    [Column("level", TypeName="tinyint")]
    public virtual byte Level { get; set; }

    [Column("leveltime", TypeName="int")]
    public virtual uint Leveltime { get; set; }

    [Column("logout_time", TypeName="bigint")]
    public virtual ulong LogoutTime { get; set; }

    /* Map Identifier */
    [Column("map", TypeName="int")]
    public virtual uint Map { get; set; }

    [Column("money", TypeName="int")]
    public virtual uint Money { get; set; }

    [Column("name")]
    [MaxLength(12)]
    public virtual string Name { get; set; }

    [Column("online", TypeName="tinyint")]
    public virtual byte Online { get; set; }

    [Column("orientation", TypeName="float")]
    public virtual float Orientation { get; set; }

    [Column("playerBytes", TypeName="int")]
    public virtual uint PlayerBytes { get; set; }

    [Column("playerBytes2", TypeName="int")]
    public virtual uint PlayerBytes2 { get; set; }

    [Column("playerFlags", TypeName="int")]
    public virtual uint PlayerFlags { get; set; }

    [Column("position_x", TypeName="float")]
    public virtual float PositionX { get; set; }

    [Column("position_y", TypeName="float")]
    public virtual float PositionY { get; set; }

    [Column("position_z", TypeName="float")]
    public virtual float PositionZ { get; set; }

    [Column("power1", TypeName="int")]
    public virtual uint Power1 { get; set; }

    [Column("power2", TypeName="int")]
    public virtual uint Power2 { get; set; }

    [Column("power3", TypeName="int")]
    public virtual uint Power3 { get; set; }

    [Column("power4", TypeName="int")]
    public virtual uint Power4 { get; set; }

    [Column("power5", TypeName="int")]
    public virtual uint Power5 { get; set; }

    [Column("race", TypeName="tinyint")]
    public virtual byte Race { get; set; }

    [Column("resettalents_cost", TypeName="int")]
    public virtual uint ResettalentsCost { get; set; }

    [Column("resettalents_time", TypeName="bigint")]
    public virtual ulong ResettalentsTime { get; set; }

    [Column("rest_bonus", TypeName="float")]
    public virtual float RestBonus { get; set; }

    [Column("stable_slots", TypeName="tinyint")]
    public virtual byte StableSlots { get; set; }

    [Column("stored_dishonorable_kills", TypeName="int")]
    public virtual int StoredDishonorableKills { get; set; }

    [Column("stored_honor_rating", TypeName="float")]
    public virtual float StoredHonorRating { get; set; }

    [Column("stored_honorable_kills", TypeName="int")]
    public virtual int StoredHonorableKills { get; set; }

    [Column("taxi_path", TypeName="text")]
    [MaxLength(65535)]
    public virtual string TaxiPath { get; set; }

    [Column("taximask", TypeName="longtext")]
    public virtual string Taximask { get; set; }

    [Column("totaltime", TypeName="int")]
    public virtual uint Totaltime { get; set; }

    [Column("trans_o", TypeName="float")]
    public virtual float TransO { get; set; }

    [Column("trans_x", TypeName="float")]
    public virtual float TransX { get; set; }

    [Column("trans_y", TypeName="float")]
    public virtual float TransY { get; set; }

    [Column("trans_z", TypeName="float")]
    public virtual float TransZ { get; set; }

    [Column("transguid", TypeName="bigint")]
    public virtual ulong Transguid { get; set; }

    [Column("watchedFaction", TypeName="int")]
    public virtual uint WatchedFaction { get; set; }

    [Column("xp", TypeName="int")]
    public virtual uint Xp { get; set; }

    [Column("zone", TypeName="int")]
    public virtual uint Zone { get; set; }

}