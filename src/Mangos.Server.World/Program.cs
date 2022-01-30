using System.Linq;
using Mangos.Core;
using Mangos.Server.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Mangos.Server.World;

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
                MangosServerWorldTypes.Get(),
                MangosCoreTypes.Get(),
                MangosServerCoreTypes.Get()
            )
            .AddLogging()
            .AddConf("mangosd.conf")
            .AddDatabase("MangosdConf");
}