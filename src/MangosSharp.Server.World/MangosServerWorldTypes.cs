using System;
using System.Collections.Generic;
using MangosSharp.Server.Core.Cli;
using MangosSharp.Server.Core.Messages;
using MangosSharp.Server.Core.Sockets;
using MangosSharp.Server.World.Messaging;

namespace MangosSharp.Server.World;

public static class MangosServerWorldTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
        yield return (typeof(ISocketHandler), typeof(WorldSocketHandler));
        yield return (typeof(ICliCommands), typeof(CliCommands));
        yield return (typeof(IPacketHandler), typeof(WorldPacketHandler));
        yield return (typeof(IWorldPacketSender), typeof(WorldPacketSender));
    }
}