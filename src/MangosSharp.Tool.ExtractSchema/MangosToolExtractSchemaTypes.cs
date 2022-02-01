using System;
using System.Collections.Generic;

namespace MangosSharp.Tool.ExtractSchema;

public static class MangosToolExtractSchemaTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
    }
}
