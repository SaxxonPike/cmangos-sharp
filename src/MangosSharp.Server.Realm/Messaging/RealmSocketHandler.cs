using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MangosSharp.Core.Security;
using MangosSharp.Server.Core.Messages;
using MangosSharp.Server.Core.Sockets;
using Microsoft.Extensions.Logging;

namespace MangosSharp.Server.Realm.Messaging;

public sealed class RealmSocketHandler : ISocketHandler
{
    public const int MaxTransmitTimeMs = 10000;
    
    private readonly ILogger _logger;
    private readonly IPacketHandler _handler;
    private readonly IAuthService _authService;

    public RealmSocketHandler(ILogger logger, IPacketHandler handler, IAuthService authService)
    {
        _logger = logger;
        _handler = handler;
        _authService = authService;
    }
    
    public Task HandleConnect(SocketStream stream)
    {
        _logger.LogInformation("Connected realm socket: ip={}", stream.RemoteEndPoint);
        return Task.CompletedTask;
    }

    public async Task HandleData(SocketStream stream)
    {
        _logger.LogInformation("Received realm data: ip={}", stream.RemoteEndPoint);

        // Disable packet time limits in debug
        using var cancel = Debugger.IsAttached
            ? new CancellationTokenSource()
            : new CancellationTokenSource(MaxTransmitTimeMs);

        while (stream.Available > 0 && !cancel.Token.IsCancellationRequested)
        {
            _handler.Handle(stream, cancel.Token);
            await stream.FlushAsync(cancel.Token);
        }
    }

    public Task HandleDisconnect(SocketStream stream)
    {
        _authService.DeleteState(stream.RemoteEndPoint);
        _logger.LogInformation("Disconnected realm socket: ip={}", stream.RemoteEndPoint);
        return Task.CompletedTask;
    }

    public Task HandleException(ISocketEndpoints endpoints, Exception e)
    {
        _logger.LogError("Realm handler exception: {} ip={}", e, endpoints.RemoteEndPoint);
        return Task.CompletedTask;
    }
}