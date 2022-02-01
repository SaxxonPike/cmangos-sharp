namespace MangosSharp.Entities.Messaging.Realm;

public enum CmdOpcode
{
    AUTH_LOGON_CHALLENGE = 0x00,
    AUTH_LOGON_PROOF = 0x01,
    AUTH_RECONNECT_CHALLENGE = 0x02,
    AUTH_RECONNECT_PROOF = 0x03,
    REALM_LIST = 0x10,
    XFER_INITIATE = 0x30,
    XFER_DATA = 0x31,

    // these opcodes no longer exist in currently supported client
    XFER_ACCEPT = 0x32,
    XFER_RESUME = 0x33,
    XFER_CANCEL = 0x34
}

public enum AuthLogonResult
{
    SUCCESS                      = 0x00,
    FAILED_UNKNOWN0              = 0x01,                 //< ? Unable to connect
    FAILED_UNKNOWN1              = 0x02,                 //< ? Unable to connect
    FAILED_BANNED                = 0x03,                 //< This <game> account has been closed and is no longer available for use. Please go to <site>/banned.html for further information.
    FAILED_UNKNOWN_ACCOUNT       = 0x04,                 //< The information you have entered is not valid. Please check the spelling of the account name and password. If you need help in retrieving a lost or stolen password, see <site> for more information
    FAILED_INCORRECT_PASSWORD    = 0x05,                 //< The information you have entered is not valid. Please check the spelling of the account name and password. If you need help in retrieving a lost or stolen password, see <site> for more information
    // client reject next login attempts after this error, so in code used FAILED_UNKNOWN_ACCOUNT for both cases
    FAILED_ALREADY_ONLINE        = 0x06,                 //< This account is already logged into <game>. Please check the spelling and try again.
    FAILED_NO_TIME               = 0x07,                 //< You have used up your prepaid time for this account. Please purchase more to continue playing
    FAILED_DB_BUSY               = 0x08,                 //< Could not log in to <game> at this time. Please try again later.
    FAILED_VERSION_INVALID       = 0x09,                 //< Unable to validate game version. This may be caused by file corruption or interference of another program. Please visit <site> for more information and possible solutions to this issue.
    FAILED_VERSION_UPDATE        = 0x0A,                 //< Downloading
    FAILED_INVALID_SERVER        = 0x0B,                 //< Unable to connect
    FAILED_SUSPENDED             = 0x0C,                 //< This <game> account has been temporarily suspended. Please go to <site>/banned.html for further information
    FAILED_FAIL_NOACCESS         = 0x0D,                 //< Unable to connect
    SUCCESS_SURVEY               = 0x0E,                 //< Connected.
    FAILED_PARENTCONTROL         = 0x0F,                 //< Access to this account has been blocked by parental controls. Your settings may be changed in your account preferences at <site>
    FAILED_LOCKED_ENFORCED       = 0x10,                 //< You have applied a lock to your account. You can change your locked status by calling your account lock phone number.
    FAILED_TRIAL_ENDED           = 0x11,                 //< Your trial subscription has expired. Please visit <site> to upgrade your account.
    FAILED_USE_BNET              = 0x12,                 //< FAILED_OTHER This account is now attached to a BNet account. Please login with your BNet account email address and password.
    // FAILED_OVERMIND_CONVERTED
    // FAILED_ANTI_INDULGENCE
    // FAILED_EXPIRED
    // FAILED_NO_GAME_ACCOUNT
    // FAILED_BILLING_LOCK
    // FAILED_IGR_WITHOUT_BNET
    // FAILED_AA_LOCK
    // FAILED_UNLOCKABLE_LOCK
    // FAILED_MUST_USE_BNET
    // FAILED_OTHER
}