using System;
using System.Collections.Generic;

namespace MangosSharp.Tool.ExtractMmap;

public static class MangosToolExtractMmapTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
    }
}
