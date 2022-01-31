using System;
using System.Collections.Generic;
using Mangos.Server.Core.Messages;
using Mangos.Server.Core.Sockets;
using Mangos.Server.Realm.Messaging;

namespace Mangos.Server.Realm;

public static class MangosServerRealmTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
        yield return (typeof(ISocketHandler), typeof(RealmSocketHandler));
        yield return (typeof(IPacketHandler), typeof(RealmPacketHandler));
    }
}