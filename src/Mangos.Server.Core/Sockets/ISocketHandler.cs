using System;

namespace Mangos.Server.Core.Sockets;

public interface ISocketHandler
{
    void HandleConnect(ISocketEgress egress);
    void HandleData(ISocketIngress ingress, ISocketEgress egress);
    void HandleDisconnect(ISocketEndpoints endpoints);
    void HandleException(ISocketEndpoints endpoints, Exception e);
}