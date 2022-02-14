using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MangosSharp.Core.Security;
using MangosSharp.Server.Core.Messages;
using MangosSharp.Server.Core.Sockets;
using Microsoft.Extensions.Logging;

namespace MangosSharp.Server.World.Messaging;

public class WorldSocketHandler : ISocketHandler
{
    private readonly IAuthService _authService;
    private readonly ILogger _logger;
    private readonly IPacketHandler _packetHandler;
    private readonly IWorldPacketSender _worldPacketSender;

    public WorldSocketHandler(IAuthService authService, ILogger logger, IPacketHandler packetHandler,
        IWorldPacketSender worldPacketSender)
    {
        _authService = authService;
        _logger = logger;
        _packetHandler = packetHandler;
        _worldPacketSender = worldPacketSender;
    }

    public async Task HandleConnect(SocketStream stream)
    {
        _worldPacketSender.Send(stream, WorldOpcode.SMSG_AUTH_CHALLENGE, writer =>
        {
            var serverSeed = new byte[4];
            Random.Shared.NextBytes(serverSeed);
            writer.Write(serverSeed);
            var seeds = new byte[32];
            Random.Shared.NextBytes(seeds);
            stream.SetMetadata("ServerSeed", serverSeed);
            writer.Write(seeds);
        });
        await stream.FlushAsync();
    }

    public async Task HandleData(SocketStream stream)
    {
        while (stream.Available >= 6)
        {
            // If it takes longer than this to read in packet data, consider it dead
            using var cancel = new CancellationTokenSource(10000);

            var header = new byte[6];
            await stream.ReadAsync(header, cancel.Token);

            var auth = stream.GetAuthState();
            if (auth is { Encrypted: true })
            {
                _authService.DecryptInPlace(header, auth);
            }

            var length = header[1] | (header[0] << 8);
            var opcode = header[2] | (header[3] << 8) | (header[4] << 16) | (header[5] << 24);

            if (auth is not { } && opcode != (int)WorldOpcode.CMSG_AUTH_SESSION)
            {
                _logger.LogError("WorldSocket::ProcessIncomingData: requires CMSG_AUTH_SESSION");
                stream.Disconnect();
                return;
            }

            // there must always be at least four bytes for the opcode,
            // and 0x2800 is the largest supported buffer in the client
            if (length is < 4 or > 0x2800)
            {
                _logger.LogError(
                    "WorldSocket::ProcessIncomingData: client sent malformed packet size = {:X4}, cmd = {:X8}",
                    length, opcode);
                stream.Disconnect();
                return;
            }

            var data = new byte[length];
            if (data.Length > 4)
                await stream.ReadAsync(data.AsMemory(4), Debugger.IsAttached ? CancellationToken.None : cancel.Token);

            // Copy over the opcode as well in case the handler needs it (movement handlers are one example.)
            header.AsSpan(2, 4).CopyTo(data.AsSpan());
            
            stream.Insert(data);

            if (!_packetHandler.Handle(stream, Debugger.IsAttached ? CancellationToken.None : cancel.Token))
                _logger.LogWarning("Unhandled packet cmd = {:X8} ({})", opcode, (WorldOpcode)opcode);

            // Flush whatever remainder of unread packet we have from the buffer.
            stream.Discard();
        }
        
        await stream.FlushAsync();
    }

    public Task HandleDisconnect(SocketStream stream)
    {
        _logger.LogInformation("Disconnected world socket: ip={}", stream.RemoteEndPoint);
        return Task.CompletedTask;
    }

    public Task HandleException(ISocketEndpoints endpoints, Exception e)
    {
        _logger.LogError("World handler exception: {} ip={}", e, endpoints.RemoteEndPoint);
        return Task.CompletedTask;
    }
}