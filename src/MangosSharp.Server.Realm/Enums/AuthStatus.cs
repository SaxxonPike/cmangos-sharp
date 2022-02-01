namespace MangosSharp.Server.Realm.Enums;

public enum AuthStatus
{
    CHALLENGE,
    LOGON_PROOF,
    RECON_PROOF,
    PATCH, // unused in CMaNGOS
    AUTHED,
    CLOSED
}