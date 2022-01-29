using System;
using System.Collections.Generic;

namespace Mangos.Server.Realm;

public static class MangosServerRealmTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
    }
}