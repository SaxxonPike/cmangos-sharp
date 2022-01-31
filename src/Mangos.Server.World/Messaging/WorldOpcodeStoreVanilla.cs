namespace Mangos.Server.World.Messaging;

public static class WorldOpcodeStoreVanilla
{
    public static void Install(IWorldOpcodeGateway gateway)
    {
        gateway.ConfigureOpcodes(0x424);
        
        /// Correspondence between opcodes and their names
        /*0x000*/
        gateway.StoreOpcode(WorldOpcode.MSG_NULL_ACTION, "MSG_NULL_ACTION", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x001*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BOOTME, "CMSG_BOOTME", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x002*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DBLOOKUP, "CMSG_DBLOOKUP", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x003*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DBLOOKUP, "SMSG_DBLOOKUP", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x004*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUERY_OBJECT_POSITION, "CMSG_QUERY_OBJECT_POSITION", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x005*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUERY_OBJECT_POSITION, "SMSG_QUERY_OBJECT_POSITION", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x006*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUERY_OBJECT_ROTATION, "CMSG_QUERY_OBJECT_ROTATION", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x007*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUERY_OBJECT_ROTATION, "SMSG_QUERY_OBJECT_ROTATION", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x008*/
        gateway.StoreOpcode(WorldOpcode.CMSG_WORLD_TELEPORT, "CMSG_WORLD_TELEPORT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleWorldTeleportOpcode);
        /*0x009*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TELEPORT_TO_UNIT, "CMSG_TELEPORT_TO_UNIT", SessionStatus.LOGGEDIN,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x00A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ZONE_MAP, "CMSG_ZONE_MAP", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x00B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ZONE_MAP, "SMSG_ZONE_MAP", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x00C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DEBUG_CHANGECELLZONE, "CMSG_DEBUG_CHANGECELLZONE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x00D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_EMBLAZON_TABARD_OBSOLETE, "CMSG_EMBLAZON_TABARD_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x00E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_UNEMBLAZON_TABARD_OBSOLETE, "CMSG_UNEMBLAZON_TABARD_OBSOLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x00F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_RECHARGE, "CMSG_RECHARGE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x010*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LEARN_SPELL, "CMSG_LEARN_SPELL", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x011*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CREATEMONSTER, "CMSG_CREATEMONSTER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x012*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DESTROYMONSTER, "CMSG_DESTROYMONSTER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x013*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CREATEITEM, "CMSG_CREATEITEM", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x014*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CREATEGAMEOBJECT, "CMSG_CREATEGAMEOBJECT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x015*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHECK_FOR_BOTS, "SMSG_CHECK_FOR_BOTS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x016*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MAKEMONSTERATTACKGUID, "CMSG_MAKEMONSTERATTACKGUID", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x017*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BOT_DETECTED2, "CMSG_BOT_DETECTED2", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x018*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FORCEACTION, "CMSG_FORCEACTION", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x019*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FORCEACTIONONOTHER, "CMSG_FORCEACTIONONOTHER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x01A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FORCEACTIONSHOW, "CMSG_FORCEACTIONSHOW", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x01B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FORCEACTIONSHOW, "SMSG_FORCEACTIONSHOW", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x01C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PETGODMODE, "CMSG_PETGODMODE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x01D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PETGODMODE, "SMSG_PETGODMODE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x01E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DEBUGINFOSPELLMISS_OBSOLETE, "SMSG_DEBUGINFOSPELLMISS_OBSOLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x01F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_WEATHER_SPEED_CHEAT, "CMSG_WEATHER_SPEED_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x020*/
        gateway.StoreOpcode(WorldOpcode.CMSG_UNDRESSPLAYER, "CMSG_UNDRESSPLAYER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x021*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BEASTMASTER, "CMSG_BEASTMASTER", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x022*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GODMODE, "CMSG_GODMODE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x023*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GODMODE, "SMSG_GODMODE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x024*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHEAT_SETMONEY, "CMSG_CHEAT_SETMONEY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x025*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LEVEL_CHEAT, "CMSG_LEVEL_CHEAT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x026*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PET_LEVEL_CHEAT, "CMSG_PET_LEVEL_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x027*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_WORLDSTATE, "CMSG_SET_WORLDSTATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x028*/
        gateway.StoreOpcode(WorldOpcode.CMSG_COOLDOWN_CHEAT, "CMSG_COOLDOWN_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x029*/
        gateway.StoreOpcode(WorldOpcode.CMSG_USE_SKILL_CHEAT, "CMSG_USE_SKILL_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x02A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FLAG_QUEST, "CMSG_FLAG_QUEST", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x02B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FLAG_QUEST_FINISH, "CMSG_FLAG_QUEST_FINISH", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x02C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CLEAR_QUEST, "CMSG_CLEAR_QUEST", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x02D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SEND_EVENT, "CMSG_SEND_EVENT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x02E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DEBUG_AISTATE, "CMSG_DEBUG_AISTATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x02F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DEBUG_AISTATE, "SMSG_DEBUG_AISTATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x030*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DISABLE_PVP_CHEAT, "CMSG_DISABLE_PVP_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x031*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ADVANCE_SPAWN_TIME, "CMSG_ADVANCE_SPAWN_TIME", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x032*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PVP_PORT_OBSOLETE, "CMSG_PVP_PORT_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x033*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTH_SRP6_BEGIN, "CMSG_AUTH_SRP6_BEGIN", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x034*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTH_SRP6_PROOF, "CMSG_AUTH_SRP6_PROOF", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x035*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTH_SRP6_RECODE, "CMSG_AUTH_SRP6_RECODE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x036*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHAR_CREATE, "CMSG_CHAR_CREATE", SessionStatus.AUTHED,
            PacketProcessing.THREADUNSAFE, gateway.HandleCharCreateOpcode);
        /*0x037*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHAR_ENUM, "CMSG_CHAR_ENUM", SessionStatus.AUTHED,
            PacketProcessing.THREADUNSAFE, gateway.HandleCharEnumOpcode);
        /*0x038*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHAR_DELETE, "CMSG_CHAR_DELETE", SessionStatus.AUTHED,
            PacketProcessing.THREADUNSAFE, gateway.HandleCharDeleteOpcode);
        /*0x039*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AUTH_SRP6_RESPONSE, "SMSG_AUTH_SRP6_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x03A*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHAR_CREATE, "SMSG_CHAR_CREATE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x03B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHAR_ENUM, "SMSG_CHAR_ENUM", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x03C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHAR_DELETE, "SMSG_CHAR_DELETE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x03D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PLAYER_LOGIN, "CMSG_PLAYER_LOGIN", SessionStatus.AUTHED,
            PacketProcessing.INPLACE, gateway.HandlePlayerLoginOpcode);
        /*0x03E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_NEW_WORLD, "SMSG_NEW_WORLD", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x03F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TRANSFER_PENDING, "SMSG_TRANSFER_PENDING", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x040*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TRANSFER_ABORTED, "SMSG_TRANSFER_ABORTED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x041*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHARACTER_LOGIN_FAILED, "SMSG_CHARACTER_LOGIN_FAILED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x042*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOGIN_SETTIMESPEED, "SMSG_LOGIN_SETTIMESPEED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x043*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GAMETIME_UPDATE, "SMSG_GAMETIME_UPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x044*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GAMETIME_SET, "CMSG_GAMETIME_SET", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x045*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GAMETIME_SET, "SMSG_GAMETIME_SET", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x046*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GAMESPEED_SET, "CMSG_GAMESPEED_SET", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x047*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GAMESPEED_SET, "SMSG_GAMESPEED_SET", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x048*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SERVERTIME, "CMSG_SERVERTIME", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x049*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SERVERTIME, "SMSG_SERVERTIME", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x04A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PLAYER_LOGOUT, "CMSG_PLAYER_LOGOUT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePlayerLogoutOpcode);
        /*0x04B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LOGOUT_REQUEST, "CMSG_LOGOUT_REQUEST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleLogoutRequestOpcode);
        /*0x04C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOGOUT_RESPONSE, "SMSG_LOGOUT_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x04D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOGOUT_COMPLETE, "SMSG_LOGOUT_COMPLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x04E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LOGOUT_CANCEL, "CMSG_LOGOUT_CANCEL", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleLogoutCancelOpcode);
        /*0x04F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOGOUT_CANCEL_ACK, "SMSG_LOGOUT_CANCEL_ACK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x050*/
        gateway.StoreOpcode(WorldOpcode.CMSG_NAME_QUERY, "CMSG_NAME_QUERY", SessionStatus.AUTHED,
            PacketProcessing.THREADUNSAFE, gateway.HandleNameQueryOpcode);
        /*0x051*/
        gateway.StoreOpcode(WorldOpcode.SMSG_NAME_QUERY_RESPONSE, "SMSG_NAME_QUERY_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x052*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PET_NAME_QUERY, "CMSG_PET_NAME_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePetNameQueryOpcode);
        /*0x053*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PET_NAME_QUERY_RESPONSE, "SMSG_PET_NAME_QUERY_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x054*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_QUERY, "CMSG_GUILD_QUERY", SessionStatus.AUTHED,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildQueryOpcode);
        /*0x055*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GUILD_QUERY_RESPONSE, "SMSG_GUILD_QUERY_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x056*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ITEM_QUERY_SINGLE, "CMSG_ITEM_QUERY_SINGLE", SessionStatus.LOGGEDIN,
            PacketProcessing.IMMEDIATE, gateway.HandleItemQuerySingleOpcode);
        /*0x057*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ITEM_QUERY_MULTIPLE, "CMSG_ITEM_QUERY_MULTIPLE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x058*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ITEM_QUERY_SINGLE_RESPONSE, "SMSG_ITEM_QUERY_SINGLE_RESPONSE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x059*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ITEM_QUERY_MULTIPLE_RESPONSE, "SMSG_ITEM_QUERY_MULTIPLE_RESPONSE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x05A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PAGE_TEXT_QUERY, "CMSG_PAGE_TEXT_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.IMMEDIATE, gateway.HandlePageTextQueryOpcode);
        /*0x05B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PAGE_TEXT_QUERY_RESPONSE, "SMSG_PAGE_TEXT_QUERY_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x05C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUEST_QUERY, "CMSG_QUEST_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.IMMEDIATE, gateway.HandleQuestQueryOpcode);
        /*0x05D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUEST_QUERY_RESPONSE, "SMSG_QUEST_QUERY_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x05E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GAMEOBJECT_QUERY, "CMSG_GAMEOBJECT_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.IMMEDIATE, gateway.HandleGameObjectQueryOpcode);
        /*0x05F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GAMEOBJECT_QUERY_RESPONSE, "SMSG_GAMEOBJECT_QUERY_RESPONSE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x060*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CREATURE_QUERY, "CMSG_CREATURE_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.IMMEDIATE, gateway.HandleCreatureQueryOpcode);
        /*0x061*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CREATURE_QUERY_RESPONSE, "SMSG_CREATURE_QUERY_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x062*/
        gateway.StoreOpcode(WorldOpcode.CMSG_WHO, "CMSG_WHO", SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE,
            gateway.HandleWhoOpcode);
        /*0x063*/
        gateway.StoreOpcode(WorldOpcode.SMSG_WHO, "SMSG_WHO", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x064*/
        gateway.StoreOpcode(WorldOpcode.CMSG_WHOIS, "CMSG_WHOIS", SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE,
            gateway.HandleWhoisOpcode);
        /*0x065*/
        gateway.StoreOpcode(WorldOpcode.SMSG_WHOIS, "SMSG_WHOIS", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x066*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FRIEND_LIST, "CMSG_FRIEND_LIST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleFriendListOpcode);
        /*0x067*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FRIEND_LIST, "SMSG_FRIEND_LIST", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x068*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FRIEND_STATUS, "SMSG_FRIEND_STATUS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x069*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ADD_FRIEND, "CMSG_ADD_FRIEND", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAddFriendOpcode);
        /*0x06A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DEL_FRIEND, "CMSG_DEL_FRIEND", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleDelFriendOpcode);
        /*0x06B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_IGNORE_LIST, "SMSG_IGNORE_LIST", SessionStatus.NEVER,
            PacketProcessing.THREADUNSAFE, gateway.Handle_ServerSide);
        /*0x06C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ADD_IGNORE, "CMSG_ADD_IGNORE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAddIgnoreOpcode);
        /*0x06D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DEL_IGNORE, "CMSG_DEL_IGNORE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleDelIgnoreOpcode);
        /*0x06E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_INVITE, "CMSG_GROUP_INVITE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGroupInviteOpcode);
        /*0x06F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GROUP_INVITE, "SMSG_GROUP_INVITE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x070*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_CANCEL, "CMSG_GROUP_CANCEL", SessionStatus.LOGGEDIN,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x071*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GROUP_CANCEL, "SMSG_GROUP_CANCEL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x072*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_ACCEPT, "CMSG_GROUP_ACCEPT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGroupAcceptOpcode);
        /*0x073*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_DECLINE, "CMSG_GROUP_DECLINE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGroupDeclineOpcode);
        /*0x074*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GROUP_DECLINE, "SMSG_GROUP_DECLINE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x075*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_UNINVITE, "CMSG_GROUP_UNINVITE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGroupUninviteOpcode);
        /*0x076*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_UNINVITE_GUID, "CMSG_GROUP_UNINVITE_GUID", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGroupUninviteGuidOpcode);
        /*0x077*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GROUP_UNINVITE, "SMSG_GROUP_UNINVITE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x078*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_SET_LEADER, "CMSG_GROUP_SET_LEADER", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGroupSetLeaderOpcode);
        /*0x079*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GROUP_SET_LEADER, "SMSG_GROUP_SET_LEADER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x07A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LOOT_METHOD, "CMSG_LOOT_METHOD", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleLootMethodOpcode);
        /*0x07B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_DISBAND, "CMSG_GROUP_DISBAND", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGroupDisbandOpcode);
        /*0x07C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GROUP_DESTROYED, "SMSG_GROUP_DESTROYED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x07D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GROUP_LIST, "SMSG_GROUP_LIST", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x07E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PARTY_MEMBER_STATS, "SMSG_PARTY_MEMBER_STATS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x07F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PARTY_COMMAND_RESULT, "SMSG_PARTY_COMMAND_RESULT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x080*/
        gateway.StoreOpcode(WorldOpcode.UMSG_UPDATE_GROUP_MEMBERS, "UMSG_UPDATE_GROUP_MEMBERS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x081*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_CREATE, "CMSG_GUILD_CREATE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildCreateOpcode);
        /*0x082*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_INVITE, "CMSG_GUILD_INVITE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildInviteOpcode);
        /*0x083*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GUILD_INVITE, "SMSG_GUILD_INVITE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x084*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_ACCEPT, "CMSG_GUILD_ACCEPT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildAcceptOpcode);
        /*0x085*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_DECLINE, "CMSG_GUILD_DECLINE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildDeclineOpcode);
        /*0x086*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GUILD_DECLINE, "SMSG_GUILD_DECLINE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x087*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_INFO, "CMSG_GUILD_INFO", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildInfoOpcode);
        /*0x088*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GUILD_INFO, "SMSG_GUILD_INFO", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x089*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_ROSTER, "CMSG_GUILD_ROSTER", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildRosterOpcode);
        /*0x08A*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GUILD_ROSTER, "SMSG_GUILD_ROSTER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x08B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_PROMOTE, "CMSG_GUILD_PROMOTE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildPromoteOpcode);
        /*0x08C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_DEMOTE, "CMSG_GUILD_DEMOTE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildDemoteOpcode);
        /*0x08D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_LEAVE, "CMSG_GUILD_LEAVE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildLeaveOpcode);
        /*0x08E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_REMOVE, "CMSG_GUILD_REMOVE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildRemoveOpcode);
        /*0x08F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_DISBAND, "CMSG_GUILD_DISBAND", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildDisbandOpcode);
        /*0x090*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_LEADER, "CMSG_GUILD_LEADER", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildLeaderOpcode);
        /*0x091*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_MOTD, "CMSG_GUILD_MOTD", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildMOTDOpcode);
        /*0x092*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GUILD_EVENT, "SMSG_GUILD_EVENT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x093*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GUILD_COMMAND_RESULT, "SMSG_GUILD_COMMAND_RESULT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x094*/
        gateway.StoreOpcode(WorldOpcode.UMSG_UPDATE_GUILD, "UMSG_UPDATE_GUILD", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x095*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MESSAGECHAT, "CMSG_MESSAGECHAT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleMessagechatOpcode);
        /*0x096*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MESSAGECHAT, "SMSG_MESSAGECHAT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x097*/
        gateway.StoreOpcode(WorldOpcode.CMSG_JOIN_CHANNEL, "CMSG_JOIN_CHANNEL", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleJoinChannelOpcode);
        /*0x098*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LEAVE_CHANNEL, "CMSG_LEAVE_CHANNEL", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleLeaveChannelOpcode);
        /*0x099*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHANNEL_NOTIFY, "SMSG_CHANNEL_NOTIFY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x09A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_LIST, "CMSG_CHANNEL_LIST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelListOpcode);
        /*0x09B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHANNEL_LIST, "SMSG_CHANNEL_LIST", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x09C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_PASSWORD, "CMSG_CHANNEL_PASSWORD", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelPasswordOpcode);
        /*0x09D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_SET_OWNER, "CMSG_CHANNEL_SET_OWNER", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelSetOwnerOpcode);
        /*0x09E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_OWNER, "CMSG_CHANNEL_OWNER", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelOwnerOpcode);
        /*0x09F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_MODERATOR, "CMSG_CHANNEL_MODERATOR", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelModeratorOpcode);
        /*0x0A0*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_UNMODERATOR, "CMSG_CHANNEL_UNMODERATOR", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelUnmoderatorOpcode);
        /*0x0A1*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_MUTE, "CMSG_CHANNEL_MUTE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelMuteOpcode);
        /*0x0A2*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_UNMUTE, "CMSG_CHANNEL_UNMUTE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelUnmuteOpcode);
        /*0x0A3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_INVITE, "CMSG_CHANNEL_INVITE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelInviteOpcode);
        /*0x0A4*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_KICK, "CMSG_CHANNEL_KICK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelKickOpcode);
        /*0x0A5*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_BAN, "CMSG_CHANNEL_BAN", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelBanOpcode);
        /*0x0A6*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_UNBAN, "CMSG_CHANNEL_UNBAN", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelUnbanOpcode);
        /*0x0A7*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_ANNOUNCEMENTS, "CMSG_CHANNEL_ANNOUNCEMENTS", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelAnnouncementsOpcode);
        /*0x0A8*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_MODERATE, "CMSG_CHANNEL_MODERATE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelModerateOpcode);
        /*0x0A9*/
        gateway.StoreOpcode(WorldOpcode.SMSG_UPDATE_OBJECT, "SMSG_UPDATE_OBJECT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0AA*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DESTROY_OBJECT, "SMSG_DESTROY_OBJECT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0AB*/
        gateway.StoreOpcode(WorldOpcode.CMSG_USE_ITEM, "CMSG_USE_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleUseItemOpcode);
        /*0x0AC*/
        gateway.StoreOpcode(WorldOpcode.CMSG_OPEN_ITEM, "CMSG_OPEN_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleOpenItemOpcode);
        /*0x0AD*/
        gateway.StoreOpcode(WorldOpcode.CMSG_READ_ITEM, "CMSG_READ_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleReadItemOpcode);
        /*0x0AE*/
        gateway.StoreOpcode(WorldOpcode.SMSG_READ_ITEM_OK, "SMSG_READ_ITEM_OK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0AF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_READ_ITEM_FAILED, "SMSG_READ_ITEM_FAILED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0B0*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ITEM_COOLDOWN, "SMSG_ITEM_COOLDOWN", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0B1*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GAMEOBJ_USE, "CMSG_GAMEOBJ_USE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGameObjectUseOpcode);
        /*0x0B2*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GAMEOBJ_CHAIR_USE_OBSOLETE, "CMSG_GAMEOBJ_CHAIR_USE_OBSOLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0B3*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GAMEOBJECT_CUSTOM_ANIM, "SMSG_GAMEOBJECT_CUSTOM_ANIM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0B4*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AREATRIGGER, "CMSG_AREATRIGGER", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAreaTriggerOpcode);
        /*0x0B5*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_START_FORWARD, "MSG_MOVE_START_FORWARD", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0B6*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_START_BACKWARD, "MSG_MOVE_START_BACKWARD", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0B7*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_STOP, "MSG_MOVE_STOP", SessionStatus.LOGGEDIN, PacketProcessing.THREADSAFE,
            gateway.HandleMovementOpcodes);
        /*0x0B8*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_START_STRAFE_LEFT, "MSG_MOVE_START_STRAFE_LEFT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0B9*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_START_STRAFE_RIGHT, "MSG_MOVE_START_STRAFE_RIGHT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0BA*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_STOP_STRAFE, "MSG_MOVE_STOP_STRAFE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0BB*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_JUMP, "MSG_MOVE_JUMP", SessionStatus.LOGGEDIN, PacketProcessing.THREADSAFE,
            gateway.HandleMovementOpcodes);
        /*0x0BC*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_START_TURN_LEFT, "MSG_MOVE_START_TURN_LEFT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0BD*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_START_TURN_RIGHT, "MSG_MOVE_START_TURN_RIGHT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0BE*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_STOP_TURN, "MSG_MOVE_STOP_TURN", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0BF*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_START_PITCH_UP, "MSG_MOVE_START_PITCH_UP", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0C0*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_START_PITCH_DOWN, "MSG_MOVE_START_PITCH_DOWN", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0C1*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_STOP_PITCH, "MSG_MOVE_STOP_PITCH", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0C2*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_RUN_MODE, "MSG_MOVE_SET_RUN_MODE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0C3*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_WALK_MODE, "MSG_MOVE_SET_WALK_MODE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0C4*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_TOGGLE_LOGGING, "MSG_MOVE_TOGGLE_LOGGING", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0C5*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_TELEPORT, "MSG_MOVE_TELEPORT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0C6*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_TELEPORT_CHEAT, "MSG_MOVE_TELEPORT_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0C7*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_TELEPORT_ACK, "MSG_MOVE_TELEPORT_ACK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMoveTeleportAckOpcode);
        /*0x0C8*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_TOGGLE_FALL_LOGGING, "MSG_MOVE_TOGGLE_FALL_LOGGING", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0C9*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_FALL_LAND, "MSG_MOVE_FALL_LAND", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0CA*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_START_SWIM, "MSG_MOVE_START_SWIM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0CB*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_STOP_SWIM, "MSG_MOVE_STOP_SWIM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0CC*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_RUN_SPEED_CHEAT, "MSG_MOVE_SET_RUN_SPEED_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0CD*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_RUN_SPEED, "MSG_MOVE_SET_RUN_SPEED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0CE*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_RUN_BACK_SPEED_CHEAT, "MSG_MOVE_SET_RUN_BACK_SPEED_CHEAT",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0CF*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_RUN_BACK_SPEED, "MSG_MOVE_SET_RUN_BACK_SPEED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0D0*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_WALK_SPEED_CHEAT, "MSG_MOVE_SET_WALK_SPEED_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0D1*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_WALK_SPEED, "MSG_MOVE_SET_WALK_SPEED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0D2*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_SWIM_SPEED_CHEAT, "MSG_MOVE_SET_SWIM_SPEED_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0D3*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_SWIM_SPEED, "MSG_MOVE_SET_SWIM_SPEED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0D4*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_SWIM_BACK_SPEED_CHEAT, "MSG_MOVE_SET_SWIM_BACK_SPEED_CHEAT",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0D5*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_SWIM_BACK_SPEED, "MSG_MOVE_SET_SWIM_BACK_SPEED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0D6*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_ALL_SPEED_CHEAT, "MSG_MOVE_SET_ALL_SPEED_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0D7*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_TURN_RATE_CHEAT, "MSG_MOVE_SET_TURN_RATE_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0D8*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_TURN_RATE, "MSG_MOVE_SET_TURN_RATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0D9*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_TOGGLE_COLLISION_CHEAT, "MSG_MOVE_TOGGLE_COLLISION_CHEAT",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0DA*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_FACING, "MSG_MOVE_SET_FACING", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0DB*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_PITCH, "MSG_MOVE_SET_PITCH", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0DC*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_WORLDPORT_ACK, "MSG_MOVE_WORLDPORT_ACK", SessionStatus.TRANSFER,
            PacketProcessing.THREADUNSAFE, gateway.HandleMoveWorldportAckOpcode);
        /*0x0DD*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MONSTER_MOVE, "SMSG_MONSTER_MOVE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0DE*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MOVE_WATER_WALK, "SMSG_MOVE_WATER_WALK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0DF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MOVE_LAND_WALK, "SMSG_MOVE_LAND_WALK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0E0*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_SET_RAW_POSITION_ACK, "MSG_MOVE_SET_RAW_POSITION_ACK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0E1*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_SET_RAW_POSITION, "CMSG_MOVE_SET_RAW_POSITION", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0E2*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FORCE_RUN_SPEED_CHANGE, "SMSG_FORCE_RUN_SPEED_CHANGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0E3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FORCE_RUN_SPEED_CHANGE_ACK, "CMSG_FORCE_RUN_SPEED_CHANGE_ACK",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADSAFE, gateway.HandleForceSpeedChangeAckOpcodes);
        /*0x0E4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FORCE_RUN_BACK_SPEED_CHANGE, "SMSG_FORCE_RUN_BACK_SPEED_CHANGE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0E5*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK, "CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADSAFE, gateway.HandleForceSpeedChangeAckOpcodes);
        /*0x0E6*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FORCE_SWIM_SPEED_CHANGE, "SMSG_FORCE_SWIM_SPEED_CHANGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0E7*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FORCE_SWIM_SPEED_CHANGE_ACK, "CMSG_FORCE_SWIM_SPEED_CHANGE_ACK",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADSAFE, gateway.HandleForceSpeedChangeAckOpcodes);
        /*0x0E8*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FORCE_MOVE_ROOT, "SMSG_FORCE_MOVE_ROOT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0E9*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FORCE_MOVE_ROOT_ACK, "CMSG_FORCE_MOVE_ROOT_ACK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMoveRootAck);
        /*0x0EA*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FORCE_MOVE_UNROOT, "SMSG_FORCE_MOVE_UNROOT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0EB*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FORCE_MOVE_UNROOT_ACK, "CMSG_FORCE_MOVE_UNROOT_ACK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMoveRootAck);
        /*0x0EC*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_ROOT, "MSG_MOVE_ROOT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x0ED*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_UNROOT, "MSG_MOVE_UNROOT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x0EE*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_HEARTBEAT, "MSG_MOVE_HEARTBEAT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x0EF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MOVE_KNOCK_BACK, "SMSG_MOVE_KNOCK_BACK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0F0*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_KNOCK_BACK_ACK, "CMSG_MOVE_KNOCK_BACK_ACK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMoveKnockBackAck);
        /*0x0F1*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_KNOCK_BACK, "MSG_MOVE_KNOCK_BACK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0F2*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MOVE_FEATHER_FALL, "SMSG_MOVE_FEATHER_FALL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0F3*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MOVE_NORMAL_FALL, "SMSG_MOVE_NORMAL_FALL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0F4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MOVE_SET_HOVER, "SMSG_MOVE_SET_HOVER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0F5*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MOVE_UNSET_HOVER, "SMSG_MOVE_UNSET_HOVER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0F6*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_HOVER_ACK, "CMSG_MOVE_HOVER_ACK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMoveFlagChangeOpcode);
        /*0x0F7*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_HOVER, "MSG_MOVE_HOVER", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x0F8*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TRIGGER_CINEMATIC_CHEAT, "CMSG_TRIGGER_CINEMATIC_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0F9*/
        gateway.StoreOpcode(WorldOpcode.CMSG_OPENING_CINEMATIC, "CMSG_OPENING_CINEMATIC", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x0FA*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TRIGGER_CINEMATIC, "SMSG_TRIGGER_CINEMATIC", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0FB*/
        gateway.StoreOpcode(WorldOpcode.CMSG_NEXT_CINEMATIC_CAMERA, "CMSG_NEXT_CINEMATIC_CAMERA", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleNextCinematicCamera);
        /*0x0FC*/
        gateway.StoreOpcode(WorldOpcode.CMSG_COMPLETE_CINEMATIC, "CMSG_COMPLETE_CINEMATIC", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleCompleteCinematic);
        /*0x0FD*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TUTORIAL_FLAGS, "SMSG_TUTORIAL_FLAGS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x0FE*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TUTORIAL_FLAG, "CMSG_TUTORIAL_FLAG", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleTutorialFlagOpcode);
        /*0x0FF*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TUTORIAL_CLEAR, "CMSG_TUTORIAL_CLEAR", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleTutorialClearOpcode);
        /*0x100*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TUTORIAL_RESET, "CMSG_TUTORIAL_RESET", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleTutorialResetOpcode);
        /*0x101*/
        gateway.StoreOpcode(WorldOpcode.CMSG_STANDSTATECHANGE, "CMSG_STANDSTATECHANGE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleStandStateChangeOpcode);
        /*0x102*/
        gateway.StoreOpcode(WorldOpcode.CMSG_EMOTE, "CMSG_EMOTE", SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE,
            gateway.HandleEmoteOpcode);
        /*0x103*/
        gateway.StoreOpcode(WorldOpcode.SMSG_EMOTE, "SMSG_EMOTE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x104*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TEXT_EMOTE, "CMSG_TEXT_EMOTE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleTextEmoteOpcode);
        /*0x105*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TEXT_EMOTE, "SMSG_TEXT_EMOTE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x106*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTOEQUIP_GROUND_ITEM, "CMSG_AUTOEQUIP_GROUND_ITEM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x107*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTOSTORE_GROUND_ITEM, "CMSG_AUTOSTORE_GROUND_ITEM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x108*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTOSTORE_LOOT_ITEM, "CMSG_AUTOSTORE_LOOT_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAutostoreLootItemOpcode);
        /*0x109*/
        gateway.StoreOpcode(WorldOpcode.CMSG_STORE_LOOT_IN_SLOT, "CMSG_STORE_LOOT_IN_SLOT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x10A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTOEQUIP_ITEM, "CMSG_AUTOEQUIP_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAutoEquipItemOpcode);
        /*0x10B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTOSTORE_BAG_ITEM, "CMSG_AUTOSTORE_BAG_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAutoStoreBagItemOpcode);
        /*0x10C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SWAP_ITEM, "CMSG_SWAP_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSwapItem);
        /*0x10D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SWAP_INV_ITEM, "CMSG_SWAP_INV_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSwapInvItemOpcode);
        /*0x10E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SPLIT_ITEM, "CMSG_SPLIT_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSplitItemOpcode);
        /*0x10F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTOEQUIP_ITEM_SLOT, "CMSG_AUTOEQUIP_ITEM_SLOT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAutoEquipItemSlotOpcode);
        /*0x110*/
        gateway.StoreOpcode(WorldOpcode.OBSOLETE_DROP_ITEM, "OBSOLETE_DROP_ITEM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x111*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DESTROYITEM, "CMSG_DESTROYITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleDestroyItemOpcode);
        /*0x112*/
        gateway.StoreOpcode(WorldOpcode.SMSG_INVENTORY_CHANGE_FAILURE, "SMSG_INVENTORY_CHANGE_FAILURE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x113*/
        gateway.StoreOpcode(WorldOpcode.SMSG_OPEN_CONTAINER, "SMSG_OPEN_CONTAINER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x114*/
        gateway.StoreOpcode(WorldOpcode.CMSG_INSPECT, "CMSG_INSPECT", SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE,
            gateway.HandleInspectOpcode);
        /*0x115*/
        gateway.StoreOpcode(WorldOpcode.SMSG_INSPECT, "SMSG_INSPECT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x116*/
        gateway.StoreOpcode(WorldOpcode.CMSG_INITIATE_TRADE, "CMSG_INITIATE_TRADE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleInitiateTradeOpcode);
        /*0x117*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BEGIN_TRADE, "CMSG_BEGIN_TRADE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleBeginTradeOpcode);
        /*0x118*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BUSY_TRADE, "CMSG_BUSY_TRADE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleBusyTradeOpcode);
        /*0x119*/
        gateway.StoreOpcode(WorldOpcode.CMSG_IGNORE_TRADE, "CMSG_IGNORE_TRADE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleIgnoreTradeOpcode);
        /*0x11A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ACCEPT_TRADE, "CMSG_ACCEPT_TRADE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAcceptTradeOpcode);
        /*0x11B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_UNACCEPT_TRADE, "CMSG_UNACCEPT_TRADE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleUnacceptTradeOpcode);
        /*0x11C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CANCEL_TRADE, "CMSG_CANCEL_TRADE",
            SessionStatus.LOGGEDIN_OR_RECENTLY_LOGGEDOUT, PacketProcessing.THREADUNSAFE,
            gateway.HandleCancelTradeOpcode);
        /*0x11D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_TRADE_ITEM, "CMSG_SET_TRADE_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSetTradeItemOpcode);
        /*0x11E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CLEAR_TRADE_ITEM, "CMSG_CLEAR_TRADE_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleClearTradeItemOpcode);
        /*0x11F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_TRADE_GOLD, "CMSG_SET_TRADE_GOLD", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSetTradeGoldOpcode);
        /*0x120*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TRADE_STATUS, "SMSG_TRADE_STATUS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x121*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TRADE_STATUS_EXTENDED, "SMSG_TRADE_STATUS_EXTENDED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x122*/
        gateway.StoreOpcode(WorldOpcode.SMSG_INITIALIZE_FACTIONS, "SMSG_INITIALIZE_FACTIONS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x123*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SET_FACTION_VISIBLE, "SMSG_SET_FACTION_VISIBLE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x124*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SET_FACTION_STANDING, "SMSG_SET_FACTION_STANDING", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x125*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_FACTION_ATWAR, "CMSG_SET_FACTION_ATWAR", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSetFactionAtWarOpcode);
        /*0x126*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_FACTION_CHEAT, "CMSG_SET_FACTION_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_Deprecated);
        /*0x127*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SET_PROFICIENCY, "SMSG_SET_PROFICIENCY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x128*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_ACTION_BUTTON, "CMSG_SET_ACTION_BUTTON", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSetActionButtonOpcode);
        /*0x129*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ACTION_BUTTONS, "SMSG_ACTION_BUTTONS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x12A*/
        gateway.StoreOpcode(WorldOpcode.SMSG_INITIAL_SPELLS, "SMSG_INITIAL_SPELLS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x12B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LEARNED_SPELL, "SMSG_LEARNED_SPELL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x12C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SUPERCEDED_SPELL, "SMSG_SUPERCEDED_SPELL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x12D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_NEW_SPELL_SLOT, "CMSG_NEW_SPELL_SLOT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x12E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CAST_SPELL, "CMSG_CAST_SPELL", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleCastSpellOpcode);
        /*0x12F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CANCEL_CAST, "CMSG_CANCEL_CAST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleCancelCastOpcode);
        /*0x130*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CAST_RESULT, "SMSG_CAST_RESULT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x131*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELL_START, "SMSG_SPELL_START", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x132*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELL_GO, "SMSG_SPELL_GO", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x133*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELL_FAILURE, "SMSG_SPELL_FAILURE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x134*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELL_COOLDOWN, "SMSG_SPELL_COOLDOWN", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x135*/
        gateway.StoreOpcode(WorldOpcode.SMSG_COOLDOWN_EVENT, "SMSG_COOLDOWN_EVENT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x136*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CANCEL_AURA, "CMSG_CANCEL_AURA", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleCancelAuraOpcode);
        /*0x137*/
        gateway.StoreOpcode(WorldOpcode.SMSG_UPDATE_AURA_DURATION, "SMSG_UPDATE_AURA_DURATION", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x138*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PET_CAST_FAILED, "SMSG_PET_CAST_FAILED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x139*/
        gateway.StoreOpcode(WorldOpcode.MSG_CHANNEL_START, "MSG_CHANNEL_START", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x13A*/
        gateway.StoreOpcode(WorldOpcode.MSG_CHANNEL_UPDATE, "MSG_CHANNEL_UPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x13B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CANCEL_CHANNELLING, "CMSG_CANCEL_CHANNELLING", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleCancelChanneling);
        /*0x13C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AI_REACTION, "SMSG_AI_REACTION", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x13D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_SELECTION, "CMSG_SET_SELECTION", SessionStatus.LOGGEDIN,
            PacketProcessing.INPLACE, gateway.HandleSetSelectionOpcode);
        /*0x13E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_TARGET_OBSOLETE, "CMSG_SET_TARGET_OBSOLETE", SessionStatus.LOGGEDIN,
            PacketProcessing.INPLACE, gateway.HandleSetTargetOpcode);
        /*0x13F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_UNUSED, "CMSG_UNUSED", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x140*/
        gateway.StoreOpcode(WorldOpcode.CMSG_UNUSED2, "CMSG_UNUSED2", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x141*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ATTACKSWING, "CMSG_ATTACKSWING", SessionStatus.LOGGEDIN,
            PacketProcessing.INPLACE, gateway.HandleAttackSwingOpcode);
        /*0x142*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ATTACKSTOP, "CMSG_ATTACKSTOP", SessionStatus.LOGGEDIN,
            PacketProcessing.INPLACE, gateway.HandleAttackStopOpcode);
        /*0x143*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ATTACKSTART, "SMSG_ATTACKSTART", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x144*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ATTACKSTOP, "SMSG_ATTACKSTOP", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x145*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ATTACKSWING_NOTINRANGE, "SMSG_ATTACKSWING_NOTINRANGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x146*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ATTACKSWING_BADFACING, "SMSG_ATTACKSWING_BADFACING", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x147*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ATTACKSWING_NOTSTANDING, "SMSG_ATTACKSWING_NOTSTANDING", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x148*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ATTACKSWING_DEADTARGET, "SMSG_ATTACKSWING_DEADTARGET", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x149*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ATTACKSWING_CANT_ATTACK, "SMSG_ATTACKSWING_CANT_ATTACK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x14A*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ATTACKERSTATEUPDATE, "SMSG_ATTACKERSTATEUPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x14B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_VICTIMSTATEUPDATE_OBSOLETE, "SMSG_VICTIMSTATEUPDATE_OBSOLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x14C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DAMAGE_DONE_OBSOLETE, "SMSG_DAMAGE_DONE_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x14D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DAMAGE_TAKEN_OBSOLETE, "SMSG_DAMAGE_TAKEN_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x14E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CANCEL_COMBAT, "SMSG_CANCEL_COMBAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x14F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAYER_COMBAT_XP_GAIN_OBSOLETE, "SMSG_PLAYER_COMBAT_XP_GAIN_OBSOLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x150*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELLHEALLOG, "SMSG_SPELLHEALLOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x151*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELLENERGIZELOG, "SMSG_SPELLENERGIZELOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x152*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SHEATHE_OBSOLETE, "CMSG_SHEATHE_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x153*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SAVE_PLAYER, "CMSG_SAVE_PLAYER", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x154*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SETDEATHBINDPOINT, "CMSG_SETDEATHBINDPOINT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x155*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BINDPOINTUPDATE, "SMSG_BINDPOINTUPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x156*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GETDEATHBINDZONE, "CMSG_GETDEATHBINDZONE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x157*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BINDZONEREPLY, "SMSG_BINDZONEREPLY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x158*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAYERBOUND, "SMSG_PLAYERBOUND", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x159*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CLIENT_CONTROL_UPDATE, "SMSG_CLIENT_CONTROL_UPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x15A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_REPOP_REQUEST, "CMSG_REPOP_REQUEST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleRepopRequestOpcode);
        /*0x15B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_RESURRECT_REQUEST, "SMSG_RESURRECT_REQUEST", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x15C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_RESURRECT_RESPONSE, "CMSG_RESURRECT_RESPONSE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleResurrectResponseOpcode);
        /*0x15D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LOOT, "CMSG_LOOT", SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE,
            gateway.HandleLootOpcode);
        /*0x15E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LOOT_MONEY, "CMSG_LOOT_MONEY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleLootMoneyOpcode);
        /*0x15F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LOOT_RELEASE, "CMSG_LOOT_RELEASE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleLootReleaseOpcode);
        /*0x160*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_RESPONSE, "SMSG_LOOT_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x161*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_RELEASE_RESPONSE, "SMSG_LOOT_RELEASE_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x162*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_REMOVED, "SMSG_LOOT_REMOVED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x163*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_MONEY_NOTIFY, "SMSG_LOOT_MONEY_NOTIFY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x164*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_ITEM_NOTIFY, "SMSG_LOOT_ITEM_NOTIFY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x165*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_CLEAR_MONEY, "SMSG_LOOT_CLEAR_MONEY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x166*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ITEM_PUSH_RESULT, "SMSG_ITEM_PUSH_RESULT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x167*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DUEL_REQUESTED, "SMSG_DUEL_REQUESTED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x168*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DUEL_OUTOFBOUNDS, "SMSG_DUEL_OUTOFBOUNDS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x169*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DUEL_INBOUNDS, "SMSG_DUEL_INBOUNDS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x16A*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DUEL_COMPLETE, "SMSG_DUEL_COMPLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x16B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DUEL_WINNER, "SMSG_DUEL_WINNER", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x16C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DUEL_ACCEPTED, "CMSG_DUEL_ACCEPTED", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleDuelAcceptedOpcode);
        /*0x16D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DUEL_CANCELLED, "CMSG_DUEL_CANCELLED", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleDuelCancelledOpcode);
        /*0x16E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MOUNTRESULT, "SMSG_MOUNTRESULT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x16F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DISMOUNTRESULT, "SMSG_DISMOUNTRESULT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x170*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PUREMOUNT_CANCELLED_OBSOLETE, "SMSG_PUREMOUNT_CANCELLED_OBSOLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x171*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOUNTSPECIAL_ANIM, "CMSG_MOUNTSPECIAL_ANIM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleMountSpecialAnimOpcode);
        /*0x172*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MOUNTSPECIAL_ANIM, "SMSG_MOUNTSPECIAL_ANIM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x173*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PET_TAME_FAILURE, "SMSG_PET_TAME_FAILURE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x174*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PET_SET_ACTION, "CMSG_PET_SET_ACTION", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePetSetAction);
        /*0x175*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PET_ACTION, "CMSG_PET_ACTION", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePetAction);
        /*0x176*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PET_ABANDON, "CMSG_PET_ABANDON", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePetAbandon);
        /*0x177*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PET_RENAME, "CMSG_PET_RENAME", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePetRename);
        /*0x178*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PET_NAME_INVALID, "SMSG_PET_NAME_INVALID", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x179*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PET_SPELLS, "SMSG_PET_SPELLS", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x17A*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PET_MODE, "SMSG_PET_MODE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x17B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GOSSIP_HELLO, "CMSG_GOSSIP_HELLO", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGossipHelloOpcode);
        /*0x17C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GOSSIP_SELECT_OPTION, "CMSG_GOSSIP_SELECT_OPTION", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGossipSelectOptionOpcode);
        /*0x17D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GOSSIP_MESSAGE, "SMSG_GOSSIP_MESSAGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x17E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GOSSIP_COMPLETE, "SMSG_GOSSIP_COMPLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x17F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_NPC_TEXT_QUERY, "CMSG_NPC_TEXT_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleNpcTextQueryOpcode);
        /*0x180*/
        gateway.StoreOpcode(WorldOpcode.SMSG_NPC_TEXT_UPDATE, "SMSG_NPC_TEXT_UPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x181*/
        gateway.StoreOpcode(WorldOpcode.SMSG_NPC_WONT_TALK, "SMSG_NPC_WONT_TALK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x182*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTGIVER_STATUS_QUERY, "CMSG_QUESTGIVER_STATUS_QUERY",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleQuestgiverStatusQueryOpcode);
        /*0x183*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTGIVER_STATUS, "SMSG_QUESTGIVER_STATUS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x184*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTGIVER_HELLO, "CMSG_QUESTGIVER_HELLO", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleQuestgiverHelloOpcode);
        /*0x185*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTGIVER_QUEST_LIST, "SMSG_QUESTGIVER_QUEST_LIST", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x186*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTGIVER_QUERY_QUEST, "CMSG_QUESTGIVER_QUERY_QUEST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleQuestgiverQueryQuestOpcode);
        /*0x187*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTGIVER_QUEST_AUTOLAUNCH, "CMSG_QUESTGIVER_QUEST_AUTOLAUNCH",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleQuestgiverQuestAutoLaunch);
        /*0x188*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTGIVER_QUEST_DETAILS, "SMSG_QUESTGIVER_QUEST_DETAILS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x189*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTGIVER_ACCEPT_QUEST, "CMSG_QUESTGIVER_ACCEPT_QUEST",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleQuestgiverAcceptQuestOpcode);
        /*0x18A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTGIVER_COMPLETE_QUEST, "CMSG_QUESTGIVER_COMPLETE_QUEST",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleQuestgiverCompleteQuest);
        /*0x18B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTGIVER_REQUEST_ITEMS, "SMSG_QUESTGIVER_REQUEST_ITEMS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x18C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTGIVER_REQUEST_REWARD, "CMSG_QUESTGIVER_REQUEST_REWARD",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleQuestgiverRequestRewardOpcode);
        /*0x18D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTGIVER_OFFER_REWARD, "SMSG_QUESTGIVER_OFFER_REWARD", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x18E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTGIVER_CHOOSE_REWARD, "CMSG_QUESTGIVER_CHOOSE_REWARD",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleQuestgiverChooseRewardOpcode);
        /*0x18F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTGIVER_QUEST_INVALID, "SMSG_QUESTGIVER_QUEST_INVALID", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x190*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTGIVER_CANCEL, "CMSG_QUESTGIVER_CANCEL", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleQuestgiverCancel);
        /*0x191*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTGIVER_QUEST_COMPLETE, "SMSG_QUESTGIVER_QUEST_COMPLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x192*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTGIVER_QUEST_FAILED, "SMSG_QUESTGIVER_QUEST_FAILED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x193*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTLOG_SWAP_QUEST, "CMSG_QUESTLOG_SWAP_QUEST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleQuestLogSwapQuest);
        /*0x194*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTLOG_REMOVE_QUEST, "CMSG_QUESTLOG_REMOVE_QUEST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleQuestLogRemoveQuest);
        /*0x195*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTLOG_FULL, "SMSG_QUESTLOG_FULL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x196*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTUPDATE_FAILED, "SMSG_QUESTUPDATE_FAILED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x197*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTUPDATE_FAILEDTIMER, "SMSG_QUESTUPDATE_FAILEDTIMER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x198*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTUPDATE_COMPLETE, "SMSG_QUESTUPDATE_COMPLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x199*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTUPDATE_ADD_KILL, "SMSG_QUESTUPDATE_ADD_KILL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x19A*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTUPDATE_ADD_ITEM, "SMSG_QUESTUPDATE_ADD_ITEM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x19B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUEST_CONFIRM_ACCEPT, "CMSG_QUEST_CONFIRM_ACCEPT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleQuestConfirmAccept);
        /*0x19C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUEST_CONFIRM_ACCEPT, "SMSG_QUEST_CONFIRM_ACCEPT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x19D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PUSHQUESTTOPARTY, "CMSG_PUSHQUESTTOPARTY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePushQuestToParty);
        /*0x19E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LIST_INVENTORY, "CMSG_LIST_INVENTORY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleListInventoryOpcode);
        /*0x19F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LIST_INVENTORY, "SMSG_LIST_INVENTORY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1A0*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SELL_ITEM, "CMSG_SELL_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSellItemOpcode);
        /*0x1A1*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SELL_ITEM, "SMSG_SELL_ITEM", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x1A2*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BUY_ITEM, "CMSG_BUY_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleBuyItemOpcode);
        /*0x1A3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BUY_ITEM_IN_SLOT, "CMSG_BUY_ITEM_IN_SLOT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleBuyItemInSlotOpcode);
        /*0x1A4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BUY_ITEM, "SMSG_BUY_ITEM", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x1A5*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BUY_FAILED, "SMSG_BUY_FAILED", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x1A6*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TAXICLEARALLNODES, "CMSG_TAXICLEARALLNODES", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x1A7*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TAXIENABLEALLNODES, "CMSG_TAXIENABLEALLNODES", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x1A8*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TAXISHOWNODES, "CMSG_TAXISHOWNODES", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x1A9*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SHOWTAXINODES, "SMSG_SHOWTAXINODES", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1AA*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TAXINODE_STATUS_QUERY, "CMSG_TAXINODE_STATUS_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleTaxiNodeStatusQueryOpcode);
        /*0x1AB*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TAXINODE_STATUS, "SMSG_TAXINODE_STATUS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1AC*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TAXIQUERYAVAILABLENODES, "CMSG_TAXIQUERYAVAILABLENODES",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleTaxiQueryAvailableNodes);
        /*0x1AD*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ACTIVATETAXI, "CMSG_ACTIVATETAXI", SessionStatus.LOGGEDIN,
            PacketProcessing.INPLACE, gateway.HandleActivateTaxiOpcode);
        /*0x1AE*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ACTIVATETAXIREPLY, "SMSG_ACTIVATETAXIREPLY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1AF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_NEW_TAXI_PATH, "SMSG_NEW_TAXI_PATH", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1B0*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TRAINER_LIST, "CMSG_TRAINER_LIST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleTrainerListOpcode);
        /*0x1B1*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TRAINER_LIST, "SMSG_TRAINER_LIST", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1B2*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TRAINER_BUY_SPELL, "CMSG_TRAINER_BUY_SPELL", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleTrainerBuySpellOpcode);
        /*0x1B3*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TRAINER_BUY_SUCCEEDED, "SMSG_TRAINER_BUY_SUCCEEDED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1B4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TRAINER_BUY_FAILED, "SMSG_TRAINER_BUY_FAILED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1B5*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BINDER_ACTIVATE, "CMSG_BINDER_ACTIVATE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleBinderActivateOpcode);
        /*0x1B6*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAYERBINDERROR, "SMSG_PLAYERBINDERROR", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1B7*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BANKER_ACTIVATE, "CMSG_BANKER_ACTIVATE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleBankerActivateOpcode);
        /*0x1B8*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SHOW_BANK, "SMSG_SHOW_BANK", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x1B9*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BUY_BANK_SLOT, "CMSG_BUY_BANK_SLOT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleBuyBankSlotOpcode);
        /*0x1BA*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BUY_BANK_SLOT_RESULT, "SMSG_BUY_BANK_SLOT_RESULT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1BB*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PETITION_SHOWLIST, "CMSG_PETITION_SHOWLIST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandlePetitionShowListOpcode);
        /*0x1BC*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PETITION_SHOWLIST, "SMSG_PETITION_SHOWLIST", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1BD*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PETITION_BUY, "CMSG_PETITION_BUY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandlePetitionBuyOpcode);
        /*0x1BE*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PETITION_SHOW_SIGNATURES, "CMSG_PETITION_SHOW_SIGNATURES",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADSAFE, gateway.HandlePetitionShowSignOpcode);
        /*0x1BF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PETITION_SHOW_SIGNATURES, "SMSG_PETITION_SHOW_SIGNATURES", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1C0*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PETITION_SIGN, "CMSG_PETITION_SIGN", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandlePetitionSignOpcode);
        /*0x1C1*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PETITION_SIGN_RESULTS, "SMSG_PETITION_SIGN_RESULTS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1C2*/
        gateway.StoreOpcode(WorldOpcode.MSG_PETITION_DECLINE, "MSG_PETITION_DECLINE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandlePetitionDeclineOpcode);
        /*0x1C3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_OFFER_PETITION, "CMSG_OFFER_PETITION", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleOfferPetitionOpcode);
        /*0x1C4*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TURN_IN_PETITION, "CMSG_TURN_IN_PETITION", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleTurnInPetitionOpcode);
        /*0x1C5*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TURN_IN_PETITION_RESULTS, "SMSG_TURN_IN_PETITION_RESULTS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1C6*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PETITION_QUERY, "CMSG_PETITION_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandlePetitionQueryOpcode);
        /*0x1C7*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PETITION_QUERY_RESPONSE, "SMSG_PETITION_QUERY_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1C8*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FISH_NOT_HOOKED, "SMSG_FISH_NOT_HOOKED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1C9*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FISH_ESCAPED, "SMSG_FISH_ESCAPED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1CA*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BUG, "CMSG_BUG", SessionStatus.LOGGEDIN, PacketProcessing.THREADSAFE,
            gateway.HandleBugOpcode);
        /*0x1CB*/
        gateway.StoreOpcode(WorldOpcode.SMSG_NOTIFICATION, "SMSG_NOTIFICATION", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1CC*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PLAYED_TIME, "CMSG_PLAYED_TIME", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandlePlayedTime);
        /*0x1CD*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAYED_TIME, "SMSG_PLAYED_TIME", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x1CE*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUERY_TIME, "CMSG_QUERY_TIME", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleQueryTimeOpcode);
        /*0x1CF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUERY_TIME_RESPONSE, "SMSG_QUERY_TIME_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1D0*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOG_XPGAIN, "SMSG_LOG_XPGAIN", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x1D1*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AURACASTLOG, "SMSG_AURACASTLOG", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x1D2*/
        gateway.StoreOpcode(WorldOpcode.CMSG_RECLAIM_CORPSE, "CMSG_RECLAIM_CORPSE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleReclaimCorpseOpcode);
        /*0x1D3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_WRAP_ITEM, "CMSG_WRAP_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleWrapItemOpcode);
        /*0x1D4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LEVELUP_INFO, "SMSG_LEVELUP_INFO", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1D5*/
        gateway.StoreOpcode(WorldOpcode.MSG_MINIMAP_PING, "MSG_MINIMAP_PING", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMinimapPingOpcode);
        /*0x1D6*/
        gateway.StoreOpcode(WorldOpcode.SMSG_RESISTLOG, "SMSG_RESISTLOG", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x1D7*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ENCHANTMENTLOG, "SMSG_ENCHANTMENTLOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1D8*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_SKILL_CHEAT, "CMSG_SET_SKILL_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x1D9*/
        gateway.StoreOpcode(WorldOpcode.SMSG_START_MIRROR_TIMER, "SMSG_START_MIRROR_TIMER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1DA*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PAUSE_MIRROR_TIMER, "SMSG_PAUSE_MIRROR_TIMER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1DB*/
        gateway.StoreOpcode(WorldOpcode.SMSG_STOP_MIRROR_TIMER, "SMSG_STOP_MIRROR_TIMER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1DC*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PING, "CMSG_PING", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_EarlyProccess);
        /*0x1DD*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PONG, "SMSG_PONG", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x1DE*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CLEAR_COOLDOWN, "SMSG_CLEAR_COOLDOWN", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1DF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GAMEOBJECT_PAGETEXT, "SMSG_GAMEOBJECT_PAGETEXT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1E0*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SETSHEATHED, "CMSG_SETSHEATHED", SessionStatus.LOGGEDIN,
            PacketProcessing.INPLACE, gateway.HandleSetSheathedOpcode);
        /*0x1E1*/
        gateway.StoreOpcode(WorldOpcode.SMSG_COOLDOWN_CHEAT, "SMSG_COOLDOWN_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1E2*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELL_DELAYED, "SMSG_SPELL_DELAYED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1E3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PLAYER_MACRO_OBSOLETE, "CMSG_PLAYER_MACRO_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x1E4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAYER_MACRO_OBSOLETE, "SMSG_PLAYER_MACRO_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1E5*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GHOST, "CMSG_GHOST", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x1E6*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_INVIS, "CMSG_GM_INVIS", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x1E7*/
        gateway.StoreOpcode(WorldOpcode.SMSG_INVALID_PROMOTION_CODE, "SMSG_INVALID_PROMOTION_CODE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1E8*/
        gateway.StoreOpcode(WorldOpcode.MSG_GM_BIND_OTHER, "MSG_GM_BIND_OTHER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x1E9*/
        gateway.StoreOpcode(WorldOpcode.MSG_GM_SUMMON, "MSG_GM_SUMMON", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x1EA*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ITEM_TIME_UPDATE, "SMSG_ITEM_TIME_UPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1EB*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ITEM_ENCHANT_TIME_UPDATE, "SMSG_ITEM_ENCHANT_TIME_UPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1EC*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AUTH_CHALLENGE, "SMSG_AUTH_CHALLENGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1ED*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTH_SESSION, "CMSG_AUTH_SESSION", SessionStatus.NEVER,
            PacketProcessing.THREADSAFE, gateway.Handle_EarlyProccess);
        /*0x1EE*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AUTH_RESPONSE, "SMSG_AUTH_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1EF*/
        gateway.StoreOpcode(WorldOpcode.MSG_GM_SHOWLABEL, "MSG_GM_SHOWLABEL", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x1F0*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PET_CAST_SPELL, "CMSG_PET_CAST_SPELL", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePetCastSpellOpcode);
        /*0x1F1*/
        gateway.StoreOpcode(WorldOpcode.MSG_SAVE_GUILD_EMBLEM, "MSG_SAVE_GUILD_EMBLEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSaveGuildEmblemOpcode);
        /*0x1F2*/
        gateway.StoreOpcode(WorldOpcode.MSG_TABARDVENDOR_ACTIVATE, "MSG_TABARDVENDOR_ACTIVATE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleTabardVendorActivateOpcode);
        /*0x1F3*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAY_SPELL_VISUAL, "SMSG_PLAY_SPELL_VISUAL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1F4*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ZONEUPDATE, "CMSG_ZONEUPDATE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleZoneUpdateOpcode);
        /*0x1F5*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PARTYKILLLOG, "SMSG_PARTYKILLLOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1F6*/
        gateway.StoreOpcode(WorldOpcode.SMSG_COMPRESSED_UPDATE_OBJECT, "SMSG_COMPRESSED_UPDATE_OBJECT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1F7*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAY_SPELL_IMPACT, "SMSG_PLAY_SPELL_IMPACT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1F8*/
        gateway.StoreOpcode(WorldOpcode.SMSG_EXPLORATION_EXPERIENCE, "SMSG_EXPLORATION_EXPERIENCE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1F9*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_SET_SECURITY_GROUP, "CMSG_GM_SET_SECURITY_GROUP", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x1FA*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_NUKE, "CMSG_GM_NUKE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x1FB*/
        gateway.StoreOpcode(WorldOpcode.MSG_RANDOM_ROLL, "MSG_RANDOM_ROLL", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleRandomRollOpcode);
        /*0x1FC*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ENVIRONMENTALDAMAGELOG, "SMSG_ENVIRONMENTALDAMAGELOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x1FD*/
        gateway.StoreOpcode(WorldOpcode.CMSG_RWHOIS_OBSOLETE, "CMSG_RWHOIS_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x1FE*/
        gateway.StoreOpcode(WorldOpcode.SMSG_RWHOIS, "SMSG_RWHOIS", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x201*/
        gateway.StoreOpcode(WorldOpcode.CMSG_UNLEARN_SPELL, "CMSG_UNLEARN_SPELL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x202*/
        gateway.StoreOpcode(WorldOpcode.CMSG_UNLEARN_SKILL, "CMSG_UNLEARN_SKILL", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleUnlearnSkillOpcode);
        /*0x203*/
        gateway.StoreOpcode(WorldOpcode.SMSG_REMOVED_SPELL, "SMSG_REMOVED_SPELL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x204*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DECHARGE, "CMSG_DECHARGE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x205*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GMTICKET_CREATE, "CMSG_GMTICKET_CREATE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGMTicketCreateOpcode);
        /*0x206*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GMTICKET_CREATE, "SMSG_GMTICKET_CREATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x207*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GMTICKET_UPDATETEXT, "CMSG_GMTICKET_UPDATETEXT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGMTicketUpdateTextOpcode);
        /*0x208*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GMTICKET_UPDATETEXT, "SMSG_GMTICKET_UPDATETEXT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x209*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ACCOUNT_DATA_TIMES, "SMSG_ACCOUNT_DATA_TIMES", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x20A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_REQUEST_ACCOUNT_DATA, "CMSG_REQUEST_ACCOUNT_DATA", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleRequestAccountData);
        /*0x20B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_UPDATE_ACCOUNT_DATA, "CMSG_UPDATE_ACCOUNT_DATA",
            SessionStatus.LOGGEDIN_OR_RECENTLY_LOGGEDOUT, PacketProcessing.THREADUNSAFE,
            gateway.HandleUpdateAccountData);
        /*0x20C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_UPDATE_ACCOUNT_DATA, "SMSG_UPDATE_ACCOUNT_DATA", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x20D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CLEAR_FAR_SIGHT_IMMEDIATE, "SMSG_CLEAR_FAR_SIGHT_IMMEDIATE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x20E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_POWERGAINLOG_OBSOLETE, "SMSG_POWERGAINLOG_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x20F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_TEACH, "CMSG_GM_TEACH", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x210*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_CREATE_ITEM_TARGET, "CMSG_GM_CREATE_ITEM_TARGET", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x211*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GMTICKET_GETTICKET, "CMSG_GMTICKET_GETTICKET", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGMTicketGetTicketOpcode);
        /*0x212*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GMTICKET_GETTICKET, "SMSG_GMTICKET_GETTICKET", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x213*/
        gateway.StoreOpcode(WorldOpcode.CMSG_UNLEARN_TALENTS, "CMSG_UNLEARN_TALENTS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x214*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GAMEOBJECT_SPAWN_ANIM_OBSOLETE, "SMSG_GAMEOBJECT_SPAWN_ANIM_OBSOLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x215*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GAMEOBJECT_DESPAWN_ANIM, "SMSG_GAMEOBJECT_DESPAWN_ANIM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x216*/
        gateway.StoreOpcode(WorldOpcode.MSG_CORPSE_QUERY, "MSG_CORPSE_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleCorpseQueryOpcode);
        /*0x217*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GMTICKET_DELETETICKET, "CMSG_GMTICKET_DELETETICKET", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGMTicketDeleteTicketOpcode);
        /*0x218*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GMTICKET_DELETETICKET, "SMSG_GMTICKET_DELETETICKET", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x219*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHAT_WRONG_FACTION, "SMSG_CHAT_WRONG_FACTION", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x21A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GMTICKET_SYSTEMSTATUS, "CMSG_GMTICKET_SYSTEMSTATUS", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGMTicketSystemStatusOpcode);
        /*0x21B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GMTICKET_SYSTEMSTATUS, "SMSG_GMTICKET_SYSTEMSTATUS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x21C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SPIRIT_HEALER_ACTIVATE, "CMSG_SPIRIT_HEALER_ACTIVATE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSpiritHealerActivateOpcode);
        /*0x21D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_STAT_CHEAT, "CMSG_SET_STAT_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x21E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SET_REST_START, "SMSG_SET_REST_START", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x21F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SKILL_BUY_STEP, "CMSG_SKILL_BUY_STEP", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x220*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SKILL_BUY_RANK, "CMSG_SKILL_BUY_RANK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x221*/
        gateway.StoreOpcode(WorldOpcode.CMSG_XP_CHEAT, "CMSG_XP_CHEAT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x222*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPIRIT_HEALER_CONFIRM, "SMSG_SPIRIT_HEALER_CONFIRM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x223*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHARACTER_POINT_CHEAT, "CMSG_CHARACTER_POINT_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x224*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GOSSIP_POI, "SMSG_GOSSIP_POI", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x225*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHAT_IGNORED, "CMSG_CHAT_IGNORED", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChatIgnoredOpcode);
        /*0x226*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_VISION, "CMSG_GM_VISION", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x227*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SERVER_COMMAND, "CMSG_SERVER_COMMAND", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x228*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_SILENCE, "CMSG_GM_SILENCE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x229*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_REVEALTO, "CMSG_GM_REVEALTO", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x22A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_RESURRECT, "CMSG_GM_RESURRECT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x22B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_SUMMONMOB, "CMSG_GM_SUMMONMOB", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x22C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_MOVECORPSE, "CMSG_GM_MOVECORPSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x22D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_FREEZE, "CMSG_GM_FREEZE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x22E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_UBERINVIS, "CMSG_GM_UBERINVIS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x22F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_REQUEST_PLAYER_INFO, "CMSG_GM_REQUEST_PLAYER_INFO", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x230*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GM_PLAYER_INFO, "SMSG_GM_PLAYER_INFO", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x231*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_RANK, "CMSG_GUILD_RANK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildRankOpcode);
        /*0x232*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_ADD_RANK, "CMSG_GUILD_ADD_RANK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildAddRankOpcode);
        /*0x233*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_DEL_RANK, "CMSG_GUILD_DEL_RANK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildDelRankOpcode);
        /*0x234*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_SET_PUBLIC_NOTE, "CMSG_GUILD_SET_PUBLIC_NOTE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildSetPublicNoteOpcode);
        /*0x235*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_SET_OFFICER_NOTE, "CMSG_GUILD_SET_OFFICER_NOTE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildSetOfficerNoteOpcode);
        /*0x236*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOGIN_VERIFY_WORLD, "SMSG_LOGIN_VERIFY_WORLD", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x237*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CLEAR_EXPLORATION, "CMSG_CLEAR_EXPLORATION", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x238*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SEND_MAIL, "CMSG_SEND_MAIL", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSendMail);
        /*0x239*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SEND_MAIL_RESULT, "SMSG_SEND_MAIL_RESULT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x23A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GET_MAIL_LIST, "CMSG_GET_MAIL_LIST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGetMailList);
        /*0x23B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MAIL_LIST_RESULT, "SMSG_MAIL_LIST_RESULT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x23C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BATTLEFIELD_LIST, "CMSG_BATTLEFIELD_LIST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleBattlefieldListOpcode);
        /*0x23D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BATTLEFIELD_LIST, "SMSG_BATTLEFIELD_LIST", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x23E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BATTLEFIELD_JOIN, "CMSG_BATTLEFIELD_JOIN", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x23F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BATTLEFIELD_WIN_OBSOLETE, "SMSG_BATTLEFIELD_WIN_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x240*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BATTLEFIELD_LOSE_OBSOLETE, "SMSG_BATTLEFIELD_LOSE_OBSOLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x241*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TAXICLEARNODE, "CMSG_TAXICLEARNODE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x242*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TAXIENABLENODE, "CMSG_TAXIENABLENODE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x243*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ITEM_TEXT_QUERY, "CMSG_ITEM_TEXT_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleItemTextQuery);
        /*0x244*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ITEM_TEXT_QUERY_RESPONSE, "SMSG_ITEM_TEXT_QUERY_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x245*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MAIL_TAKE_MONEY, "CMSG_MAIL_TAKE_MONEY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleMailTakeMoney);
        /*0x246*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MAIL_TAKE_ITEM, "CMSG_MAIL_TAKE_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleMailTakeItem);
        /*0x247*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MAIL_MARK_AS_READ, "CMSG_MAIL_MARK_AS_READ", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleMailMarkAsRead);
        /*0x248*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MAIL_RETURN_TO_SENDER, "CMSG_MAIL_RETURN_TO_SENDER", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleMailReturnToSender);
        /*0x249*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MAIL_DELETE, "CMSG_MAIL_DELETE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleMailDelete);
        /*0x24A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MAIL_CREATE_TEXT_ITEM, "CMSG_MAIL_CREATE_TEXT_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleMailCreateTextItem);
        /*0x24B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELLLOGMISS, "SMSG_SPELLLOGMISS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x24C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELLLOGEXECUTE, "SMSG_SPELLLOGEXECUTE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x24D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DEBUGAURAPROC, "SMSG_DEBUGAURAPROC", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x24E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PERIODICAURALOG, "SMSG_PERIODICAURALOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x24F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELLDAMAGESHIELD, "SMSG_SPELLDAMAGESHIELD", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x250*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELLNONMELEEDAMAGELOG, "SMSG_SPELLNONMELEEDAMAGELOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x251*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LEARN_TALENT, "CMSG_LEARN_TALENT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleLearnTalentOpcode);
        /*0x252*/
        gateway.StoreOpcode(WorldOpcode.SMSG_RESURRECT_FAILED, "SMSG_RESURRECT_FAILED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x253*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TOGGLE_PVP, "CMSG_TOGGLE_PVP", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleTogglePvP);
        /*0x254*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ZONE_UNDER_ATTACK, "SMSG_ZONE_UNDER_ATTACK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x255*/
        gateway.StoreOpcode(WorldOpcode.MSG_AUCTION_HELLO, "MSG_AUCTION_HELLO", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAuctionHelloOpcode);
        /*0x256*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUCTION_SELL_ITEM, "CMSG_AUCTION_SELL_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAuctionSellItem);
        /*0x257*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUCTION_REMOVE_ITEM, "CMSG_AUCTION_REMOVE_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAuctionRemoveItem);
        /*0x258*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUCTION_LIST_ITEMS, "CMSG_AUCTION_LIST_ITEMS", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAuctionListItems);
        /*0x259*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUCTION_LIST_OWNER_ITEMS, "CMSG_AUCTION_LIST_OWNER_ITEMS",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleAuctionListOwnerItems);
        /*0x25A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUCTION_PLACE_BID, "CMSG_AUCTION_PLACE_BID", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAuctionPlaceBid);
        /*0x25B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AUCTION_COMMAND_RESULT, "SMSG_AUCTION_COMMAND_RESULT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x25C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AUCTION_LIST_RESULT, "SMSG_AUCTION_LIST_RESULT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x25D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AUCTION_OWNER_LIST_RESULT, "SMSG_AUCTION_OWNER_LIST_RESULT",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x25E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AUCTION_BIDDER_NOTIFICATION, "SMSG_AUCTION_BIDDER_NOTIFICATION",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x25F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AUCTION_OWNER_NOTIFICATION, "SMSG_AUCTION_OWNER_NOTIFICATION",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x260*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PROCRESIST, "SMSG_PROCRESIST", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x261*/
        gateway.StoreOpcode(WorldOpcode.SMSG_STANDSTATE_CHANGE_FAILURE_OBSOLETE, "SMSG_STANDSTATE_CHANGE_FAILURE_OBSOLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x262*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DISPEL_FAILED, "SMSG_DISPEL_FAILED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x263*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELLORDAMAGE_IMMUNE, "SMSG_SPELLORDAMAGE_IMMUNE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x264*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUCTION_LIST_BIDDER_ITEMS, "CMSG_AUCTION_LIST_BIDDER_ITEMS",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleAuctionListBidderItems);
        /*0x265*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AUCTION_BIDDER_LIST_RESULT, "SMSG_AUCTION_BIDDER_LIST_RESULT",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x266*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SET_FLAT_SPELL_MODIFIER, "SMSG_SET_FLAT_SPELL_MODIFIER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x267*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SET_PCT_SPELL_MODIFIER, "SMSG_SET_PCT_SPELL_MODIFIER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x268*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_AMMO, "CMSG_SET_AMMO", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSetAmmoOpcode);
        /*0x269*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CORPSE_RECLAIM_DELAY, "SMSG_CORPSE_RECLAIM_DELAY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x26A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_ACTIVE_MOVER, "CMSG_SET_ACTIVE_MOVER", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSetActiveMoverOpcode);
        /*0x26B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PET_CANCEL_AURA, "CMSG_PET_CANCEL_AURA", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePetCancelAuraOpcode);
        /*0x26C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PLAYER_AI_CHEAT, "CMSG_PLAYER_AI_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x26D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CANCEL_AUTO_REPEAT_SPELL, "CMSG_CANCEL_AUTO_REPEAT_SPELL",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleCancelAutoRepeatSpellOpcode);
        /*0x26E*/
        gateway.StoreOpcode(WorldOpcode.MSG_GM_ACCOUNT_ONLINE, "MSG_GM_ACCOUNT_ONLINE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x26F*/
        gateway.StoreOpcode(WorldOpcode.MSG_LIST_STABLED_PETS, "MSG_LIST_STABLED_PETS", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleListStabledPetsOpcode);
        /*0x270*/
        gateway.StoreOpcode(WorldOpcode.CMSG_STABLE_PET, "CMSG_STABLE_PET", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleStablePet);
        /*0x271*/
        gateway.StoreOpcode(WorldOpcode.CMSG_UNSTABLE_PET, "CMSG_UNSTABLE_PET", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleUnstablePet);
        /*0x272*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BUY_STABLE_SLOT, "CMSG_BUY_STABLE_SLOT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleBuyStableSlot);
        /*0x273*/
        gateway.StoreOpcode(WorldOpcode.SMSG_STABLE_RESULT, "SMSG_STABLE_RESULT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x274*/
        gateway.StoreOpcode(WorldOpcode.CMSG_STABLE_REVIVE_PET, "CMSG_STABLE_REVIVE_PET", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleStableRevivePet);
        /*0x275*/
        gateway.StoreOpcode(WorldOpcode.CMSG_STABLE_SWAP_PET, "CMSG_STABLE_SWAP_PET", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleStableSwapPet);
        /*0x276*/
        gateway.StoreOpcode(WorldOpcode.MSG_QUEST_PUSH_RESULT, "MSG_QUEST_PUSH_RESULT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleQuestPushResult);
        /*0x277*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAY_MUSIC, "SMSG_PLAY_MUSIC", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x278*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAY_OBJECT_SOUND, "SMSG_PLAY_OBJECT_SOUND", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x279*/
        gateway.StoreOpcode(WorldOpcode.CMSG_REQUEST_PET_INFO, "CMSG_REQUEST_PET_INFO", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleRequestPetInfoOpcode);
        /*0x27A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FAR_SIGHT, "CMSG_FAR_SIGHT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleFarSightOpcode);
        /*0x27B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELLDISPELLOG, "SMSG_SPELLDISPELLOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x27C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DAMAGE_CALC_LOG, "SMSG_DAMAGE_CALC_LOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x27D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ENABLE_DAMAGE_LOG, "CMSG_ENABLE_DAMAGE_LOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x27E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_CHANGE_SUB_GROUP, "CMSG_GROUP_CHANGE_SUB_GROUP", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGroupChangeSubGroupOpcode);
        /*0x27F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_REQUEST_PARTY_MEMBER_STATS, "CMSG_REQUEST_PARTY_MEMBER_STATS",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleRequestPartyMemberStatsOpcode);
        /*0x280*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_SWAP_SUB_GROUP, "CMSG_GROUP_SWAP_SUB_GROUP", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGroupSwapSubGroupOpcode);
        /*0x281*/
        gateway.StoreOpcode(WorldOpcode.CMSG_RESET_FACTION_CHEAT, "CMSG_RESET_FACTION_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x282*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTOSTORE_BANK_ITEM, "CMSG_AUTOSTORE_BANK_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAutoStoreBankItemOpcode);
        /*0x283*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AUTOBANK_ITEM, "CMSG_AUTOBANK_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleAutoBankItemOpcode);
        /*0x284*/
        gateway.StoreOpcode(WorldOpcode.MSG_QUERY_NEXT_MAIL_TIME, "MSG_QUERY_NEXT_MAIL_TIME", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleQueryNextMailTime);
        /*0x285*/
        gateway.StoreOpcode(WorldOpcode.SMSG_RECEIVED_MAIL, "SMSG_RECEIVED_MAIL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x286*/
        gateway.StoreOpcode(WorldOpcode.SMSG_RAID_GROUP_ONLY, "SMSG_RAID_GROUP_ONLY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x287*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_DURABILITY_CHEAT, "CMSG_SET_DURABILITY_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x288*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_PVP_RANK_CHEAT, "CMSG_SET_PVP_RANK_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x289*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ADD_PVP_MEDAL_CHEAT, "CMSG_ADD_PVP_MEDAL_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x28A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DEL_PVP_MEDAL_CHEAT, "CMSG_DEL_PVP_MEDAL_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x28B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_PVP_TITLE, "CMSG_SET_PVP_TITLE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x28C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PVP_CREDIT, "SMSG_PVP_CREDIT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x28D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AUCTION_REMOVED_NOTIFICATION, "SMSG_AUCTION_REMOVED_NOTIFICATION",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x28E*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_RAID_CONVERT, "CMSG_GROUP_RAID_CONVERT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGroupRaidConvertOpcode);
        /*0x28F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUP_ASSISTANT_LEADER, "CMSG_GROUP_ASSISTANT_LEADER", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGroupAssistantLeaderOpcode);
        /*0x290*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BUYBACK_ITEM, "CMSG_BUYBACK_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleBuybackItem);
        /*0x291*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SERVER_MESSAGE, "SMSG_SERVER_MESSAGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x292*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MEETINGSTONE_JOIN, "CMSG_MEETINGSTONE_JOIN", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleMeetingStoneJoinOpcode);
        /*0x293*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MEETINGSTONE_LEAVE, "CMSG_MEETINGSTONE_LEAVE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x294*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MEETINGSTONE_CHEAT, "CMSG_MEETINGSTONE_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x295*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MEETINGSTONE_SETQUEUE, "SMSG_MEETINGSTONE_SETQUEUE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x296*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MEETINGSTONE_INFO, "CMSG_MEETINGSTONE_INFO", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleMeetingStoneInfoOpcode);
        /*0x297*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MEETINGSTONE_COMPLETE, "SMSG_MEETINGSTONE_COMPLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x298*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MEETINGSTONE_IN_PROGRESS, "SMSG_MEETINGSTONE_IN_PROGRESS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x299*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MEETINGSTONE_MEMBER_ADDED, "SMSG_MEETINGSTONE_MEMBER_ADDED",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x29A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GMTICKETSYSTEM_TOGGLE, "CMSG_GMTICKETSYSTEM_TOGGLE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x29B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CANCEL_GROWTH_AURA, "CMSG_CANCEL_GROWTH_AURA", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleCancelGrowthAuraOpcode);
        /*0x29C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CANCEL_AUTO_REPEAT, "SMSG_CANCEL_AUTO_REPEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x29D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_STANDSTATE_UPDATE, "SMSG_STANDSTATE_UPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x29E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_ALL_PASSED, "SMSG_LOOT_ALL_PASSED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x29F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_ROLL_WON, "SMSG_LOOT_ROLL_WON", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2A0*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LOOT_ROLL, "CMSG_LOOT_ROLL", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleLootRoll);
        /*0x2A1*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_START_ROLL, "SMSG_LOOT_START_ROLL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2A2*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_ROLL, "SMSG_LOOT_ROLL", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x2A3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LOOT_MASTER_GIVE, "CMSG_LOOT_MASTER_GIVE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleLootMasterGiveOpcode);
        /*0x2A4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_MASTER_LIST, "SMSG_LOOT_MASTER_LIST", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2A5*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SET_FORCED_REACTIONS, "SMSG_SET_FORCED_REACTIONS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2A6*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELL_FAILED_OTHER, "SMSG_SPELL_FAILED_OTHER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2A7*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GAMEOBJECT_RESET_STATE, "SMSG_GAMEOBJECT_RESET_STATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2A8*/
        gateway.StoreOpcode(WorldOpcode.CMSG_REPAIR_ITEM, "CMSG_REPAIR_ITEM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleRepairItemOpcode);
        /*0x2A9*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHAT_PLAYER_NOT_FOUND, "SMSG_CHAT_PLAYER_NOT_FOUND", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2AA*/
        gateway.StoreOpcode(WorldOpcode.MSG_TALENT_WIPE_CONFIRM, "MSG_TALENT_WIPE_CONFIRM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleTalentWipeConfirmOpcode);
        /*0x2AB*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SUMMON_REQUEST, "SMSG_SUMMON_REQUEST", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2AC*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SUMMON_RESPONSE, "CMSG_SUMMON_RESPONSE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSummonResponseOpcode);
        /*0x2AD*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_TOGGLE_GRAVITY_CHEAT, "MSG_MOVE_TOGGLE_GRAVITY_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x2AE*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MONSTER_MOVE_TRANSPORT, "SMSG_MONSTER_MOVE_TRANSPORT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2AF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PET_BROKEN, "SMSG_PET_BROKEN", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x2B0*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_FEATHER_FALL, "MSG_MOVE_FEATHER_FALL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x2B1*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_WATER_WALK, "MSG_MOVE_WATER_WALK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x2B2*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SERVER_BROADCAST, "CMSG_SERVER_BROADCAST", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x2B3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SELF_RES, "CMSG_SELF_RES", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSelfResOpcode);
        /*0x2B4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FEIGN_DEATH_RESISTED, "SMSG_FEIGN_DEATH_RESISTED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2B5*/
        gateway.StoreOpcode(WorldOpcode.CMSG_RUN_SCRIPT, "CMSG_RUN_SCRIPT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x2B6*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SCRIPT_MESSAGE, "SMSG_SCRIPT_MESSAGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2B7*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DUEL_COUNTDOWN, "SMSG_DUEL_COUNTDOWN", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2B8*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AREA_TRIGGER_MESSAGE, "SMSG_AREA_TRIGGER_MESSAGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2B9*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TOGGLE_HELM, "CMSG_TOGGLE_HELM", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleShowingHelmOpcode);
        /*0x2BA*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TOGGLE_CLOAK, "CMSG_TOGGLE_CLOAK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleShowingCloakOpcode);
        /*0x2BB*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MEETINGSTONE_JOINFAILED, "SMSG_MEETINGSTONE_JOINFAILED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2BC*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAYER_SKINNED, "SMSG_PLAYER_SKINNED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2BD*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DURABILITY_DAMAGE_DEATH, "SMSG_DURABILITY_DAMAGE_DEATH", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2BE*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_EXPLORATION, "CMSG_SET_EXPLORATION", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x2BF*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_ACTIONBAR_TOGGLES, "CMSG_SET_ACTIONBAR_TOGGLES", SessionStatus.AUTHED,
            PacketProcessing.THREADUNSAFE, gateway.HandleSetActionBarTogglesOpcode);
        /*0x2C0*/
        gateway.StoreOpcode(WorldOpcode.UMSG_DELETE_GUILD_CHARTER, "UMSG_DELETE_GUILD_CHARTER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x2C1*/
        gateway.StoreOpcode(WorldOpcode.MSG_PETITION_RENAME, "MSG_PETITION_RENAME", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePetitionRenameOpcode);
        /*0x2C2*/
        gateway.StoreOpcode(WorldOpcode.SMSG_INIT_WORLD_STATES, "SMSG_INIT_WORLD_STATES", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2C3*/
        gateway.StoreOpcode(WorldOpcode.SMSG_UPDATE_WORLD_STATE, "SMSG_UPDATE_WORLD_STATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2C4*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ITEM_NAME_QUERY, "CMSG_ITEM_NAME_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleItemNameQueryOpcode);
        /*0x2C5*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ITEM_NAME_QUERY_RESPONSE, "SMSG_ITEM_NAME_QUERY_RESPONSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2C6*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PET_ACTION_FEEDBACK, "SMSG_PET_ACTION_FEEDBACK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2C7*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHAR_RENAME, "CMSG_CHAR_RENAME", SessionStatus.AUTHED,
            PacketProcessing.THREADUNSAFE, gateway.HandleCharRenameOpcode);
        /*0x2C8*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHAR_RENAME, "SMSG_CHAR_RENAME", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x2C9*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_SPLINE_DONE, "CMSG_MOVE_SPLINE_DONE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMoveSplineDoneOpcode);
        /*0x2CA*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_FALL_RESET, "CMSG_MOVE_FALL_RESET", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x2CB*/
        gateway.StoreOpcode(WorldOpcode.SMSG_INSTANCE_SAVE_CREATED, "SMSG_INSTANCE_SAVE_CREATED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2CC*/
        gateway.StoreOpcode(WorldOpcode.SMSG_RAID_INSTANCE_INFO, "SMSG_RAID_INSTANCE_INFO", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2CD*/
        gateway.StoreOpcode(WorldOpcode.CMSG_REQUEST_RAID_INFO, "CMSG_REQUEST_RAID_INFO", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleRequestRaidInfoOpcode);
        /*0x2CE*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_TIME_SKIPPED, "CMSG_MOVE_TIME_SKIPPED", SessionStatus.LOGGEDIN,
            PacketProcessing.INPLACE, gateway.HandleMoveTimeSkippedOpcode);
        /*0x2CF*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_FEATHER_FALL_ACK, "CMSG_MOVE_FEATHER_FALL_ACK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMoveFlagChangeOpcode);
        /*0x2D0*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_WATER_WALK_ACK, "CMSG_MOVE_WATER_WALK_ACK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMoveFlagChangeOpcode);
        /*0x2D1*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_NOT_ACTIVE_MOVER, "CMSG_MOVE_NOT_ACTIVE_MOVER", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMoveNotActiveMoverOpcode);
        /*0x2D2*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAY_SOUND, "SMSG_PLAY_SOUND", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x2D3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BATTLEFIELD_STATUS, "CMSG_BATTLEFIELD_STATUS", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleBattlefieldStatusOpcode);
        /*0x2D4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BATTLEFIELD_STATUS, "SMSG_BATTLEFIELD_STATUS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2D5*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BATTLEFIELD_PORT, "CMSG_BATTLEFIELD_PORT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleBattlefieldPortOpcode);
        /*0x2D6*/
        gateway.StoreOpcode(WorldOpcode.MSG_INSPECT_HONOR_STATS, "MSG_INSPECT_HONOR_STATS", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleInspectHonorStatsOpcode);
        /*0x2D7*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BATTLEMASTER_HELLO, "CMSG_BATTLEMASTER_HELLO", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleBattlemasterHelloOpcode);
        /*0x2D8*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_START_SWIM_CHEAT, "CMSG_MOVE_START_SWIM_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x2D9*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_STOP_SWIM_CHEAT, "CMSG_MOVE_STOP_SWIM_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x2DA*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FORCE_WALK_SPEED_CHANGE, "SMSG_FORCE_WALK_SPEED_CHANGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2DB*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FORCE_WALK_SPEED_CHANGE_ACK, "CMSG_FORCE_WALK_SPEED_CHANGE_ACK",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADSAFE, gateway.HandleForceSpeedChangeAckOpcodes);
        /*0x2DC*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FORCE_SWIM_BACK_SPEED_CHANGE, "SMSG_FORCE_SWIM_BACK_SPEED_CHANGE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2DD*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FORCE_SWIM_BACK_SPEED_CHANGE_ACK, "CMSG_FORCE_SWIM_BACK_SPEED_CHANGE_ACK",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADSAFE, gateway.HandleForceSpeedChangeAckOpcodes);
        /*0x2DE*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FORCE_TURN_RATE_CHANGE, "SMSG_FORCE_TURN_RATE_CHANGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2DF*/
        gateway.StoreOpcode(WorldOpcode.CMSG_FORCE_TURN_RATE_CHANGE_ACK, "CMSG_FORCE_TURN_RATE_CHANGE_ACK",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADSAFE, gateway.HandleForceSpeedChangeAckOpcodes);
        /*0x2E0*/
        gateway.StoreOpcode(WorldOpcode.MSG_PVP_LOG_DATA, "MSG_PVP_LOG_DATA", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePVPLogDataOpcode);
        /*0x2E1*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LEAVE_BATTLEFIELD, "CMSG_LEAVE_BATTLEFIELD", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleLeaveBattlefieldOpcode);
        /*0x2E2*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AREA_SPIRIT_HEALER_QUERY, "CMSG_AREA_SPIRIT_HEALER_QUERY",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleAreaSpiritHealerQueryOpcode);
        /*0x2E3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_AREA_SPIRIT_HEALER_QUEUE, "CMSG_AREA_SPIRIT_HEALER_QUEUE",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleAreaSpiritHealerQueueOpcode);
        /*0x2E4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_AREA_SPIRIT_HEALER_TIME, "SMSG_AREA_SPIRIT_HEALER_TIME", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2E5*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_UNTEACH, "CMSG_GM_UNTEACH", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x2E6*/
        gateway.StoreOpcode(WorldOpcode.SMSG_WARDEN_DATA, "SMSG_WARDEN_DATA", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x2E7*/
        gateway.StoreOpcode(WorldOpcode.CMSG_WARDEN_DATA, "CMSG_WARDEN_DATA", SessionStatus.AUTHED,
            PacketProcessing.THREADUNSAFE, gateway.HandleWardenDataOpcode);
        /*0x2E8*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GROUP_JOINED_BATTLEGROUND, "SMSG_GROUP_JOINED_BATTLEGROUND",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2E9*/
        gateway.StoreOpcode(WorldOpcode.MSG_BATTLEGROUND_PLAYER_POSITIONS, "MSG_BATTLEGROUND_PLAYER_POSITIONS",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleBattleGroundPlayerPositionsOpcode);
        /*0x2EA*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PET_STOP_ATTACK, "CMSG_PET_STOP_ATTACK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePetStopAttack);
        /*0x2EB*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BINDER_CONFIRM, "SMSG_BINDER_CONFIRM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2EC*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BATTLEGROUND_PLAYER_JOINED, "SMSG_BATTLEGROUND_PLAYER_JOINED",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2ED*/
        gateway.StoreOpcode(WorldOpcode.SMSG_BATTLEGROUND_PLAYER_LEFT, "SMSG_BATTLEGROUND_PLAYER_LEFT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2EE*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BATTLEMASTER_JOIN, "CMSG_BATTLEMASTER_JOIN", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleBattlemasterJoinOpcode);
        /*0x2EF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ADDON_INFO, "SMSG_ADDON_INFO", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x2F0*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PET_UNLEARN, "CMSG_PET_UNLEARN", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePetUnlearnOpcode);
        /*0x2F1*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PET_UNLEARN_CONFIRM, "SMSG_PET_UNLEARN_CONFIRM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2F2*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PARTY_MEMBER_STATS_FULL, "SMSG_PARTY_MEMBER_STATS_FULL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2F3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PET_SPELL_AUTOCAST, "CMSG_PET_SPELL_AUTOCAST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePetSpellAutocastOpcode);
        /*0x2F4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_WEATHER, "SMSG_WEATHER", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x2F5*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PLAY_TIME_WARNING, "SMSG_PLAY_TIME_WARNING", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2F6*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MINIGAME_SETUP, "SMSG_MINIGAME_SETUP", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2F7*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MINIGAME_STATE, "SMSG_MINIGAME_STATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2F8*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MINIGAME_MOVE, "CMSG_MINIGAME_MOVE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x2F9*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MINIGAME_MOVE_FAILED, "SMSG_MINIGAME_MOVE_FAILED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2FA*/
        gateway.StoreOpcode(WorldOpcode.SMSG_RAID_INSTANCE_MESSAGE, "SMSG_RAID_INSTANCE_MESSAGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2FB*/
        gateway.StoreOpcode(WorldOpcode.SMSG_COMPRESSED_MOVES, "SMSG_COMPRESSED_MOVES", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2FC*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GUILD_INFO_TEXT, "CMSG_GUILD_INFO_TEXT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildChangeInfoTextOpcode);
        /*0x2FD*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHAT_RESTRICTED, "SMSG_CHAT_RESTRICTED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2FE*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_SET_RUN_SPEED, "SMSG_SPLINE_SET_RUN_SPEED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x2FF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_SET_RUN_BACK_SPEED, "SMSG_SPLINE_SET_RUN_BACK_SPEED",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x300*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_SET_SWIM_SPEED, "SMSG_SPLINE_SET_SWIM_SPEED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x301*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_SET_WALK_SPEED, "SMSG_SPLINE_SET_WALK_SPEED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x302*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_SET_SWIM_BACK_SPEED, "SMSG_SPLINE_SET_SWIM_BACK_SPEED",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x303*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_SET_TURN_RATE, "SMSG_SPLINE_SET_TURN_RATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x304*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_UNROOT, "SMSG_SPLINE_MOVE_UNROOT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x305*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_FEATHER_FALL, "SMSG_SPLINE_MOVE_FEATHER_FALL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x306*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_NORMAL_FALL, "SMSG_SPLINE_MOVE_NORMAL_FALL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x307*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_SET_HOVER, "SMSG_SPLINE_MOVE_SET_HOVER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x308*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_UNSET_HOVER, "SMSG_SPLINE_MOVE_UNSET_HOVER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x309*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_WATER_WALK, "SMSG_SPLINE_MOVE_WATER_WALK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x30A*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_LAND_WALK, "SMSG_SPLINE_MOVE_LAND_WALK", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x30B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_START_SWIM, "SMSG_SPLINE_MOVE_START_SWIM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x30C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_STOP_SWIM, "SMSG_SPLINE_MOVE_STOP_SWIM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x30D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_SET_RUN_MODE, "SMSG_SPLINE_MOVE_SET_RUN_MODE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x30E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_SET_WALK_MODE, "SMSG_SPLINE_MOVE_SET_WALK_MODE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x30F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_NUKE_ACCOUNT, "CMSG_GM_NUKE_ACCOUNT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x310*/
        gateway.StoreOpcode(WorldOpcode.MSG_GM_DESTROY_CORPSE, "MSG_GM_DESTROY_CORPSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x311*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_DESTROY_ONLINE_CORPSE, "CMSG_GM_DESTROY_ONLINE_CORPSE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x312*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ACTIVATETAXIEXPRESS, "CMSG_ACTIVATETAXIEXPRESS", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleActivateTaxiExpressOpcode);
        /*0x313*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SET_FACTION_ATWAR, "SMSG_SET_FACTION_ATWAR", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x314*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GAMETIMEBIAS_SET, "SMSG_GAMETIMEBIAS_SET", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x315*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DEBUG_ACTIONS_START, "CMSG_DEBUG_ACTIONS_START", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x316*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DEBUG_ACTIONS_STOP, "CMSG_DEBUG_ACTIONS_STOP", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x317*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_FACTION_INACTIVE, "CMSG_SET_FACTION_INACTIVE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSetFactionInactiveOpcode);
        /*0x318*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_WATCHED_FACTION, "CMSG_SET_WATCHED_FACTION", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSetWatchedFactionOpcode);
        /*0x319*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_TIME_SKIPPED, "MSG_MOVE_TIME_SKIPPED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x31A*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPLINE_MOVE_ROOT, "SMSG_SPLINE_MOVE_ROOT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x31B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_EXPLORATION_ALL, "CMSG_SET_EXPLORATION_ALL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x31C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_INVALIDATE_PLAYER, "SMSG_INVALIDATE_PLAYER", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x31D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_RESET_INSTANCES, "CMSG_RESET_INSTANCES", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleResetInstancesOpcode);
        /*0x31E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_INSTANCE_RESET, "SMSG_INSTANCE_RESET", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x31F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_INSTANCE_RESET_FAILED, "SMSG_INSTANCE_RESET_FAILED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x320*/
        gateway.StoreOpcode(WorldOpcode.SMSG_UPDATE_LAST_INSTANCE, "SMSG_UPDATE_LAST_INSTANCE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x321*/
        gateway.StoreOpcode(WorldOpcode.MSG_RAID_TARGET_UPDATE, "MSG_RAID_TARGET_UPDATE", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleRaidTargetUpdateOpcode);
        /*0x322*/
        gateway.StoreOpcode(WorldOpcode.MSG_RAID_READY_CHECK, "MSG_RAID_READY_CHECK", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleRaidReadyCheckOpcode);
        /*0x323*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LUA_USAGE, "CMSG_LUA_USAGE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x324*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PET_ACTION_SOUND, "SMSG_PET_ACTION_SOUND", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x325*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PET_DISMISS_SOUND, "SMSG_PET_DISMISS_SOUND", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x326*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GHOSTEE_GONE, "SMSG_GHOSTEE_GONE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x327*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GM_UPDATE_TICKET_STATUS, "CMSG_GM_UPDATE_TICKET_STATUS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x328*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GM_TICKET_STATUS_UPDATE, "SMSG_GM_TICKET_STATUS_UPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x32A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GMSURVEY_SUBMIT, "CMSG_GMSURVEY_SUBMIT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGMSurveySubmitOpcode);
        /*0x32B*/
        gateway.StoreOpcode(WorldOpcode.SMSG_UPDATE_INSTANCE_OWNERSHIP, "SMSG_UPDATE_INSTANCE_OWNERSHIP",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x32C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_IGNORE_KNOCKBACK_CHEAT, "CMSG_IGNORE_KNOCKBACK_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x32D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHAT_PLAYER_AMBIGUOUS, "SMSG_CHAT_PLAYER_AMBIGUOUS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x32E*/
        gateway.StoreOpcode(WorldOpcode.MSG_DELAY_GHOST_TELEPORT, "MSG_DELAY_GHOST_TELEPORT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x32F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELLINSTAKILLLOG, "SMSG_SPELLINSTAKILLLOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x330*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELL_UPDATE_CHAIN_TARGETS, "SMSG_SPELL_UPDATE_CHAIN_TARGETS",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x331*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHAT_FILTERED, "CMSG_CHAT_FILTERED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x332*/
        gateway.StoreOpcode(WorldOpcode.SMSG_EXPECTED_SPAM_RECORDS, "SMSG_EXPECTED_SPAM_RECORDS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x333*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELLSTEALLOG, "SMSG_SPELLSTEALLOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x334*/
        gateway.StoreOpcode(WorldOpcode.CMSG_LOTTERY_QUERY_OBSOLETE, "CMSG_LOTTERY_QUERY_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x335*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOTTERY_QUERY_RESULT_OBSOLETE, "SMSG_LOTTERY_QUERY_RESULT_OBSOLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x336*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BUY_LOTTERY_TICKET_OBSOLETE, "CMSG_BUY_LOTTERY_TICKET_OBSOLETE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x337*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOTTERY_RESULT_OBSOLETE, "SMSG_LOTTERY_RESULT_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x338*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHARACTER_PROFILE, "SMSG_CHARACTER_PROFILE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x339*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHARACTER_PROFILE_REALM_CONNECTED, "SMSG_CHARACTER_PROFILE_REALM_CONNECTED",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x33A*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DEFENSE_MESSAGE, "SMSG_DEFENSE_MESSAGE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x33C*/
        gateway.StoreOpcode(WorldOpcode.MSG_GM_RESETINSTANCELIMIT, "MSG_GM_RESETINSTANCELIMIT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x33E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MOVE_SET_FLIGHT, "SMSG_MOVE_SET_FLIGHT_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x33F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MOVE_UNSET_FLIGHT, "SMSG_MOVE_UNSET_FLIGHT_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x340*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_FLIGHT_ACK, "CMSG_MOVE_FLIGHT_ACK_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x341*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_START_SWIM_CHEAT, "MSG_MOVE_START_SWIM_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x342*/
        gateway.StoreOpcode(WorldOpcode.MSG_MOVE_STOP_SWIM_CHEAT, "MSG_MOVE_STOP_SWIM_CHEAT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);

        // [-ZERO] Last existed in 1.12.1 opcode, maybe some renumbering from other side
        /*0x375*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CANCEL_MOUNT_AURA, "CMSG_CANCEL_MOUNT_AURA", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleCancelMountAuraOpcode);
        /*0x379*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CANCEL_TEMP_ENCHANTMENT, "CMSG_CANCEL_TEMP_ENCHANTMENT",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleCancelTempEnchantmentOpcode);
        /*0x389*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_TAXI_BENCHMARK_MODE, "CMSG_SET_TAXI_BENCHMARK_MODE", SessionStatus.AUTHED,
            PacketProcessing.THREADUNSAFE, gateway.HandleSetTaxiBenchmarkOpcode);
        /*0x38D*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_CHNG_TRANSPORT, "CMSG_MOVE_CHNG_TRANSPORT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADSAFE, gateway.HandleMovementOpcodes);
        /*0x38E*/
        gateway.StoreOpcode(WorldOpcode.MSG_PARTY_ASSIGNMENT, "MSG_PARTY_ASSIGNMENT", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandlePartyAssignmentOpcode);
        /*0x38F*/
        gateway.StoreOpcode(WorldOpcode.SMSG_OFFER_PETITION_ERROR, "SMSG_OFFER_PETITION_ERROR", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x396*/
        gateway.StoreOpcode(WorldOpcode.SMSG_RESET_FAILED_NOTIFY, "SMSG_RESET_FAILED_NOTIFY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x397*/
        gateway.StoreOpcode(WorldOpcode.SMSG_REAL_GROUP_UPDATE, "SMSG_REAL_GROUP_UPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3A3*/
        gateway.StoreOpcode(WorldOpcode.SMSG_INIT_EXTRA_AURA_INFO, "SMSG_INIT_EXTRA_AURA_INFO", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3A4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SET_EXTRA_AURA_INFO, "SMSG_SET_EXTRA_AURA_INFO", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3A5*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SET_EXTRA_AURA_INFO_NEED_UPDATE, "SMSG_SET_EXTRA_AURA_INFO_NEED_UPDATE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3AA*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELL_CHANCE_PROC_LOG, "SMSG_SPELL_CHANCE_PROC_LOG", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3AB*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MOVE_SET_RUN_SPEED, "CMSG_MOVE_SET_RUN_SPEED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x3AC*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DISMOUNT, "SMSG_DISMOUNT", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x3AE*/
        gateway.StoreOpcode(WorldOpcode.MSG_RAID_READY_CHECK_CONFIRM, "MSG_RAID_READY_CHECK_CONFIRM", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x3BE*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CLEAR_TARGET, "SMSG_CLEAR_TARGET", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3BF*/
        gateway.StoreOpcode(WorldOpcode.CMSG_BOT_DETECTED, "CMSG_BOT_DETECTED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x3C4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_KICK_REASON, "SMSG_KICK_REASON", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x3C5*/
        gateway.StoreOpcode(WorldOpcode.MSG_RAID_READY_CHECK_FINISHED, "MSG_RAID_READY_CHECK_FINISHED",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleRaidReadyCheckFinishedOpcode);
        /*0x3CF*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TARGET_CAST, "CMSG_TARGET_CAST", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x3D0*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TARGET_SCRIPT_CAST, "CMSG_TARGET_SCRIPT_CAST", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x3D1*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CHANNEL_DISPLAY_LIST, "CMSG_CHANNEL_DISPLAY_LIST", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleChannelDisplayListQueryOpcode);
        /*0x3D3*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GET_CHANNEL_MEMBER_COUNT, "CMSG_GET_CHANNEL_MEMBER_COUNT",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleGetChannelMemberCountOpcode);
        /*0x3D4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_CHANNEL_MEMBER_COUNT, "SMSG_CHANNEL_MEMBER_COUNT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3D7*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DEBUG_LIST_TARGETS, "CMSG_DEBUG_LIST_TARGETS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x3D8*/
        gateway.StoreOpcode(WorldOpcode.SMSG_DEBUG_LIST_TARGETS, "SMSG_DEBUG_LIST_TARGETS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3DC*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PARTY_SILENCE, "CMSG_PARTY_SILENCE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x3DD*/
        gateway.StoreOpcode(WorldOpcode.CMSG_PARTY_UNSILENCE, "CMSG_PARTY_UNSILENCE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x3DE*/
        gateway.StoreOpcode(WorldOpcode.MSG_NOTIFY_PARTY_SQUELCH, "MSG_NOTIFY_PARTY_SQUELCH", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x3DF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_COMSAT_RECONNECT_TRY, "SMSG_COMSAT_RECONNECT_TRY", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3E0*/
        gateway.StoreOpcode(WorldOpcode.SMSG_COMSAT_DISCONNECT, "SMSG_COMSAT_DISCONNECT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3E1*/
        gateway.StoreOpcode(WorldOpcode.SMSG_COMSAT_CONNECT_FAIL, "SMSG_COMSAT_CONNECT_FAIL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3EE*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_CHANNEL_WATCH, "CMSG_SET_CHANNEL_WATCH", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleSetChannelWatchOpcode);
        /*0x3EF*/
        gateway.StoreOpcode(WorldOpcode.SMSG_USERLIST_ADD, "SMSG_USERLIST_ADD", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3F0*/
        gateway.StoreOpcode(WorldOpcode.SMSG_USERLIST_REMOVE, "SMSG_USERLIST_REMOVE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3F1*/
        gateway.StoreOpcode(WorldOpcode.SMSG_USERLIST_UPDATE, "SMSG_USERLIST_UPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3F2*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CLEAR_CHANNEL_WATCH, "CMSG_CLEAR_CHANNEL_WATCH", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x3F4*/
        gateway.StoreOpcode(WorldOpcode.SMSG_GOGOGO_OBSOLETE, "SMSG_GOGOGO_OBSOLETE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3F5*/
        gateway.StoreOpcode(WorldOpcode.SMSG_ECHO_PARTY_SQUELCH, "SMSG_ECHO_PARTY_SQUELCH", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x3F7*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SPELLCLICK, "CMSG_SPELLCLICK", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x3F8*/
        gateway.StoreOpcode(WorldOpcode.SMSG_LOOT_LIST, "SMSG_LOOT_LIST", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_ServerSide);
        /*0x3FE*/
        gateway.StoreOpcode(WorldOpcode.MSG_GUILD_EVENT_LOG_QUERY, "MSG_GUILD_EVENT_LOG_QUERY", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleGuildEventLogQueryOpcode);
        /*0x3FF*/
        gateway.StoreOpcode(WorldOpcode.CMSG_MAELSTROM_RENAME_GUILD, "CMSG_MAELSTROM_RENAME_GUILD", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x400*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GET_MIRRORIMAGE_DATA, "CMSG_GET_MIRRORIMAGE_DATA", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x401*/
        gateway.StoreOpcode(WorldOpcode.SMSG_MIRRORIMAGE_DATA, "SMSG_MIRRORIMAGE_DATA", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x402*/
        gateway.StoreOpcode(WorldOpcode.SMSG_FORCE_DISPLAY_UPDATE, "SMSG_FORCE_DISPLAY_UPDATE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x403*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SPELL_CHANCE_RESIST_PUSHBACK, "SMSG_SPELL_CHANCE_RESIST_PUSHBACK",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x404*/
        gateway.StoreOpcode(WorldOpcode.CMSG_IGNORE_DIMINISHING_RETURNS_CHEAT, "CMSG_IGNORE_DIMINISHING_RETURNS_CHEAT",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x405*/
        gateway.StoreOpcode(WorldOpcode.SMSG_IGNORE_DIMINISHING_RETURNS_CHEAT, "SMSG_IGNORE_DIMINISHING_RETURNS_CHEAT",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x406*/
        gateway.StoreOpcode(WorldOpcode.CMSG_KEEP_ALIVE, "CMSG_KEEP_ALIVE", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_EarlyProccess);
        /*0x407*/
        gateway.StoreOpcode(WorldOpcode.SMSG_RAID_READY_CHECK_ERROR, "SMSG_RAID_READY_CHECK_ERROR", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x408*/
        gateway.StoreOpcode(WorldOpcode.CMSG_OPT_OUT_OF_LOOT, "CMSG_OPT_OUT_OF_LOOT", SessionStatus.AUTHED,
            PacketProcessing.THREADUNSAFE, gateway.HandleOptOutOfLootOpcode);
        /*0x40B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_SET_GRANTABLE_LEVELS, "CMSG_SET_GRANTABLE_LEVELS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x40C*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GRANT_LEVEL, "CMSG_GRANT_LEVEL", SessionStatus.NEVER, PacketProcessing.INPLACE,
            gateway.Handle_NULL);
        /*0x40F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_DECLINE_CHANNEL_INVITE, "CMSG_DECLINE_CHANNEL_INVITE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x410*/
        gateway.StoreOpcode(WorldOpcode.CMSG_GROUPACTION_THROTTLED, "CMSG_GROUPACTION_THROTTLED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x411*/
        gateway.StoreOpcode(WorldOpcode.SMSG_OVERRIDE_LIGHT, "SMSG_OVERRIDE_LIGHT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x412*/
        gateway.StoreOpcode(WorldOpcode.SMSG_TOTEM_CREATED, "SMSG_TOTEM_CREATED", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x413*/
        gateway.StoreOpcode(WorldOpcode.CMSG_TOTEM_DESTROYED, "CMSG_TOTEM_DESTROYED", SessionStatus.LOGGEDIN,
            PacketProcessing.THREADUNSAFE, gateway.HandleTotemDestroyed);
        /*0x414*/
        gateway.StoreOpcode(WorldOpcode.CMSG_EXPIRE_RAID_INSTANCE, "CMSG_EXPIRE_RAID_INSTANCE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x415*/
        gateway.StoreOpcode(WorldOpcode.CMSG_NO_SPELL_VARIANCE, "CMSG_NO_SPELL_VARIANCE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x416*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUESTGIVER_STATUS_MULTIPLE_QUERY, "CMSG_QUESTGIVER_STATUS_MULTIPLE_QUERY",
            SessionStatus.LOGGEDIN, PacketProcessing.THREADUNSAFE, gateway.HandleQuestgiverStatusMultipleQuery);
        /*0x417*/
        gateway.StoreOpcode(WorldOpcode.SMSG_QUESTGIVER_STATUS_MULTIPLE, "SMSG_QUESTGIVER_STATUS_MULTIPLE",
            SessionStatus.NEVER, PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x41A*/
        gateway.StoreOpcode(WorldOpcode.CMSG_QUERY_SERVER_BUCK_DATA, "CMSG_QUERY_SERVER_BUCK_DATA", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x41B*/
        gateway.StoreOpcode(WorldOpcode.CMSG_CLEAR_SERVER_BUCK_DATA, "CMSG_CLEAR_SERVER_BUCK_DATA", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x41C*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SERVER_BUCK_DATA, "SMSG_SERVER_BUCK_DATA", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x41D*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SEND_UNLEARN_SPELLS, "SMSG_SEND_UNLEARN_SPELLS", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x41E*/
        gateway.StoreOpcode(WorldOpcode.SMSG_PROPOSE_LEVEL_GRANT, "SMSG_PROPOSE_LEVEL_GRANT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x41F*/
        gateway.StoreOpcode(WorldOpcode.CMSG_ACCEPT_LEVEL_GRANT, "CMSG_ACCEPT_LEVEL_GRANT", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_NULL);
        /*0x420*/
        gateway.StoreOpcode(WorldOpcode.SMSG_REFER_A_FRIEND_FAILURE, "SMSG_REFER_A_FRIEND_FAILURE", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
        /*0x423*/
        gateway.StoreOpcode(WorldOpcode.SMSG_SUMMON_CANCEL, "SMSG_SUMMON_CANCEL", SessionStatus.NEVER,
            PacketProcessing.INPLACE, gateway.Handle_ServerSide);
    }
}