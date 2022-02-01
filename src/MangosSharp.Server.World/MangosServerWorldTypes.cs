using System;
using System.Collections.Generic;
using MangosSharp.Server.Core.Sockets;

namespace MangosSharp.Server.World;

public static class MangosServerWorldTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
        yield return (typeof(ISocketHandler), typeof(WorldServerHandler));
    }
}