using MangosSharp.Server.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MangosSharp.Server.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton(typeof(IDatabase), typeof(Database));
        return serviceCollection;
    }
}