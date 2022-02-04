using System;
using System.IO;
using System.Threading.Tasks;

namespace MangosSharp.Server.World.Messaging;

public interface IWorldPacketSender
{
    Task Send(string endpoint, WorldOpcode opcode, Action<BinaryWriter> context);
}