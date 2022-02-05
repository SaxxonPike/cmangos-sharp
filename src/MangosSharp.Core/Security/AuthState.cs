using System;

namespace MangosSharp.Core.Security;

public sealed class AuthState
{
    public long AccountId { get; set; }
    public ReadOnlyMemory<byte> SessionKey { get; set; }
    public int EncryptionKeyIndex { get; set; }
    public byte LastEncryptedValue { get; set; }
    public int DecryptionKeyIndex { get; set; }
    public byte LastDecryptedValue { get; set; }
    public bool Encrypted { get; set; }
    public ReadOnlyMemory<char> Username { get; set; }
}