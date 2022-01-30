using System;
using Mangos.Server.Core.Sockets;
using Microsoft.Extensions.Logging;

namespace Mangos.Server.Realm.Messaging;

public class RealmServerHandler : ISocketHandler
{
    private readonly ILogger _logger;

    public RealmServerHandler(ILogger logger)
    {
        _logger = logger;
    }
    
    public void HandleConnect(ISocketEgress egress)
    {
        _logger.LogInformation("Connected socket: ip={}", egress.RemoteEndPoint);
    }

    public void HandleData(ISocketIngress ingress, ISocketEgress egress)
    {
        _logger.LogInformation("Received data: ip={}", ingress.RemoteEndPoint);
    }

    public void HandleDisconnect(ISocketEndpoints endpoints)
    {
        _logger.LogInformation("Disconnected socket: ip={}", endpoints.RemoteEndPoint);
    }

    public void HandleException(ISocketEndpoints endpoints, Exception e)
    {
        _logger.LogError("Handler exception: {} ip={}", e, endpoints.RemoteEndPoint);
    }
}