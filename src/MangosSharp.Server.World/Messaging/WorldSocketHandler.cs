using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MangosSharp.Core;
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
    private readonly int _seed;

    public WorldSocketHandler(IAuthService authService, ILogger logger, IPacketHandler packetHandler,
        IWorldPacketSender worldPacketSender)
    {
        _authService = authService;
        _logger = logger;
        _packetHandler = packetHandler;
        _worldPacketSender = worldPacketSender;
        _seed = Random.Shared.Next();
    }

    public async Task HandleConnect(SocketStream stream)
    {
        _authService.DeleteState(stream.RemoteEndPoint);
        await _worldPacketSender.Send(stream.RemoteEndPoint, WorldOpcode.SMSG_AUTH_CHALLENGE, writer =>
        {
            writer.Write(_seed);
            var seedBytes = new byte[32];
            Random.Shared.NextBytes(seedBytes);
            writer.Write(seedBytes);
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

            var state = _authService.GetState(stream.RemoteEndPoint);
            if (state is { Encrypted: true })
            {
                _authService.DecryptInPlace(header, state);
            }

            var length = header[1] | (header[0] << 8);
            var opcode = header[2] | (header[3] << 8) | (header[4] << 16) | (header[5] << 24);

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
            if (data.Length > 0)
                await stream.ReadAsync(data.AsMemory(4), cancel.Token);

            // Copy over the opcode as well
            header.AsSpan(2, 4).CopyTo(data.AsSpan());
            await using var packetStream = new ReadOnlyMemoryStream(data);
            if (!_packetHandler.Handle(packetStream, Debugger.IsAttached ? CancellationToken.None : cancel.Token))
            {
                _logger.LogWarning("Unhandled packet cmd = {:X8} ({})", opcode, (WorldOpcode)opcode);
            }
        }
        
        await stream.FlushAsync();
    }

    public async Task HandleDisconnect(SocketStream stream)
    {
        _authService.DeleteState(stream.RemoteEndPoint);
        _logger.LogInformation("Disconnected world socket: ip={}", stream.RemoteEndPoint);
    }

    public async Task HandleException(ISocketEndpoints endpoints, Exception e)
    {
        _logger.LogError("World handler exception: {} ip={}", e, endpoints.RemoteEndPoint);
    }
}