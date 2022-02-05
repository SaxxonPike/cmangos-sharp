using System;
using System.IO;
using System.Threading.Tasks;
using MangosSharp.Core.Security;
using MangosSharp.Server.Core.Sockets;

namespace MangosSharp.Server.World.Messaging;

public interface IWorldPacketSender
{
    /// <summary>
    /// Send a packet immediately to the specified socket.
    /// </summary>
    void Send(SocketStream socket, WorldOpcode opcode, Action<BinaryWriter> context);
    
    /// <summary>
    /// Queue up a packet to the specified endpoint.
    /// </summary>
    Task Send(string endpoint, WorldOpcode opcode, Action<BinaryWriter> context);
}