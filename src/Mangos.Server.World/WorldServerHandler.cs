using System;
using Mangos.Server.Core.Sockets;

namespace Mangos.Server.World;

public class WorldServerHandler : ISocketHandler
{
    public void HandleConnect(ISocketEgress egress)
    {
        throw new NotImplementedException();
    }

    public void HandleData(ISocketIngress ingress, ISocketEgress egress)
    {
        throw new NotImplementedException();
    }

    public void HandleDisconnect(ISocketEndpoints endpoints)
    {
        throw new NotImplementedException();
    }

    public void HandleException(ISocketEndpoints endpoints, Exception e)
    {
        throw new NotImplementedException();
    }
}