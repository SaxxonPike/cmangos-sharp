using System;
using MangosSharp.Data.Context;

namespace MangosSharp.Server.Core.Services;

public interface IDatabase
{
    void UseLogin(Action<ClassicrealmdDbContext> context);
    T UseLogin<T>(Func<ClassicrealmdDbContext, T> context);
    void UseWorld(Action<ClassicmangosDbContext> context);
    T UseWorld<T>(Func<ClassicmangosDbContext, T> context);
    void UseCharacter(Action<ClassiccharactersDbContext> context);
    T UseCharacter<T>(Func<ClassiccharactersDbContext, T> context);
    void UseLogs(Action<ClassiclogsDbContext> context);
    T UseLogs<T>(Func<ClassiclogsDbContext, T> context);
    void UseClient(Action<ClientDbContext> context);
    T UseClient<T>(Func<ClientDbContext, T> context);
}