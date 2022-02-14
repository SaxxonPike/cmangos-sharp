using System;
using System.Collections.Generic;

namespace MangosSharp.Tool.ExtractVmap;

public static class MangosToolExtractVmapTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
    }
}
