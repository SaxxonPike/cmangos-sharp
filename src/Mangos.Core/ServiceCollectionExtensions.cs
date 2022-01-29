using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mangos.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection MapServices(
        this IServiceCollection sc, 
        IEnumerable<(Type Service, Type Implementation)> map)
    {
        foreach (var (service, implementation) in map)
            sc.AddSingleton(service, implementation);
        return sc;
    }
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        var name = Assembly.GetCallingAssembly().GetName().Name;

        return serviceCollection
            .AddSingleton(LoggerFactory.Create(f => f
                .AddConsole(c => { c.FormatterName = "systemd"; })
                .AddDebug()
            ).CreateLogger(name));
    }

    public static IServiceCollection AddConf(this IServiceCollection serviceCollection, string fileName)
    {
        return serviceCollection
            .AddSingleton(typeof(IConfiguration), new MangosConfiguration(fileName));
    }
}