namespace Mangos.Server.World.Messaging;

public enum SessionStatus
{
    AUTHED =
        0, // Player authenticated (_player==nullptr, m_playerRecentlyLogout = false or will be reset before handler call)
    LOGGEDIN, // Player in game (_player!=nullptr, inWorld())
    TRANSFER, // Player transferring to another map (_player!=nullptr, !inWorld())
    LOGGEDIN_OR_RECENTLY_LOGGEDOUT, // _player!= nullptr or _player==nullptr && m_playerRecentlyLogout)
    NEVER, // Opcode not accepted from client (deprecated or server side only)
    UNHANDLED
}