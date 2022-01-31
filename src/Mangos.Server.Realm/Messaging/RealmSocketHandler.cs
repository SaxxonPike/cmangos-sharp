using System;
using System.Diagnostics;
using System.Threading;
using Mangos.Server.Core.Messages;
using Mangos.Server.Core.Sockets;
using Microsoft.Extensions.Logging;

namespace Mangos.Server.Realm.Messaging;

public sealed class RealmSocketHandler : ISocketHandler
{
    public const int MaxTransmitTimeMs = 10000;
    
    private readonly ILogger _logger;
    private readonly IPacketHandler _handler;

    public RealmSocketHandler(ILogger logger, IPacketHandler handler)
    {
        _logger = logger;
        _handler = handler;
    }
    
    public void HandleConnect(SocketStream stream)
    {
        _logger.LogInformation("Connected realm socket: ip={}", stream.RemoteEndPoint);
    }

    public void HandleData(SocketStream stream)
    {
        _logger.LogInformation("Received realm data: ip={}", stream.RemoteEndPoint);

        // Disable packet time limits in debug
        using var cancel = Debugger.IsAttached
            ? new CancellationTokenSource()
            : new CancellationTokenSource(MaxTransmitTimeMs);

        while (stream.Available > 0 && !cancel.Token.IsCancellationRequested)
        {
            _handler.Handle(stream, cancel.Token);
            stream.FlushAsync(cancel.Token);
        }
    }

    public void HandleDisconnect(SocketStream stream)
    {
        _logger.LogInformation("Disconnected realm socket: ip={}", stream.RemoteEndPoint);
    }

    public void HandleException(ISocketEndpoints endpoints, Exception e)
    {
        _logger.LogError("Realm handler exception: {} ip={}", e, endpoints.RemoteEndPoint);
    }
}