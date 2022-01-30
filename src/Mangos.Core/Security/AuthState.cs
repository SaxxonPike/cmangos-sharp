using System;

namespace Mangos.Core.Security;

public sealed class AuthState
{
    public int AccountId { get; set; }
    public ReadOnlyMemory<byte> SessionKey { get; set; }
    public DateTimeOffset Expiry { get; set; }
    public int EncryptionKeyIndex { get; set; }
    public byte LastEncryptedValue { get; set; }
    public int DecryptionKeyIndex { get; set; }
    public byte LastDecryptedValue { get; set; }
    public bool Encrypted { get; set; }
    public string Username { get; set; }
}