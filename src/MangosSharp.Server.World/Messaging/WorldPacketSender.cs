using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MangosSharp.Core;
using MangosSharp.Core.Security;
using MangosSharp.Server.Core.Sockets;

namespace MangosSharp.Server.World.Messaging;

public class WorldPacketSender : IWorldPacketSender
{
    private readonly IAuthService _authService;
    private readonly ISocketDaemon _socketDaemon;

    public WorldPacketSender(IAuthService authService, ISocketDaemon socketDaemon)
    {
        _authService = authService;
        _socketDaemon = socketDaemon;
    }

    public Task Send(string endpoint, WorldOpcode opcode, Action<BinaryWriter> context) =>
        Task.Run(async () =>
        {
            using var cancel = new CancellationTokenSource(10000);
            var mem = new MemoryStream();
            var writer = new BinaryWriter(mem);
            
            writer.Write((short)0);
            writer.Write(0);
            
            context(writer);
            
            mem.Position = 0;
            var length = mem.Length - 2;
            mem.WriteByte(unchecked((byte)(length >> 8)));
            mem.WriteByte(unchecked((byte)length));
            writer.Write((int)opcode);
            
            var bytes = mem.AsMemory();
            
            if (_authService.GetState(endpoint) is { Encrypted: true } state)
                _authService.EncryptInPlace(bytes.Span[..6], state);
            
            await _socketDaemon.SendAsync(endpoint, stream => stream.Write(bytes),
                Debugger.IsAttached ? CancellationToken.None : cancel.Token);
        });
}