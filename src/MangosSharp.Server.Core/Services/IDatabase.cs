using System;
using MangosSharp.Data.Context;

namespace MangosSharp.Server.Core.Services;

public interface IDatabase
{
    /// <summary>
    /// Open the REALMD database to perform actions on it.
    /// </summary>
    void UseLogin(Action<ClassicrealmdDbContext> context);
    
    /// <summary>
    /// Open the REALMD database to perform actions on it.
    /// </summary>
    T UseLogin<T>(Func<ClassicrealmdDbContext, T> context);
    
    /// <summary>
    /// Open the MANGOS database to perform actions on it.
    /// </summary>
    void UseWorld(Action<ClassicmangosDbContext> context);
    
    /// <summary>
    /// Open the MANGOS database to perform actions on it.
    /// </summary>
    T UseWorld<T>(Func<ClassicmangosDbContext, T> context);
    
    /// <summary>
    /// Open the CHARACTERS database to perform actions on it.
    /// </summary>
    void UseCharacter(Action<ClassiccharactersDbContext> context);
    
    /// <summary>
    /// Open the CHARACTERS database to perform actions on it.
    /// </summary>
    T UseCharacter<T>(Func<ClassiccharactersDbContext, T> context);
    
    /// <summary>
    /// Open the LOGS database to perform actions on it.
    /// </summary>
    void UseLogs(Action<ClassiclogsDbContext> context);
    
    /// <summary>
    /// Open the LOGS database to perform actions on it.
    /// </summary>
    T UseLogs<T>(Func<ClassiclogsDbContext, T> context);
    
    /// <summary>
    /// Open the client database (DBC).
    /// </summary>
    void UseClient(Action<ClientDbContext> context);
    
    /// <summary>
    /// Open the client database (DBC).
    /// </summary>
    T UseClient<T>(Func<ClientDbContext, T> context);

    /// <summary>
    /// Enqueue a deferred commit to the REALMD database.
    /// </summary>
    void CommitLogin(Action<ClassicrealmdDbContext> context);
    
    /// <summary>
    /// Enqueue a deferred commit to the MANGOS database.
    /// </summary>
    void CommitWorld(Action<ClassicmangosDbContext> context);
    
    /// <summary>
    /// Enqueue a deferred commit to the CHARACTER database.
    /// </summary>
    void CommitCharacter(Action<ClassiccharactersDbContext> context);

    /// <summary>
    /// Enqueue a deferred commit to the LOGS database.
    /// </summary>
    void CommitLogs(Action<ClassiclogsDbContext> context);
}