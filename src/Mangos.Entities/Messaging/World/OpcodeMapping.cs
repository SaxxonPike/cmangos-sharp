using System;

namespace Mangos.Entities.Messaging;

public struct OpcodeMapping
{
    public int Id;
    public string Name;
    public int Status;
    public int Process;
    public Type Handler;
}