using System;
using System.Collections.Generic;
using Mangos.Server.Core.Sockets;

namespace Mangos.Server.Core;

public static class MangosServerCoreTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(ISocketDaemon), typeof(SocketDaemon));
    }
}