using Mangos.Server.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mangos.Server.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection, string confSection)
    {
        serviceCollection.AddSingleton(typeof(IDatabase),
            c => new Database(c.GetService<IConfiguration>(), c.GetService<ILogger>(), confSection));
        return serviceCollection;
    }
}