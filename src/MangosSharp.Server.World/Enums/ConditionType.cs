namespace MangosSharp.Server.World.Enums;

public enum ConditionType
{
    //                                                      // value1       value2  for the Condition enumed
    CONDITION_NOT                   = -3,                   // cond-id-1    0          returns !cond-id-1
    CONDITION_OR                    = -2,                   // cond-id-1    cond-id-2  returns cond-id-1 OR cond-id-2
    CONDITION_AND                   = -1,                   // cond-id-1    cond-id-2  returns cond-id-1 AND cond-id-2
    CONDITION_NONE                  = 0,                    // 0            0
    CONDITION_AURA                  = 1,                    // spell_id     effindex
    CONDITION_ITEM                  = 2,                    // item_id      count   check present req. amount items in inventory
    CONDITION_ITEM_EQUIPPED         = 3,                    // item_id      0
    CONDITION_AREAID                = 4,                    // area_id      0, 1 (0: in (sub)area, 1: not in (sub)area)
    CONDITION_REPUTATION_RANK_MIN   = 5,                    // faction_id   min_rank
    CONDITION_TEAM                  = 6,                    // player_team  0,      (469 - Alliance 67 - Horde)
    CONDITION_SKILL                 = 7,                    // skill_id     skill_value
    CONDITION_QUESTREWARDED         = 8,                    // quest_id     0
    CONDITION_QUESTTAKEN            = 9,                    // quest_id     0,1,2   for condition true while quest active (0 any state, 1 if quest incomplete, 2 if quest completed).
    CONDITION_AD_COMMISSION_AURA    = 10,                   // 0            0,      for condition true while one from AD commission aura active
    CONDITION_UNUSED_1              = 11,
    CONDITION_ACTIVE_GAME_EVENT     = 12,                   // event_id     0
    CONDITION_AREA_FLAG             = 13,                   // area_flag    area_flag_not
    CONDITION_RACE_CLASS            = 14,                   // race_mask    class_mask
    CONDITION_LEVEL                 = 15,                   // level        0, 1 or 2 (0: equal to, 1: equal or higher than, 2: equal or less than)
    CONDITION_UNUSED_2              = 16,
    CONDITION_SPELL                 = 17,                   // spell_id     0, 1 (0: has spell, 1: hasn't spell)
    CONDITION_INSTANCE_SCRIPT       = 18,                   // map_id       instance_condition_id (instance script specific enum)
    CONDITION_QUESTAVAILABLE        = 19,                   // quest_id     0       for case when loot/gossip possible only if player can start quest
    CONDITION_RESERVED_1            = 20,                   // reserved for 3.x and later
    CONDITION_RESERVED_2            = 21,                   // reserved for 3.x and later
    CONDITION_QUEST_NONE            = 22,                   // quest_id     0 (quest did not take and not rewarded)
    CONDITION_ITEM_WITH_BANK        = 23,                   // item_id      count   check present req. amount items in inventory or bank
    CONDITION_UNUSED_3              = 24,
    CONDITION_UNUSED_4              = 25,
    CONDITION_ACTIVE_HOLIDAY        = 26,                   // holiday_id   0       preferred use instead CONDITION_ACTIVE_GAME_EVENT when possible
    CONDITION_UNUSED_5              = 27,
    CONDITION_LEARNABLE_ABILITY     = 28,                   // spell_id     0 or item_id
                                                            // True when player can learn ability (using min skill value from SkillLineAbility).
                                                            // Item_id can be defined in addition, to check if player has one (1) item in inventory or bank.
                                                            // When player has spell or has item (when defined), condition return false.
    CONDITION_SKILL_BELOW           = 29,                   // skill_id     skill_value
                                                            // True if player has skill skill_id and skill less than (and not equal) skill_value (for skill_value > 1)
                                                            // If skill_value == 1, then true if player has not skill skill_id
    CONDITION_REPUTATION_RANK_MAX   = 30,                   // faction_id   max_rank
    CONDITION_COMPLETED_ENCOUNTER   = 31,                   // encounter_id encounter_id2       encounter_id[2] = DungeonEncounter(dbc).id (if value2 provided it will return value1 OR value2)
    CONDITION_UNUSED_6              = 32,
    CONDITION_LAST_WAYPOINT         = 33,                   // waypointId   0 = exact, 1: wp <= waypointId, 2: wp > waypointId  Use to check what waypoint was last reached
    CONDITION_RESERVED_4            = 34,                   // reserved for 3.x and later
    CONDITION_GENDER                = 35,                   // 0=male, 1=female, 2=none (see enum Gender)
    CONDITION_DEAD_OR_AWAY          = 36,                   // value1: 0=player dead, 1=player is dead (with group dead), 2=player in instance are dead, 3=creature is dead
                                                            // value2: if != 0 only consider players in range of this value
    CONDITION_CREATURE_IN_RANGE     = 37,                   // value1: creature entry; value2: range; returns only alive creatures
    CONDITION_PVP_SCRIPT            = 38,                   // value1: zoneId; value2: conditionId;
    CONDITION_SPAWN_COUNT           = 39,                   // value1: creatureId; value2: count;
    CONDITION_WORLD_SCRIPT          = 40,
    CONDITION_UNUSED_7              = 41,
    
}

public enum ConditionFlag
{
    CONDITION_FLAG_REVERSE_RESULT = 0x1,
    CONDITION_FLAG_SWAP_TARGETS   = 0x2
}

public enum ConditionSource
{
    CONDITION_FROM_LOOT                 = 0,                    // Used to check a *_loot_template entry
    CONDITION_FROM_REFERING_LOOT        = 1,                    // Used to check a entry refering to a reference_loot_template entry
    CONDITION_FROM_GOSSIP_MENU          = 2,                    // Used to check a gossip menu menu-text
    CONDITION_FROM_GOSSIP_OPTION        = 3,                    // Used to check a gossip menu option-item
    CONDITION_FROM_EVENTAI              = 4,                    // Used to check EventAI Event "On Receive Emote"
    CONDITION_FROM_HARDCODED            = 5,                    // Used to check a hardcoded event - not actually a condition
    CONDITION_FROM_VENDOR               = 6,                    // Used to check a condition from a vendor
    CONDITION_FROM_SPELL_AREA           = 7,                    // Used to check a condition from spell_area table
    CONDITION_FROM_RESERVED_1           = 8,                    // reserved for 3.x and later
    CONDITION_FROM_DBSCRIPTS            = 9,                    // Used to check a condition from DB Scripts Engine
    CONDITION_FROM_TRAINER              = 10,                   // Used to check a condition from npc_trainer and npc_trainer_template
    CONDITION_FROM_AREATRIGGER_TELEPORT = 11,                   // Used to check a condition from areatrigger_teleport
    CONDITION_FROM_QUEST                = 12,                   // Used to check a condition from quest_template
}

public enum ConditionRequirement
{
    CONDITION_REQ_NONE,
    CONDITION_REQ_TARGET_WORLDOBJECT,
    CONDITION_REQ_TARGET_GAMEOBJECT,
    CONDITION_REQ_TARGET_UNIT,
    CONDITION_REQ_TARGET_CREATURE,
    CONDITION_REQ_TARGET_PLAYER,
    CONDITION_REQ_SOURCE_WORLDOBJECT,
    CONDITION_REQ_SOURCE_GAMEOBJECT,
    CONDITION_REQ_SOURCE_UNIT,
    CONDITION_REQ_SOURCE_CREATURE,
    CONDITION_REQ_SOURCE_PLAYER,
    CONDITION_REQ_ANY_WORLDOBJECT,
    CONDITION_REQ_MAP_OR_WORLDOBJECT,
    CONDITION_REQ_BOTH_WORLDOBJECTS,
    CONDITION_REQ_BOTH_GAMEOBJECTS,
    CONDITION_REQ_BOTH_UNITS,
    CONDITION_REQ_BOTH_PLAYERS,    
}