using System;
using System.Collections.Generic;
using Mangos.Core.Infrastructure;
using Mangos.Core.Security;

namespace Mangos.Core;

public static class MangosCoreTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(IConsoleProvider), typeof(ConsoleProvider));
        yield return (typeof(IAuthEngine), typeof(AuthEngine));
    }
}