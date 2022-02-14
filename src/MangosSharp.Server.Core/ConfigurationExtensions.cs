using Microsoft.Extensions.Configuration;

namespace MangosSharp.Server.Core;

public static class ConfigurationExtensions
{
    public static T GetValue<T>(this IConfiguration configuration, Conf conf) => 
        configuration.GetValue(conf.Name, (T)conf.Fallback);
}