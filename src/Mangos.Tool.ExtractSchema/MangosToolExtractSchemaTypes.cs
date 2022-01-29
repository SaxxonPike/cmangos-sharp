using System;
using System.Collections.Generic;

namespace Mangos.Tool.ExtractSchema;

public static class MangosToolExtractSchemaTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(App), typeof(App));
    }
}
