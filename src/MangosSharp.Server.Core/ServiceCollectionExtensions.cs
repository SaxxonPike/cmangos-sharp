using MangosSharp.Server.Core.Cli;
using MangosSharp.Server.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MangosSharp.Server.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton(typeof(IDatabase), typeof(Database));
        serviceCollection.AddSingleton(typeof(ICliParser), typeof(CliParser));
        serviceCollection.AddSingleton(typeof(IFacts), typeof(Facts));
        serviceCollection.AddSingleton(typeof(IAccountService), typeof(AccountService));
        return serviceCollection;
    }
}