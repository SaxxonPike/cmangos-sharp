using System;
using Mangos.Server.Core.Sockets;

namespace Mangos.Server.World;

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