namespace MangosSharp.Server.Core.Enums;

public enum UpdateType
{
    VALUES = 0,

    // 1 byte  - MASK
    // 8 bytes - GUID
    // Goto Update Block
    MOVEMENT = 1,

    // 1 byte  - MASK
    // 8 bytes - GUID
    // Goto Position Update
    CREATE_OBJECT = 2,

    CREATE_OBJECT2 = 3,

    // 1 byte  - MASK
    // 8 bytes - GUID
    // 1 byte - Object Type (*)
    // Goto Position Update
    // Goto Update Block
    OUT_OF_RANGE_OBJECTS = 4,

    // 4 bytes - Count
    // Loop Count Times:
    // 1 byte  - MASK
    // 8 bytes - GUID
    NEAR_OBJECTS = 5 // looks like 4 & 5 do the same thing

    // 4 bytes - Count
    // Loop Count Times:
    // 1 byte  - MASK
    // 8 bytes - GUID
}