using System;

namespace Mangos.Entities.Messaging;

public readonly struct Packet
{
    public Memory<byte> Data { get; init; }
    public int Opcode { get; init; }
}