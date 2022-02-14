using MangosSharp.Core.Security;
using MangosSharp.Server.Core.Sockets;

namespace MangosSharp.Server.World.Messaging;

public static class SocketStreamExtensions
{
    public static AuthState GetAuthState(this SocketStream stream) =>
        stream.GetMetadata<AuthState>(nameof(AuthState));

    public static void SetAuthState(this SocketStream stream, AuthState auth) =>
        stream.SetMetadata(nameof(AuthState), auth);
    
    public static SocketState GetSocketState(this SocketStream stream) =>
        stream.GetMetadata<SocketState>(nameof(SocketState));

    public static void SetSocketState(this SocketStream stream, SocketState state) =>
        stream.SetMetadata(nameof(SocketState), state);
}