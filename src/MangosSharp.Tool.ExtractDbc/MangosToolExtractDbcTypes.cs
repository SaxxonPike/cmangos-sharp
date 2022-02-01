using System;
using System.Collections.Generic;

namespace MangosSharp.Tool.ExtractDbc;

public static class MangosToolExtractDbcTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
    }
}
