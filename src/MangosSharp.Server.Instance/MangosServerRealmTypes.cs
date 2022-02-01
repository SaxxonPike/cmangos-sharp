using System;
using System.Collections.Generic;

namespace MangosSharp.Server.Instance;

public static class MangosServerInstanceTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
    }
}
