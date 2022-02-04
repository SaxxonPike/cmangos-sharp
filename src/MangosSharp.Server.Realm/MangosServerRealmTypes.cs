using System;
using System.Collections.Generic;
using MangosSharp.Server.Core;
using MangosSharp.Server.Core.Cli;
using MangosSharp.Server.Core.Messages;
using MangosSharp.Server.Core.Sockets;
using MangosSharp.Server.Realm.Messaging;
using MangosSharp.Server.Realm.Services;

namespace MangosSharp.Server.Realm;

public static class MangosServerRealmTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
        yield return (typeof(ISocketHandler), typeof(RealmSocketHandler));
        yield return (typeof(IPacketHandler), typeof(RealmPacketHandler));
        yield return (typeof(IRealmListService), typeof(RealmListService));
        yield return (typeof(ICliCommands), typeof(CliCommands));
    }
}