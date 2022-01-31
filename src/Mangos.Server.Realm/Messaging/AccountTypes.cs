namespace Mangos.Server.Realm.Messaging;

public enum AccountTypes
{
    PLAYER = 0,
    MODERATOR = 1,
    GAMEMASTER = 2,
    ADMINISTRATOR = 3,
    CONSOLE = 4 // must be always last in list, accounts must have less security level always also
}