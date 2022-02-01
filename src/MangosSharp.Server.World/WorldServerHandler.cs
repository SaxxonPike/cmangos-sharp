using System;
using MangosSharp.Server.Core.Sockets;

namespace MangosSharp.Server.World;

public class WorldServerHandler : ISocketHandler
{
    public void HandleConnect(SocketStream stream)
    {
        throw new NotImplementedException();
    }

    public void HandleData(SocketStream stream)
    {
        throw new NotImplementedException();
    }

    public void HandleDisconnect(SocketStream stream)
    {
        throw new NotImplementedException();
    }

    public void HandleException(ISocketEndpoints endpoints, Exception e)
    {
        throw new NotImplementedException();
    }
}