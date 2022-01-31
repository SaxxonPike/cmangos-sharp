using System;
using Mangos.Data.Context;

namespace Mangos.Server.Core.Services;

public interface IDatabase
{
    void UseLogin(Action<RealmDbContext> context);
    T UseLogin<T>(Func<RealmDbContext, T> context);
    void UseWorld(Action<MangosDbContext> context);
    T UseWorld<T>(Func<MangosDbContext, T> context);
    void UseCharacter(Action<CharacterDbContext> context);
    T UseCharacter<T>(Func<CharacterDbContext, T> context);
    void UseLogs(Action<LogsDbContext> context);
    T UseLogs<T>(Func<LogsDbContext, T> context);
    void UseClient(Action<ClientDbContext> context);
    T UseClient<T>(Func<ClientDbContext, T> context);
}