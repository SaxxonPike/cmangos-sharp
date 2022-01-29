using System;
using System.Collections.Generic;

namespace Mangos.Tool.ExtractDbc;

public static class MangosToolExtractDbcTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
    }
}
