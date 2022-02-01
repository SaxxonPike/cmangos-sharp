using System;
using System.Collections.Generic;
using MangosSharp.Core.Infrastructure;
using MangosSharp.Core.Security;

namespace MangosSharp.Core;

public static class MangosCoreTypes
{
    public static IEnumerable<(Type Service, Type Implementation)> Get()
    {
        yield return (typeof(IConsoleProvider), typeof(ConsoleProvider));
        yield return (typeof(IAuthEngine), typeof(AuthEngine));
    }
}