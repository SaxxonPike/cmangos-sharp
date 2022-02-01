using System;

namespace MangosSharp.Server.Core.Messages;

public readonly struct Packet
{
    public string Endpoint { get; init; }
    public int Opcode { get; init; }
    public ReadOnlyMemory<byte> Data { get; init; }
}