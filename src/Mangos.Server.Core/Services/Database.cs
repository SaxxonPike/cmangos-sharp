using System;
using Mangos.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace Mangos.Server.Core.Services;

public class Database : IDatabase
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;
    private DbContextOptions _mangosDbOptions;
    private DbContextOptions _realmDbOptions;
    private DbContextOptions _characterDbOptions;
    private DbContextOptions _logsDbOptions;

    public Database(IConfiguration configuration, ILogger logger)
    {
        _configuration = configuration;
        _logger = logger;
        RegisterConfigCallback();
        Configure();
    }

    private void RegisterConfigCallback()
    {
        _configuration.GetReloadToken().RegisterChangeCallback(_ => { Configure(); }, null);
    }

    private void Configure()
    {
        _logsDbOptions = GetMySqlOptions("LogsDatabaseInfo");
        _mangosDbOptions = GetMySqlOptions("WorldDatabaseInfo");
        _characterDbOptions = GetMySqlOptions("CharacterDatabaseInfo");
        _realmDbOptions = GetMySqlOptions("LoginDatabaseInfo");
    }

    private DbContextOptions GetMySqlOptions(string configValue)
    {
        var configString = _configuration[configValue];
        if (string.IsNullOrWhiteSpace(configString))
            return default;

        var dbConfig = configString.Split(';');
        var builder = new MySqlConnectionStringBuilder
        {
            Database = dbConfig[4],
            Server = dbConfig[0],
            Port = uint.Parse(dbConfig[1]),
            UserID = dbConfig[2],
            Password = dbConfig[3]
        };

        var options = new DbContextOptionsBuilder();
        options.UseMySQL(builder.ToString());
        return options.Options;
    }

    public void UseLogin(Action<ClassicrealmdDbContext> context)
    {
        using var db = new ClassicrealmdDbContext(_realmDbOptions);
        context(db);
    }

    public T UseLogin<T>(Func<ClassicrealmdDbContext, T> context)
    {
        using var db = new ClassicrealmdDbContext(_realmDbOptions);
        return context(db);
    }

    public void UseWorld(Action<ClassicmangosDbContext> context)
    {
        using var db = new ClassicmangosDbContext(_mangosDbOptions);
        context(db);
    }

    public T UseWorld<T>(Func<ClassicmangosDbContext, T> context)
    {
        using var db = new ClassicmangosDbContext(_mangosDbOptions);
        return context(db);
    }

    public void UseCharacter(Action<ClassiccharactersDbContext> context)
    {
        using var db = new ClassiccharactersDbContext(_characterDbOptions);
        context(db);
    }

    public T UseCharacter<T>(Func<ClassiccharactersDbContext, T> context)
    {
        using var db = new ClassiccharactersDbContext(_characterDbOptions);
        return context(db);
    }

    public void UseLogs(Action<ClassiclogsDbContext> context)
    {
        using var db = new ClassiclogsDbContext(_logsDbOptions);
        context(db);
    }
    
    public T UseLogs<T>(Func<ClassiclogsDbContext, T> context)
    {
        using var db = new ClassiclogsDbContext(_logsDbOptions);
        return context(db);
    }

    public void UseClient(Action<ClientDbContext> context)
    {
        using var db = new ClientDbContext(_logger);
        context(db);
    }
    
    public T UseClient<T>(Func<ClientDbContext, T> context)
    {
        using var db = new ClientDbContext(_logger);
        return context(db);
    }
}