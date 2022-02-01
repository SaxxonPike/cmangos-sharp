using System;

namespace MangosSharp.Core.Security;

public sealed class AuthChallengeServer
{
    public ReadOnlyMemory<byte> ServerProof { get; set; }
    public ReadOnlyMemory<char> Username { get; set; }
    public ReadOnlyMemory<byte> SessionKey { get; set; }
    public long AccountId { get; set; }
}