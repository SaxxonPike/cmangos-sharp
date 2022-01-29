using Mangos.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Mangos.Server.Realm;

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
            .MapServices(new[]
            {
                (typeof(App), typeof(App))
            });
}