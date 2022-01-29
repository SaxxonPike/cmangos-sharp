using System;
using System.Collections.Generic;

namespace Mangos.Server.World;

public static class MangosServerWorldTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
    }
}