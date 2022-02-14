using System;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.World.Messaging;

public sealed class SocketState
{
    public DateTimeOffset LastPing { get; set; }
    public int Latency { get; set; }
    public int OverSpeedPings { get; set; }
    public AccountType Security { get; set; }
}