using System;

namespace Mangos.Core.Security;

public sealed class AuthChallengeServer
{
    public ReadOnlyMemory<byte> ServerProof { get; set; }
    public string Username { get; set; }
    public ReadOnlyMemory<byte> SessionKey { get; set; }
    public int AccountId { get; set; }
}