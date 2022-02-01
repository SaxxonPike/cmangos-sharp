using MangosSharp.Server.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MangosSharp.Server.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton(typeof(IDatabase),
            c => new Database(c.GetService<IConfiguration>(), c.GetService<ILogger>()));
        return serviceCollection;
    }
}