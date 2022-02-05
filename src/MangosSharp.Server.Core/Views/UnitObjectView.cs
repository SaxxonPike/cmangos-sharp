using System;
using System.Collections.Concurrent;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public class UnitObjectView : ObjectView, IUnitObjectView
{
    public UnitObjectView() : this(new int[Fields.UNIT_END])
    {
    }

    public UnitObjectView(Memory<int> fields) : base(fields)
    {
        TypeMask |= TypeMask.UNIT;
    }

    public sealed override int GetValueForUpdate(int index)
    {
        return index switch
        {
            /* some values have different internal/external representations.. */
            >= Fields.PLAYER_FIELD_POSSTAT0 and < Fields.PLAYER_FIELD_MOD_DAMAGE_DONE_POS => 
                (int)GetFloat(index),
            >= Fields.UNIT_FIELD_BASEATTACKTIME and <= Fields.UNIT_FIELD_RANGEDATTACKTIME => 
                Math.Max(0, (int)GetFloat(index)),
            _ => base.GetValueForUpdate(index)
        };
    }

    public ObjectGuid Charm
    {
        get => GetLong(Fields.UNIT_FIELD_CHARM);
        set => SetLong(Fields.UNIT_FIELD_CHARM, value);
    }

    public ObjectGuid Summon
    {
        get => GetLong(Fields.UNIT_FIELD_SUMMON);
        set => SetLong(Fields.UNIT_FIELD_SUMMON, value);
    }

    public ObjectGuid CharmedBy
    {
        get => GetLong(Fields.UNIT_FIELD_CHARMEDBY);
        set => SetLong(Fields.UNIT_FIELD_CHARMEDBY, value);
    }

    public ObjectGuid SummonedBy
    {
        get => GetLong(Fields.UNIT_FIELD_SUMMONEDBY);
        set => SetLong(Fields.UNIT_FIELD_SUMMONEDBY, value);
    }

    public ObjectGuid CreatedBy
    {
        get => GetLong(Fields.UNIT_FIELD_CREATEDBY);
        set => SetLong(Fields.UNIT_FIELD_CREATEDBY, value);
    }

    public ObjectGuid Target
    {
        get => GetLong(Fields.UNIT_FIELD_TARGET);
        set => SetLong(Fields.UNIT_FIELD_TARGET, value);
    }

    public ObjectGuid Persuaded
    {
        get => GetLong(Fields.UNIT_FIELD_PERSUADED);
        set => SetLong(Fields.UNIT_FIELD_PERSUADED, value);
    }

    public ObjectGuid ChannelObject
    {
        get => GetLong(Fields.UNIT_FIELD_CHANNEL_OBJECT);
        set => SetLong(Fields.UNIT_FIELD_CHANNEL_OBJECT, value);
    }

    public int Health
    {
        get => GetInt(Fields.UNIT_FIELD_HEALTH);
        set => SetInt(Fields.UNIT_FIELD_HEALTH, value);
    }

    public Span<int> Powers => GetInts(Fields.UNIT_FIELD_POWER1, 5);

    public int MaxHealth
    {
        get => GetInt(Fields.UNIT_FIELD_MAXHEALTH);
        set => SetInt(Fields.UNIT_FIELD_MAXHEALTH, value);
    }

    public Span<int> MaxPowers => GetInts(Fields.UNIT_FIELD_MAXPOWER1, 5);

    public int Level
    {
        get => GetInt(Fields.UNIT_FIELD_LEVEL);
        set => SetInt(Fields.UNIT_FIELD_LEVEL, value);
    }

    public int FactionTemplate
    {
        get => GetInt(Fields.UNIT_FIELD_FACTIONTEMPLATE);
        set => SetInt(Fields.UNIT_FIELD_FACTIONTEMPLATE, value);
    }

    public byte Race
    {
        get => GetByte(Fields.UNIT_FIELD_BYTES_0, 0);
        set => SetByte(Fields.UNIT_FIELD_BYTES_0, 0, value);
    }

    public byte Class
    {
        get => GetByte(Fields.UNIT_FIELD_BYTES_0, 1);
        set => SetByte(Fields.UNIT_FIELD_BYTES_0, 1, value);
    }

    public Gender Gender
    {
        get => (Gender)GetByte(Fields.UNIT_FIELD_BYTES_0, 2);
        set => SetByte(Fields.UNIT_FIELD_BYTES_0, 2, (byte)value);
    }

    public PowerType PowerType
    {
        get => (PowerType)GetByte(Fields.UNIT_FIELD_BYTES_0, 3);
        set => SetByte(Fields.UNIT_FIELD_BYTES_0, 3, (byte)value);
    }

    public Span<int> VirtualItemSlotDisplay => GetInts(Fields.UNIT_VIRTUAL_ITEM_SLOT_DISPLAY, 3);

    public Span<int> VirtualItemInfo => GetInts(Fields.UNIT_VIRTUAL_ITEM_INFO, 6);

    public UnitFlags UnitFlags
    {
        get => (UnitFlags)GetInt(Fields.UNIT_FIELD_FLAGS);
        set => SetInt(Fields.UNIT_FIELD_FLAGS, (int)value);
    }

    public Span<int> Auras => GetInts(Fields.UNIT_FIELD_AURA, 48);

    public Span<int> AuraFlags => GetInts(Fields.UNIT_FIELD_AURAFLAGS, 6);

    public Span<int> AuraLevels => GetInts(Fields.UNIT_FIELD_AURALEVELS, 12);

    public Span<int> AuraApplications => GetInts(Fields.UNIT_FIELD_AURAAPPLICATIONS, 12);

    public int AuraState
    {
        get => GetInt(Fields.UNIT_FIELD_AURASTATE);
        set => SetInt(Fields.UNIT_FIELD_AURASTATE, value);
    }

    public int MainAttackTime
    {
        get => GetInt(Fields.UNIT_FIELD_BASEATTACKTIME);
        set => SetInt(Fields.UNIT_FIELD_BASEATTACKTIME, value);
    }

    public int OffAttackTime
    {
        get => GetInt(Fields.UNIT_FIELD_OFFHANDATTACKTIME);
        set => SetInt(Fields.UNIT_FIELD_OFFHANDATTACKTIME, value);
    }

    public int RangedAttackTime
    {
        get => GetInt(Fields.UNIT_FIELD_RANGEDATTACKTIME);
        set => SetInt(Fields.UNIT_FIELD_RANGEDATTACKTIME, value);
    }

    public float BoundingRadius
    {
        get => GetFloat(Fields.UNIT_FIELD_BOUNDINGRADIUS);
        set => SetFloat(Fields.UNIT_FIELD_BOUNDINGRADIUS, value);
    }

    public float CombatReach
    {
        get => GetFloat(Fields.UNIT_FIELD_COMBATREACH);
        set => SetFloat(Fields.UNIT_FIELD_COMBATREACH, value);
    }

    public int DisplayId
    {
        get => GetInt(Fields.UNIT_FIELD_DISPLAYID);
        set => SetInt(Fields.UNIT_FIELD_DISPLAYID, value);
    }

    public int NativeDisplayId
    {
        get => GetInt(Fields.UNIT_FIELD_NATIVEDISPLAYID);
        set => SetInt(Fields.UNIT_FIELD_NATIVEDISPLAYID, value);
    }

    public int MountDisplayId
    {
        get => GetInt(Fields.UNIT_FIELD_MOUNTDISPLAYID);
        set => SetInt(Fields.UNIT_FIELD_MOUNTDISPLAYID, value);
    }

    public float MinMainDamage
    {
        get => GetFloat(Fields.UNIT_FIELD_MINDAMAGE);
        set => SetFloat(Fields.UNIT_FIELD_MINDAMAGE, value);
    }

    public float MaxMainDamage
    {
        get => GetFloat(Fields.UNIT_FIELD_MAXDAMAGE);
        set => SetFloat(Fields.UNIT_FIELD_MAXDAMAGE, value);
    }

    public float MinOffDamage
    {
        get => GetFloat(Fields.UNIT_FIELD_MINOFFHANDDAMAGE);
        set => SetFloat(Fields.UNIT_FIELD_MINOFFHANDDAMAGE, value);
    }

    public float MaxOffDamage
    {
        get => GetFloat(Fields.UNIT_FIELD_MAXOFFHANDDAMAGE);
        set => SetFloat(Fields.UNIT_FIELD_MAXOFFHANDDAMAGE, value);
    }

    // public Span<byte> Bytes1 => GetBytes(Fields.UNIT_FIELD_BYTES_1, 1);

    public UnitStandStateType StandState
    {
        get => (UnitStandStateType)GetByte(Fields.UNIT_FIELD_BYTES_1, 0);
        set => SetByte(Fields.UNIT_FIELD_BYTES_1, 0, (byte)value);
    }

    public byte UnitFieldByte1_2
    {
        get => GetByte(Fields.UNIT_FIELD_BYTES_1, 1);
        set => SetByte(Fields.UNIT_FIELD_BYTES_1, 1, value);
    }

    public ShapeShiftForm ShapeShiftForm
    {
        get => (ShapeShiftForm)GetByte(Fields.UNIT_FIELD_BYTES_1, 2);
        set => SetByte(Fields.UNIT_FIELD_BYTES_1, 2, (byte)value);
    }

    public UnitFlags1 UnitFlags1
    {
        get => (UnitFlags1)GetByte(Fields.UNIT_FIELD_BYTES_1, 3);
        set => SetByte(Fields.UNIT_FIELD_BYTES_1, 3, (byte)value);
    }

    public int PetNumber
    {
        get => GetInt(Fields.UNIT_FIELD_PETNUMBER);
        set => SetInt(Fields.UNIT_FIELD_PETNUMBER, value);
    }

    public int PetNameTimestamp
    {
        get => GetInt(Fields.UNIT_FIELD_PET_NAME_TIMESTAMP);
        set => SetInt(Fields.UNIT_FIELD_PET_NAME_TIMESTAMP, value);
    }

    public int PetExperience
    {
        get => GetInt(Fields.UNIT_FIELD_PETEXPERIENCE);
        set => SetInt(Fields.UNIT_FIELD_PETEXPERIENCE, value);
    }

    public int PetNextLevelExperience
    {
        get => GetInt(Fields.UNIT_FIELD_PETNEXTLEVELEXP);
        set => SetInt(Fields.UNIT_FIELD_PETNEXTLEVELEXP, value);
    }

    public int DynFlags
    {
        get => GetInt(Fields.UNIT_DYNAMIC_FLAGS);
        set => SetInt(Fields.UNIT_DYNAMIC_FLAGS, value);
    }

    public int ChannelSpell
    {
        get => GetInt(Fields.UNIT_CHANNEL_SPELL);
        set => SetInt(Fields.UNIT_CHANNEL_SPELL, value);
    }

    public int ModCastSpeed
    {
        get => GetInt(Fields.UNIT_MOD_CAST_SPEED);
        set => SetInt(Fields.UNIT_MOD_CAST_SPEED, value);
    }

    public int CreatedBySpell
    {
        get => GetInt(Fields.UNIT_CREATED_BY_SPELL);
        set => SetInt(Fields.UNIT_CREATED_BY_SPELL, value);
    }

    public int NpcFlags
    {
        get => GetInt(Fields.UNIT_NPC_FLAGS);
        set => SetInt(Fields.UNIT_NPC_FLAGS, value);
    }

    public int NpcEmoteState
    {
        get => GetInt(Fields.UNIT_NPC_EMOTESTATE);
        set => SetInt(Fields.UNIT_NPC_EMOTESTATE, value);
    }

    public Span<short> TrainingPoints => GetShorts(Fields.UNIT_TRAINING_POINTS, 2);

    public Span<int> Stats => GetInts(Fields.UNIT_FIELD_STAT0, 5);

    public Span<int> Resistances => GetInts(Fields.UNIT_FIELD_RESISTANCES, 7);

    public int BaseMana
    {
        get => GetInt(Fields.UNIT_FIELD_BASE_MANA);
        set => SetInt(Fields.UNIT_FIELD_BASE_MANA, value);
    }

    public int BaseHealth
    {
        get => GetInt(Fields.UNIT_FIELD_BASE_HEALTH);
        set => SetInt(Fields.UNIT_FIELD_BASE_HEALTH, value);
    }

    public SheathState SheathState
    {
        get => (SheathState)GetByte(Fields.UNIT_FIELD_BYTES_2, 0);
        set => SetByte(Fields.UNIT_FIELD_BYTES_2, 0, (byte)value);
    }

    public UnitFlags2 UnitFlags2
    {
        get => (UnitFlags2)GetByte(Fields.UNIT_FIELD_BYTES_2, 1);
        set => SetByte(Fields.UNIT_FIELD_BYTES_2, 1, (byte)value);
    }

    public int MeleeAttackPower
    {
        get => GetInt(Fields.UNIT_FIELD_ATTACK_POWER);
        set => SetInt(Fields.UNIT_FIELD_ATTACK_POWER, value);
    }

    public Span<short> MeleeAttackPowerModifiers => GetShorts(Fields.UNIT_FIELD_ATTACK_POWER_MODS, 2);

    public float MeleeAttackPowerMultiplier
    {
        get => GetFloat(Fields.UNIT_FIELD_ATTACK_POWER_MULTIPLIER);
        set => SetFloat(Fields.UNIT_FIELD_ATTACK_POWER_MULTIPLIER, value);
    }

    public int RangedAttackPower
    {
        get => GetInt(Fields.UNIT_FIELD_RANGED_ATTACK_POWER);
        set => SetInt(Fields.UNIT_FIELD_RANGED_ATTACK_POWER, value);
    }

    public Span<short> RangedAttackPowerModifiers => GetShorts(Fields.UNIT_FIELD_RANGED_ATTACK_POWER_MODS, 2);

    public float RangedAttackPowerMultiplier
    {
        get => GetFloat(Fields.UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER);
        set => SetFloat(Fields.UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER, value);
    }

    public float MinRangedDamage
    {
        get => GetFloat(Fields.UNIT_FIELD_MINRANGEDDAMAGE);
        set => SetFloat(Fields.UNIT_FIELD_MINRANGEDDAMAGE, value);
    }

    public float MaxRangedDamage
    {
        get => GetFloat(Fields.UNIT_FIELD_MAXRANGEDDAMAGE);
        set => SetFloat(Fields.UNIT_FIELD_MAXRANGEDDAMAGE, value);
    }

    public Span<int> PowerCostModifiers => GetInts(Fields.UNIT_FIELD_POWER_COST_MODIFIER, 7);

    public Span<int> PowerCostMultipliers => GetInts(Fields.UNIT_FIELD_POWER_COST_MULTIPLIER, 7);

    // These are handled separately.

    public override IMovementView Movement { get; } = new MovementView();

    public override IMovementSpeedView Speed { get; } = new MovementSpeedView();

    public override ILocationView Location => Movement.Location;

    public int TemplateId { get; set; }

    public UnitState UnitState { get; set; }

    public string Name { get; set; }

    public string SubName { get; set; }

    public int Civilian { get; set; }
    
    public int RacialLeader { get; set; }
    
    public int Rank { get; set; }
    
    public CreatureTypeFlags CreatureTypeFlags { get; set; }
    
    public int CreatureTypeId { get; set; }

    public ConcurrentDictionary<ObjectGuid, int> ThreatGuids { get; } = new();

    public override UpdateFlags UpdateFlags => UpdateFlags.ALL | UpdateFlags.LIVING | UpdateFlags.HAS_POSITION;
}