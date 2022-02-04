using System.Collections.Generic;
using MangosSharp.Core;
using MangosSharp.Server.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MangosSharp.Server.Realm;

public static class Program
{
    public static void Main(string[] args)
    {
        var container = new ServiceCollection().AddApp(args).BuildServiceProvider();
        container.GetService<App>()?.Run();
    }

    /// <summary>
    /// Put all new app services in here.
    /// </summary>
    private static IServiceCollection AddApp(this IServiceCollection serviceCollection, IEnumerable<string> args) =>
        serviceCollection
            .MapServices(
                MangosServerRealmTypes.Get(),
                MangosCoreTypes.Get(),
                MangosServerCoreTypes.Get()
            )
            .AddInfrastructure(args)
            .AddLogging()
            .AddConf("realmd.conf", "RealmdConf")
            .AddDatabase()
            .AddMemoryCache();
}