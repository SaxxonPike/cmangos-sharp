namespace MangosSharp.Server.World.Enums;


public enum PetSaveMode
{
    PET_SAVE_AS_DELETED        = -1,                        // not saved in fact
    PET_SAVE_AS_CURRENT        =  0,                        // in current slot (with player)
    PET_SAVE_FIRST_STABLE_SLOT =  1,
    PET_SAVE_LAST_STABLE_SLOT  =  2,                        // last in DB stable slot index (including), all higher have same meaning as PET_SAVE_NOT_IN_SLOT
    PET_SAVE_NOT_IN_SLOT       =  100,                      // for avoid conflict with stable size grow will use 100
    PET_SAVE_REAGENTS          =  101                       // PET_SAVE_NOT_IN_SLOT with reagents return
}