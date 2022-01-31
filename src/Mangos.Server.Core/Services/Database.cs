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

    public void UseLogin(Action<RealmDbContext> context)
    {
        using var db = new RealmDbContext(_realmDbOptions);
        context(db);
    }

    public T UseLogin<T>(Func<RealmDbContext, T> context)
    {
        using var db = new RealmDbContext(_realmDbOptions);
        return context(db);
    }

    public void UseWorld(Action<MangosDbContext> context)
    {
        using var db = new MangosDbContext(_mangosDbOptions);
        context(db);
    }

    public T UseWorld<T>(Func<MangosDbContext, T> context)
    {
        using var db = new MangosDbContext(_mangosDbOptions);
        return context(db);
    }

    public void UseCharacter(Action<CharacterDbContext> context)
    {
        using var db = new CharacterDbContext(_characterDbOptions);
        context(db);
    }

    public T UseCharacter<T>(Func<CharacterDbContext, T> context)
    {
        using var db = new CharacterDbContext(_characterDbOptions);
        return context(db);
    }

    public void UseLogs(Action<LogsDbContext> context)
    {
        using var db = new LogsDbContext(_logsDbOptions);
        context(db);
    }
    
    public T UseLogs<T>(Func<LogsDbContext, T> context)
    {
        using var db = new LogsDbContext(_logsDbOptions);
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