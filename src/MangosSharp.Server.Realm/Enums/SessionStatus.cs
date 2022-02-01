namespace MangosSharp.Server.Realm.Enums;

public enum SessionStatus
{
    CHALLENGE,
    LOGON_PROOF,
    RECON_PROOF,
    PATCH,      // unused in CMaNGOS
    AUTHED,
    CLOSED    
}