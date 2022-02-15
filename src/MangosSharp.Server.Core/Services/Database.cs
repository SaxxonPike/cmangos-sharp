using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MangosSharp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

    private readonly Interceptor _interceptor = new();

    private readonly Dictionary<Type, ConcurrentQueue<Commit>> _commitQueue;
    private readonly Dictionary<Type, Func<object>> _dbCtors;
    private Task _commitTask;
    private CancellationTokenSource _commitTaskCancel;

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

        _commitQueue = new Dictionary<Type, ConcurrentQueue<Commit>>
        {
            { typeof(ClassiccharactersDbContext), new ConcurrentQueue<Commit>() },
            { typeof(ClassiclogsDbContext), new ConcurrentQueue<Commit>() },
            { typeof(ClassicmangosDbContext), new ConcurrentQueue<Commit>() },
            { typeof(ClassicrealmdDbContext), new ConcurrentQueue<Commit>() }
        };

        _dbCtors = new Dictionary<Type, Func<object>>
        {
            { typeof(ClassiccharactersDbContext), () => new ClassiccharactersDbContext(_characterDbOptions) },
            { typeof(ClassiclogsDbContext), () => new ClassiccharactersDbContext(_logsDbOptions) },
            { typeof(ClassicmangosDbContext), () => new ClassiccharactersDbContext(_mangosDbOptions) },
            { typeof(ClassicrealmdDbContext), () => new ClassiccharactersDbContext(_realmDbOptions) },
            { typeof(ClientDbContext), () => new ClientDbContext(_logger, _memoryCache) }
        };
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

        if (_commitTask != default)
            _commitTaskCancel.Cancel();

        ResetCommitTimer();
    }

    private void ResetCommitTimer()
    {
        _commitTaskCancel?.Cancel();
        _commitTaskCancel?.Dispose();

        // TODO: make the commit interval configurable
        _commitTaskCancel = new CancellationTokenSource();
        _commitTask = Task.Delay(5000, _commitTaskCancel.Token).ContinueWith(CommitCallback, _commitTaskCancel.Token);
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

            // This is used to "fix" some of the faulty MySQL syntax generated by the MySQL EF adapter.
            .AddInterceptors(_interceptor)

            // This will mega spam your debug window. If it is a problem, remove this line.
            .LogTo(s => Debug.WriteLine(s));

        return options.Options;
    }

    private object Use(Type type) =>
        _dbCtors[type]();

    private T Use<T>() =>
        (T)Use(typeof(T));

    public void UseLogin(Action<ClassicrealmdDbContext> context)
    {
        using var db = Use<ClassicrealmdDbContext>();
        context(db);
    }

    public T UseLogin<T>(Func<ClassicrealmdDbContext, T> context)
    {
        using var db = Use<ClassicrealmdDbContext>();
        return context(db);
    }

    public void UseWorld(Action<ClassicmangosDbContext> context)
    {
        using var db = Use<ClassicmangosDbContext>();
        context(db);
    }

    public T UseWorld<T>(Func<ClassicmangosDbContext, T> context)
    {
        using var db = Use<ClassicmangosDbContext>();
        return context(db);
    }

    public void UseCharacter(Action<ClassiccharactersDbContext> context)
    {
        using var db = Use<ClassiccharactersDbContext>();
        context(db);
    }

    public T UseCharacter<T>(Func<ClassiccharactersDbContext, T> context)
    {
        using var db = Use<ClassiccharactersDbContext>();
        return context(db);
    }

    public void UseLogs(Action<ClassiclogsDbContext> context)
    {
        using var db = Use<ClassiclogsDbContext>();
        context(db);
    }

    public T UseLogs<T>(Func<ClassiclogsDbContext, T> context)
    {
        using var db = Use<ClassiclogsDbContext>();
        return context(db);
    }

    public void UseClient(Action<ClientDbContext> context)
    {
        using var db = Use<ClientDbContext>();
        context(db);
    }

    public T UseClient<T>(Func<ClientDbContext, T> context)
    {
        using var db = Use<ClientDbContext>();
        return context(db);
    }

    private void CommitCallback(Task _)
    {
        var commits = new Dictionary<Type, List<Commit>>();
        
        lock (_commitQueue)
        {
            foreach (var (type, queue) in _commitQueue)
            {
                lock (queue)
                {
                    commits[type] = new List<Commit>(queue);
                    queue.Clear();
                }
            }
        }

        foreach (var (type, queue) in commits)
        {
            using var ctx = Use(type) as IDisposable;
            foreach (var item in queue)
                item.Action(ctx);
        }
    }

    private void CommitInternal<T>(Action<T> context) => 
        _commitQueue[typeof(T)].Enqueue(new Commit { Action = x => context((T)x) });

    public void CommitLogin(Action<ClassicrealmdDbContext> context) => 
        CommitInternal(context);

    public void CommitWorld(Action<ClassicmangosDbContext> context) =>
        CommitInternal(context);

    public void CommitCharacter(Action<ClassiccharactersDbContext> context) =>
        CommitInternal(context);

    public void CommitLogs(Action<ClassiclogsDbContext> context) =>
        CommitInternal(context);

    private sealed class Interceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            // So, the EF connector attempts to cast some things whenever the data types don't exactly match. Thing is,
            // all the types the adapter tries to cast are not actually supported by MySQL. It's stupid, yes, but we can't
            // turn it off. So the next best thing is to shim it.
            //
            // We assume all implicit casting between incompatible types will fail, and that's okay. We can't fix that
            // situation anyway. Implicit casting between compatible types should be done by MySQL and not EF.
            //
            // Example: (characters to remove are indicated with 'x':)
            // SELECT COALESCE(SUM(CAST(`r`.`numchars` AS int)), 0) FROM `realmcharacters` AS `r` WHERE `r`.`acctid` = @__xid_0
            //                     xxxxx               xxxxxxx

            var text = command.CommandText;
            var replaced = false;
            while (text.Contains("CAST"))
            {
                var prefixLength = text.IndexOf("CAST(", StringComparison.Ordinal);
                var snipStart = prefixLength + 5;
                var snipLength = text.IndexOf("` AS ", snipStart, StringComparison.Ordinal) - snipStart + 1;
                var postfixStart = text.IndexOf(")", snipStart, StringComparison.Ordinal) + 1;
                text = string.Concat(text[..prefixLength], text.Substring(snipStart, snipLength), text[postfixStart..]);
                replaced = true;
            }

            if (replaced)
                command.CommandText = text;
            return base.ReaderExecuting(command, eventData, result);
        }
    }

    private struct Commit
    {
        public Action<object> Action { get; init; }
    }
}