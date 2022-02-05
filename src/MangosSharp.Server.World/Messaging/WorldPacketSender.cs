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

    private MemoryStream Build(string endpoint, WorldOpcode opcode, Action<BinaryWriter> context)
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
            
        var bytes = mem.AsMemory();
            
        if (_authService.GetState(endpoint) is { Encrypted: true } state)
            _authService.EncryptInPlace(bytes.Span[..4], state);

        mem.Position = 0;
        return mem;
    }
    
    public void Send(SocketStream socket, WorldOpcode opcode, Action<BinaryWriter> context)
    {
        using var mem = Build(socket.RemoteEndPoint, opcode, context);
        socket.Write(mem.AsMemory());
    }

    public async Task Send(string endpoint, WorldOpcode opcode, Action<BinaryWriter> context)
    {
        // Keep in mind: packets sent out of order cause huge issues
        var mem = Build(endpoint, opcode, context);
        using var cancel = new CancellationTokenSource(10000);
        await _socketDaemon.SendAsync(endpoint, stream =>
            {
                stream.Write(mem.AsMemory());
                mem.Dispose();
            },
            Debugger.IsAttached ? CancellationToken.None : cancel.Token);
    }
}