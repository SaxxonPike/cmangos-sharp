using System;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace MangosSharp.Core.Security;

public sealed class Srp6 : IDisposable
{
    private readonly SHA1 Sha1 = SHA1.Create();

    private static readonly byte[] Zero = new byte[32];
    
    private static readonly byte[] Nbytes = {
        0x89, 0x4b, 0x64, 0x5e, 0x89, 0xe1, 0x53, 0x5b,
        0xbd, 0xad, 0x5b, 0x8b, 0x29, 0x06, 0x50, 0x53,
        0x08, 0x01, 0xb1, 0x8e, 0xbf, 0xbf, 0x5e, 0x8f,
        0xab, 0x3c, 0x82, 0x87, 0x2a, 0x3e, 0x9b, 0xb7
    };
    
    private static readonly BigInteger N = new(Nbytes, true, true);

    private static readonly byte[] hashN = GetHash(Nbytes);

    private static readonly byte[] gbytes = { 0x07 };
    
    private static readonly BigInteger g = new(gbytes, true);

    private static readonly byte[] hashg = GetHash(g);

    private static readonly byte[] xor = GetXor(hashN, hashg);

    private byte[] A, u, S, s, B, K, M, b, v;
    
    // A: 32 bytes
    // B: 32 bytes
    // b: 32 bytes
    // K: 40 bytes
    // M: 20 bytes
    // S: 32 bytes
    // s: 32 bytes
    // u: 20 bytes
    // v: 32 bytes
    // x: 20 bytes
    // xor: 20 bytes

    private static byte[] GetHash(BigInteger i)
    {
        using var sha = SHA1.Create();
        return sha.ComputeHash(i.ToByteArray());
    }

    private static byte[] GetHash(byte[] b)
    {
        using var sha = SHA1.Create();
        return sha.ComputeHash(b);
    }

    private static byte[] GetXor(ReadOnlySpan<byte> hN, ReadOnlySpan<byte> hg)
    {
        var result = new byte[20];
        for (var i = 0; i < 20; i++)
            result[i] = unchecked((byte)(hN[i] ^ hg[i]));
        return result;
    }
    
    private static void Reverse(Span<byte> bytes)
    {
        var length = bytes.Length / 2;
        for (var i = 0; i < length; i++)
            (bytes[i], bytes[^(i + 1)]) = (bytes[^(i + 1)], bytes[i]);
    }

    private static byte[] GetUtf8Bytes(ReadOnlySpan<char> chars)
    {
        var utf8 = Encoding.UTF8;
        var buffer = new byte[utf8.GetByteCount(chars)];
        utf8.GetBytes(chars, buffer);
        return buffer;
    }

    public ReadOnlySpan<byte> GetHostPublicEphemeral() => B;

    public static ReadOnlySpan<byte> GetGeneratorModulo() => gbytes;

    public static ReadOnlySpan<byte> GetPrime() => Nbytes;

    public ReadOnlySpan<byte> GetProof() => M;

    public ReadOnlySpan<byte> GetSalt() => s;

    public ReadOnlySpan<byte> GetStrongSessionKey() => K;

    public ReadOnlySpan<byte> GetVerifier() => v;

    public void SetStrongSessionKey(ReadOnlySpan<char> new_K)
    {
        K = new byte[40];
        Convert.FromHexString(new_K).AsSpan().CopyTo(K);
    }

    public void CalculateHostPublicEphemeral()
    {
        b = new byte[32];
        Random.Shared.NextBytes(b.AsSpan(0, 19));
        
        var ib = new BigInteger(b, true);
        var iv = new BigInteger(v, true);
        
        var gmod = g.ModPow(ib, N);
        B = ((iv * 3 + gmod) % N).ToByteArray(32, true);
    }

    public void CalculateProof(ReadOnlySpan<char> username)
    {
        var t4 = Sha1.ComputeHash(GetUtf8Bytes(username));
        using var mem = new MemoryStream();
        mem.Write(xor);
        mem.Write(t4);
        mem.Write(s);
        mem.Write(A);
        mem.Write(B);
        mem.Write(K);
        mem.Position = 0;
        M = Sha1.ComputeHash(mem);
    }

    public bool CalculateSessionKey(ReadOnlySpan<byte> lp_A)
    {
        var iA = new BigInteger(lp_A, true);
        
        if (iA.IsZero)
            return false;
        
        if ((iA % N).IsZero)
            return false;

        A = iA.ToByteArray(32, true);

        var iv = new BigInteger(v, true);
        var ib = new BigInteger(b, true);
        
        using var mem = new MemoryStream();
        mem.Write(A);
        mem.Write(B);
        mem.Position = 0;

        u = Sha1.ComputeHash(mem);
        var iu = new BigInteger(u, true);

        S = (iA * iv.ModPow(iu, N)).ModPow(ib, N).ToByteArray(32, true);

        return true;
    }

    public bool CalculateVerifier(string userPassHash)
    {
        var salt = new byte[20];
        Random.Shared.NextBytes(salt);
        return CalculateVerifier(userPassHash, Convert.ToHexString(salt));
    }

    public bool CalculateVerifier(ReadOnlySpan<char> userPassHash, ReadOnlySpan<char> saltHash)
    {
        s = new byte[20];
        Convert.FromHexString(saltHash).CopyTo(s.AsSpan());
        if (s.AsSpan().SequenceEqual(Zero.AsSpan(0, 20)))
            return false;

        var mDigest = new byte[20];
        Convert.FromHexString(userPassHash).CopyTo(mDigest.AsSpan());
        Reverse(mDigest);
        using var mem = new MemoryStream();
        mem.Write(s);
        mem.Write(mDigest);
        mem.Position = 0;
        var x = new BigInteger(Sha1.ComputeHash(mem), true, true);
        v = g.ModPow(x, N).ToByteArray(32, true);
        return true;
    }

    public void HashSessionKey()
    {
        var t = new byte[32];
        var t1 = new byte[16];
        K = new byte[40];

        S.CopyTo(t.AsSpan());
        for (var i = 0; i < 16; ++i)
            t1[i] = t[i * 2];
        var digest = Sha1.ComputeHash(t1);
        for (var i = 0; i < 20; ++i)
            K[i * 2] = digest[i];
        for (var i = 0; i < 16; ++i)
            t1[i] = t[i * 2 + 1];
        digest = Sha1.ComputeHash(t1);
        for (var i = 0; i < 20; ++i)
            K[i * 2 + 1] = digest[i];
    }

    public bool Proof(ReadOnlySpan<byte> lp_M)
    {
        return M.AsSpan().SequenceEqual(lp_M);
    }

    public bool ProofVerifier(ReadOnlySpan<char> vC)
    {
        return Convert.FromHexString(vC).AsSpan().SequenceEqual(v);
    }

    public Memory<byte> Finalize()
    {
        using var mem = new MemoryStream();
        mem.Write(A);
        mem.Write(M);
        mem.Write(K);
        mem.Position = 0;
        return Sha1.ComputeHash(mem);
    }

    public bool SetSalt(ReadOnlySpan<char> new_s)
    {
        s = new byte[32];
        Convert.FromHexString(new_s).CopyTo(s.AsSpan());
        return !s.AsSpan().SequenceEqual(Zero.AsSpan(0, 32));
    }

    public bool SetVerifier(ReadOnlySpan<char> new_v)
    {
        v = new byte[32];
        Convert.FromHexString(new_v).CopyTo(v.AsSpan());
        return !v.AsSpan().SequenceEqual(Zero.AsSpan(0, 32));
    }

    public void Dispose()
    {
        Sha1?.Dispose();
    }
}
