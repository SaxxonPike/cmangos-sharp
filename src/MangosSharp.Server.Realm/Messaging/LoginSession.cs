using System;
using MangosSharp.Core.Security;

namespace MangosSharp.Server.Realm.Messaging;

public class LoginSession
{
    public long AccountId { get; set; }
    public string Name { get; set; }
    public int Build { get; set; }
    public SessionStatus Status { get; set; }
    public AccountTypes Level { get; set; }
    public DateTimeOffset Created { get; set; }
    public SecurityFlag Flags { get; set; }
    public string Token { get; set; }
    public string Locale { get; set; }
    public string Os { get; set; }
    public string Platform { get; set; }
}