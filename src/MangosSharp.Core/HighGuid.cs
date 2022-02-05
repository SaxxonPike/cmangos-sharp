namespace MangosSharp.Core;

public enum HighGuid
{
    ITEM = 0x4000, // blizz 4000
    CONTAINER = 0x4000, // blizz 4000
    PLAYER = 0x0000, // blizz 0000
    GAMEOBJECT = 0xF110, // blizz F110
    TRANSPORT = 0xF120, // blizz F120 (for GAMEOBJECT_TYPE_TRANSPORT)
    UNIT = 0xF130, // blizz F130
    PET = 0xF140, // blizz F140
    DYNAMICOBJECT = 0xF100, // blizz F100
    CORPSE = 0xF101, // blizz F100
    MO_TRANSPORT = 0x1FC0 // blizz 1FC0 (for GAMEOBJECT_TYPE_MO_TRANSPORT)    
}