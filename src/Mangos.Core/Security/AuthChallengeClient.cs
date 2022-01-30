using System;

namespace Mangos.Core.Security;

public sealed class AuthChallengeClient
{
    public DateTimeOffset Expiry { get; set; }
    public ReadOnlyMemory<byte> ServerPublicKey { get; set; }
    public ReadOnlyMemory<byte> Generator { get; set; }
    public ReadOnlyMemory<byte> LargeSafePrime { get; set; }
    public ReadOnlyMemory<byte> Salt { get; set; }
    public ReadOnlyMemory<byte> CrcSalt { get; set; }
    public string Username { get; set; }
    public ReadOnlyMemory<byte> PasswordVerifier { get; set; }
    public int AccountId { get; set; }
}