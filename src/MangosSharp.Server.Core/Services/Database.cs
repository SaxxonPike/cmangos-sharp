using System;
using System.Diagnostics;
using MangosSharp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace MangosSharp.Server.Core.Services;

/// <inheritdoc />
public sealed class Database : IDatabase
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;
    private readonly IMemoryCache _memoryCache;
    private DbContextOptions _mangosDbOptions;
    private DbContextOptions _realmDbOptions;
    private DbContextOptions _characterDbOptions;
    private DbContextOptions _logsDbOptions;

    /// <summary>
    /// Create a Database access service.
    /// </summary>
    public Database(IConfiguration configuration, ILogger logger, IMemoryCache memoryCache)
    {
        _configuration = configuration;
        _logger = logger;
        _memoryCache = memoryCache;
        RegisterConfigCallback();
        Configure();
    }

    /// <summary>
    /// Create a reload token in the configuration object so that if it changes, we trigger re-creation of DB
    /// connection strings.
    /// </summary>
    private void RegisterConfigCallback()
    {
        _configuration.GetReloadToken().RegisterChangeCallback(_ => { Configure(); }, null);
    }

    /// <summary>
    /// Cache DB connection strings.
    /// </summary>
    private void Configure()
    {
        _logsDbOptions = GetMySqlOptions("LogsDatabaseInfo");
        _mangosDbOptions = GetMySqlOptions("WorldDatabaseInfo");
        _characterDbOptions = GetMySqlOptions("CharacterDatabaseInfo");
        _realmDbOptions = GetMySqlOptions("LoginDatabaseInfo");
    }

    /// <summary>
    /// Construct DbContextOptions that will be used for all DbContext constructors.
    /// </summary>
    private DbContextOptions GetMySqlOptions(string configValue)
    {
        var configString = _configuration[configValue];
        if (string.IsNullOrWhiteSpace(configString))
            return default;

        // We assume the config value is in the format used by Realmd.
        var dbConfig = configString.Split(';');
        var builder = new MySqlConnectionStringBuilder
        {
            Database = dbConfig[4],
            Server = dbConfig[0],
            Port = uint.Parse(dbConfig[1]),
            UserID = dbConfig[2],
            Password = dbConfig[3]
        };

        var options = new DbContextOptionsBuilder()
            .UseMySQL(builder.ToString())
            
            // This makes it so that entities we retrieve repeatedly should be cached without needing a round trip to
            // the database. (Ideally.) Saves bandwidth.
            .UseMemoryCache(_memoryCache)
            
            // Effectively makes all queries read-only by default. In most cases we will not need to modify database
            // information, and in the cases we do, we can just use .AsTracking() in the query. Saves memory.
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            
            // This makes it so that field values are visible in SQL logging, enabled below.
            .EnableSensitiveDataLogging(Debugger.IsAttached)
            
            // So about this line:
            // Microsoft says DbContext objects are not usable across threads. If we are careful to construct
            // and dispose contexts within the same function, this should not be an issue. It is also why we cannot
            // use DbContext pooling- the pool may inadvertently cross threads. Our massively multithreaded setup
            // will not permit us use of any other fun optimizations- we have to do it precisely this way.
            .EnableThreadSafetyChecks(false)
            
            // This will mega spam your debug window. If it is a problem, remove this line.
            .LogTo(s => _logger.LogDebug("[SQL] {}", s));

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
        using var db = new ClientDbContext(_logger, _memoryCache);
        context(db);
    }
    
    public T UseClient<T>(Func<ClientDbContext, T> context)
    {
        using var db = new ClientDbContext(_logger, _memoryCache);
        return context(db);
    }
}