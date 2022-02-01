namespace MangosSharp.Server.Realm.Messaging;

public enum SessionStatus
{
    CHALLENGE,
    LOGON_PROOF,
    RECON_PROOF,
    PATCH,      // unused in CMaNGOS
    AUTHED,
    CLOSED    
}