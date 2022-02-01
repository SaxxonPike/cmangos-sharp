using MangosSharp.Core;
using MangosSharp.Server.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MangosSharp.Server.Realm;

public static class Program
{
    public static void Main(string[] args)
    {
        var container = new ServiceCollection().AddInfrastructure().AddApp().BuildServiceProvider();
        container.GetService<App>()?.Run(args);
    }

    /// <summary>
    /// Put all new app services in here.
    /// </summary>
    private static IServiceCollection AddApp(this IServiceCollection serviceCollection) =>
        serviceCollection
            .MapServices(
                MangosServerRealmTypes.Get(),
                MangosCoreTypes.Get(),
                MangosServerCoreTypes.Get()
            )
            .AddInfrastructure()
            .AddLogging()
            .AddConf("realmd.conf", "RealmdConf")
            .AddDatabase();
}