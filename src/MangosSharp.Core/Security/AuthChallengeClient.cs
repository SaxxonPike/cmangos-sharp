using System;

namespace MangosSharp.Core.Security;

public sealed class AuthChallengeClient
{
    public DateTimeOffset Expiry { get; set; }
    public ReadOnlyMemory<byte> ServerPublicKey { get; set; }
    public ReadOnlyMemory<byte> ServerPrivateKey { get; set; }
    public ReadOnlyMemory<byte> Generator { get; set; }
    public ReadOnlyMemory<byte> LargeSafePrime { get; set; }
    public ReadOnlyMemory<byte> Salt { get; set; }
    public ReadOnlyMemory<char> Username { get; set; }
    public ReadOnlyMemory<byte> PasswordVerifier { get; set; }
    public long AccountId { get; set; }
}