using System;

namespace MangosSharp.Server.Core.Sockets;

public interface ISocketHandler
{
    void HandleConnect(SocketStream stream);
    void HandleData(SocketStream stream);
    void HandleDisconnect(SocketStream stream);
    void HandleException(ISocketEndpoints endpoints, Exception e);
}