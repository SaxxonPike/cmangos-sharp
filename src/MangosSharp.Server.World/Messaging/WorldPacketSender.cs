using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MangosSharp.Core;
using MangosSharp.Core.Security;
using MangosSharp.Server.Core.Sockets;

namespace MangosSharp.Server.World.Messaging;

/// <summary>
/// Handles building and packets to connected client sockets.
/// </summary>
public class WorldPacketSender : IWorldPacketSender
{
    private readonly IAuthService _authService;
    private readonly ISocketDaemon _socketDaemon;

    public WorldPacketSender(IAuthService authService, ISocketDaemon socketDaemon)
    {
        _authService = authService;
        _socketDaemon = socketDaemon;
    }

    private static MemoryStream Build(WorldOpcode opcode, Action<BinaryWriter> context)
    {
        var mem = new MemoryStream(2);
        var writer = new BinaryWriter(mem);
            
        writer.Write((short)0);
        writer.Write((short)0);
            
        context(writer);
            
        mem.Position = 0;
        var length = mem.Length - 2;
        mem.WriteByte(unchecked((byte)(length >> 8)));
        mem.WriteByte(unchecked((byte)length));
        writer.Write((short)opcode);
            
        mem.Position = 0;
        return mem;
    }

    private void Encrypt(SocketStream stream, Memory<byte> bytes)
    {
        if (stream.GetMetadata<AuthState>(nameof(AuthState)) is { Encrypted: true } state)
            _authService.EncryptInPlace(bytes.Span[..4], state);
    }
    
    public void Send(SocketStream socket, WorldOpcode opcode, Action<BinaryWriter> context)
    {
        using var mem = Build(opcode, context);
        var bytes = mem.AsMemory();
        Encrypt(socket, bytes);
        socket.Write(bytes);
    }

    public async Task Send(string endpoint, WorldOpcode opcode, Action<BinaryWriter> context)
    {
        var mem = Build(opcode, context);
        using var cancel = new CancellationTokenSource(10000);
        await _socketDaemon.SendAsync(endpoint, stream =>
            {
                // Keep in mind: packets sent out of order cause issues
                // so keep encryption as close to transmission as possible
                var bytes = mem.AsMemory();
                Encrypt(stream, bytes);
                stream.Write(bytes);
                mem.Dispose();
            },
            Debugger.IsAttached ? CancellationToken.None : cancel.Token);
    }
}