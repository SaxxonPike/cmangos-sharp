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
    private readonly string _configSection;
    private DbContextOptions _mangosDbOptions;
    private DbContextOptions _realmDbOptions;
    private DbContextOptions _characterDbOptions;
    private DbContextOptions _logsDbOptions;

    public Database(IConfiguration configuration, ILogger logger, string configSection)
    {
        _configuration = configuration;
        _logger = logger;
        _configSection = configSection;
        RegisterConfigCallback();
        Configure();
    }

    private void RegisterConfigCallback()
    {
        _configuration.GetReloadToken().RegisterChangeCallback(_ => { Configure(); }, null);
    }

    private void Configure()
    {
        _logsDbOptions = GetMySqlOptions(_configuration[$"{_configSection}.LogsDatabaseInfo"]);
        _mangosDbOptions = GetMySqlOptions(_configuration[$"{_configSection}.WorldDatabaseInfo"]);
        _characterDbOptions = GetMySqlOptions(_configuration[$"{_configSection}.CharacterDatabaseInfo"]);
        _realmDbOptions = GetMySqlOptions(_configuration[$"{_configSection}.LoginDatabaseInfo"]);
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

    public void UseWorld(Action<MangosDbContext> context)
    {
        using var db = new MangosDbContext(_mangosDbOptions);
        context(db);
    }

    public void UseCharacter(Action<CharacterDbContext> context)
    {
        using var db = new CharacterDbContext(_characterDbOptions);
        context(db);
    }

    public void UseLogs(Action<LogsDbContext> context)
    {
        using var db = new LogsDbContext(_logsDbOptions);
        context(db);
    }

    public void UseClient(Action<ClientDbContext> context)
    {
        using var db = new ClientDbContext(_logger);
        context(db);
    }
}