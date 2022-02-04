using System;
using MangosSharp.Server.Core.Enums;
using MangosSharp.Server.Realm.Enums;

namespace MangosSharp.Server.Realm.Records;

public sealed class LoginSession
{
    public long AccountId { get; set; }
    public string Name { get; set; }
    public int Build { get; set; }
    public SessionStatus Status { get; set; }
    public AccountType Level { get; set; }
    public DateTimeOffset Created { get; set; }
    public SecurityFlag Flags { get; set; }
    public string Token { get; set; }
    public string Locale { get; set; }
    public string Os { get; set; }
    public string Platform { get; set; }
}