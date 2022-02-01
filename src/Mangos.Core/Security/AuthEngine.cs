using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Mangos.Core.Security;

public sealed class AuthEngine : IAuthEngine
{
    // WoW uses a key exchange method called SRP6, slightly modified.
    // Reference: https://gtker.com/implementation-guide-for-the-world-of-warcraft-flavor-of-srp6/
    // C# implementation: Saxxon Fox

    private readonly Dictionary<string, AuthState> _states = new();
    private readonly Dictionary<string, AuthChallengeClient> _challenges = new();

    private static readonly TimeSpan StateTtl = TimeSpan.FromMinutes(10);
    private static readonly TimeSpan ChallengeTtl = TimeSpan.FromSeconds(30);

    // aka: N (do not change)
    private static readonly byte[] LargeSafePrimeBytes =
    {
        0xb7, 0x9b, 0x3e, 0x2a, 0x87, 0x82, 0x3c, 0xab,
        0x8f, 0x5e, 0xbf, 0xbf, 0x8e, 0xb1, 0x01, 0x08,
        0x53, 0x50, 0x06, 0x29, 0x8b, 0x5b, 0xad, 0xbd,
        0x5b, 0x53, 0xe1, 0x89, 0x5e, 0x64, 0x4b, 0x89
    };

    private static readonly BigInteger LargeSafePrime = new(LargeSafePrimeBytes, true);

    // aka: g (do not change)
    private static readonly byte[] GeneratorBytes =
    {
        0x07
    };

    private static readonly BigInteger Generator = new(GeneratorBytes, true);

    // aka: k (do not change)
    private static readonly BigInteger K = 3;

    private static readonly SHA1 Sha1 = SHA1.Create();

    private static readonly Encoding Utf8 = Encoding.UTF8;

    private static readonly ReadOnlyMemory<byte> XorCache = CalculateXorHashInternal();

    private static ReadOnlyMemory<byte> Zip(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
    {
        if (left.Length != right.Length)
            throw new Exception("Arrays are not the same length.");

        var output = new byte[left.Length + right.Length];
        var index = 0;
        for (var i = 0; i < left.Length; i++)
        {
            output[index++] = left[i];
            output[index++] = right[i];
        }

        return output;
    }

    private static void UnZip(ReadOnlySpan<byte> bytes, Span<byte> left, Span<byte> right)
    {
        var index = 0;
        for (var i = 0; i < bytes.Length;)
        {
            left[index] = bytes[i++];
            right[index++] = bytes[i++];
        }
    }

    public AuthChallengeClient CreateChallenge(string endpoint, long id, ReadOnlyMemory<char> username,
        ReadOnlyMemory<byte> passwordVerifier, ReadOnlyMemory<byte> salt)
    {
        var secret = new byte[32];
        Random.Shared.NextBytes(secret);
        
        var result = new AuthChallengeClient
        {
            AccountId = id,
            Username = username,
            PasswordVerifier = passwordVerifier,
            ServerPublicKey = CalculateServerPublicKey(passwordVerifier.Span, secret),
            ServerPrivateKey = secret,
            Salt = salt,
            Expiry = DateTimeOffset.Now + ChallengeTtl,
            Generator = Generator.ToByteArray(true),
            LargeSafePrime = LargeSafePrimeBytes.AsMemory()
        };

        _challenges[endpoint] = result;
        return result;
    }

    public AuthChallengeServer VerifyChallenge(string endpoint, ReadOnlySpan<byte> clientPublicKey,
        ReadOnlySpan<byte> clientProof)
    {
        if (!_challenges.TryGetValue(endpoint, out var challenge) || challenge.Expiry < DateTimeOffset.Now)
            return default;
        _challenges.Remove(endpoint);

        // Verify the proofs.
        var sKey = CalculateServerSKey(clientPublicKey, challenge.PasswordVerifier.Span,
            CalculateU(clientPublicKey, challenge.ServerPublicKey.Span).Span, challenge.ServerPrivateKey.Span);
        var sessionKey = CalculateSessionKey(sKey.Span);
        var expected = CalculateClientProof(XorCache.Span, challenge.Username, sessionKey.Span, clientPublicKey,
            challenge.ServerPublicKey.Span, challenge.Salt.Span);
        if (!expected.Span.SequenceEqual(clientProof))
            return new AuthChallengeServer { Username = challenge.Username };

        // Success, now generate auth state with the key.
        DeleteState(endpoint);
        CreateState(endpoint, challenge.AccountId, challenge.Username, sessionKey);

        return new AuthChallengeServer
        {
            ServerProof = CalculateServerProof(clientPublicKey, clientProof, sessionKey.Span),
            SessionKey = sessionKey,
            Username = challenge.Username,
            AccountId = challenge.AccountId
        };
    }

    public AuthState CreateState(string endpoint, long id, ReadOnlyMemory<char> username, ReadOnlyMemory<byte> sessionKey)
    {
        if (_states.TryGetValue(endpoint, out var existing))
            return existing;

        // This immediately invalidates all state of previous connections from the same user ID.
        foreach (var kv in _states.Where(s => s.Value?.AccountId == id).ToList())
            _states.Remove(kv.Key);

        var state = new AuthState
        {
            AccountId = id,
            Username = username,
            SessionKey = sessionKey,
        };
        _states.Add(endpoint, state);
        RefreshState(endpoint);

        return state;
    }

    public AuthState RefreshState(string endpoint)
    {
        if (_states.TryGetValue(endpoint, out var state))
            state.Expiry = DateTimeOffset.Now + StateTtl;
        return state;
    }

    public AuthState GetState(string endpoint)
    {
        // Reuse existing auth state if it's not expired yet.
        if (!_states.TryGetValue(endpoint, out var result) || result.Expiry < DateTimeOffset.Now)
            return default;

        // Auto refresh states in active use.
        RefreshState(endpoint);
        return result;
    }

    public void DeleteState(string endpoint)
    {
        _states.Remove(endpoint);
    }

    public void ResetState(string endpoint)
    {
        if (!_states.TryGetValue(endpoint, out var result))
            return;

        result.Encrypted = false;
        result.DecryptionKeyIndex = 0;
        result.EncryptionKeyIndex = 0;
        result.LastDecryptedValue = 0;
        result.LastEncryptedValue = 0;
    }

    // Calculates password verifier. This is what logins will be compared against.
    public ReadOnlyMemory<byte> CalculatePasswordVerifier(ReadOnlySpan<char> username, ReadOnlySpan<char> password, ReadOnlySpan<byte> salt)
    {
        Debug.Assert(salt.Length == 32);

        var x = CalculateX(username, password, salt);
        var result = BigInteger.ModPow(Generator, new BigInteger(x.Span, true), LargeSafePrime)
            .ToByteArray(32, true);
        return result;
    }

    public ReadOnlyMemory<byte> CalculateX(ReadOnlySpan<char> username, ReadOnlySpan<char> password, ReadOnlySpan<byte> salt)
    {
        Debug.Assert(salt.Length == 32);

        var usernameLength = Utf8.GetByteCount(username);
        var passwordLength = Utf8.GetByteCount(password);
        var credentialInput = new byte[usernameLength + 1 + passwordLength];
        Utf8.GetBytes(username, credentialInput);
        Utf8.GetBytes(password, credentialInput.AsSpan(usernameLength + 1));
        credentialInput[usernameLength] = (byte)':';
        var credentialHash = Sha1.ComputeHash(credentialInput);

        var resultInput = new byte[salt.Length + credentialHash.Length];
        salt.CopyTo(resultInput);
        credentialHash.CopyTo(resultInput.AsSpan(salt.Length));
        var resultHash = Sha1.ComputeHash(resultInput);

        return resultHash;
    }

    public ReadOnlyMemory<byte> CalculateServerPublicKey(ReadOnlySpan<byte> passwordVerifier,
        ReadOnlySpan<byte> serverPrivateKey)
    {
        var vi = new BigInteger(passwordVerifier, true);
        var bi = new BigInteger(serverPrivateKey, true);
        var result =
            ((K * vi + BigInteger.ModPow(Generator, bi, LargeSafePrime)) % LargeSafePrime).ToByteArray(32, true);
        return result;
    }

    public ReadOnlyMemory<byte> CalculateServerSKey(ReadOnlySpan<byte> clientPublicKey,
        ReadOnlySpan<byte> passwordVerifier, ReadOnlySpan<byte> u, ReadOnlySpan<byte> serverPrivateKey)
    {
        var ai = new BigInteger(clientPublicKey, true);
        var vi = new BigInteger(passwordVerifier, true);
        var ui = new BigInteger(u, true);
        var bi = new BigInteger(serverPrivateKey, true);

        var result = BigInteger.ModPow(ai * BigInteger.ModPow(vi, ui, LargeSafePrime), bi, LargeSafePrime)
            .ToByteArray(32, true);
        return result;
    }

    public ReadOnlyMemory<byte> CalculateU(ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> serverPublicKey)
    {
        var input = new byte[clientPublicKey.Length + serverPublicKey.Length];
        clientPublicKey.CopyTo(input);
        serverPublicKey.CopyTo(input.AsSpan(clientPublicKey.Length));
        return Sha1.ComputeHash(input);
    }

    public ReadOnlyMemory<byte> CalculateSessionKey(ReadOnlySpan<byte> sKey)
    {
        ReadOnlySpan<byte> TruncateKey(ReadOnlySpan<byte> key) =>
            key[0] == 0
                ? key[2..]
                : key;

        var splitKey = TruncateKey(sKey);
        var left = new byte[splitKey.Length / 2];
        var right = new byte[splitKey.Length / 2];
        UnZip(splitKey, left, right);
        var g = Sha1.ComputeHash(left);
        var h = Sha1.ComputeHash(right);
        var newKey = Zip(g, h);
        return newKey;
    }

    // aka: M2
    public ReadOnlyMemory<byte> CalculateServerProof(ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> clientProof,
        ReadOnlySpan<byte> sessionKey)
    {
        var input = new byte[clientPublicKey.Length + clientProof.Length + sessionKey.Length];
        var cursor = input.AsSpan();
        clientPublicKey.CopyTo(cursor);
        cursor = cursor[clientPublicKey.Length..];
        clientProof.CopyTo(cursor);
        cursor = cursor[clientProof.Length..];
        sessionKey.CopyTo(cursor);
        return Sha1.ComputeHash(input);
    }

    // aka: M1
    private static ReadOnlyMemory<byte> CalculateClientProof(ReadOnlySpan<byte> xorHash, ReadOnlyMemory<char> username,
        ReadOnlySpan<byte> sessionKey, ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> serverPublicKey,
        ReadOnlySpan<byte> salt)
    {
        var userHash = Sha1.ComputeHash(username.Span.ToUtf8Bytes());
        // source doc's pseudocode is incorrect for this line (transposed salt/sessionKey)
        var input = new byte[xorHash.Length + userHash.Length + salt.Length + clientPublicKey.Length +
                             serverPublicKey.Length + sessionKey.Length];
        var cursor = input.AsSpan();
        xorHash.CopyTo(cursor);
        cursor = cursor[xorHash.Length..];
        userHash.CopyTo(cursor);
        cursor = cursor[userHash.Length..];
        salt.CopyTo(cursor);
        cursor = cursor[salt.Length..];
        clientPublicKey.CopyTo(cursor);
        cursor = cursor[clientPublicKey.Length..];
        serverPublicKey.CopyTo(cursor);
        cursor = cursor[serverPublicKey.Length..];
        sessionKey.CopyTo(cursor);
        return Sha1.ComputeHash(input);
    }

    // aka: XOR_HASH - implemented this way because it can be pre-cached for performance
    public ReadOnlyMemory<byte> CalculateXorHash() => CalculateXorHashInternal();

    private static ReadOnlyMemory<byte> CalculateXorHashInternal()
    {
        var result = Sha1.ComputeHash(Generator.ToByteArray(true));
        var mask = Sha1.ComputeHash(LargeSafePrime.ToByteArray(32, true));
        for (var i = 0; i < result.Length; i++)
            result[i] ^= mask[i];
        return result;
    }

    public ReadOnlyMemory<byte> CalculateReconnectProof(ReadOnlySpan<char> username, ReadOnlySpan<byte> clientData,
        ReadOnlySpan<byte> serverData, ReadOnlySpan<byte> sessionKey)
    {
        var userBytes = username.ToUtf8Bytes();
        var input = new byte[userBytes.Length + clientData.Length + serverData.Length + sessionKey.Length];
        var cursor = input.AsSpan();
        userBytes.CopyTo(cursor);
        cursor = cursor[userBytes.Length..];
        clientData.CopyTo(cursor);
        cursor = cursor[clientData.Length..];
        serverData.CopyTo(cursor);
        cursor = cursor[serverData.Length..];
        sessionKey.CopyTo(cursor);
        return Sha1.ComputeHash(input);
    }

    public Memory<byte> Encrypt(ReadOnlySpan<byte> data, AuthState state)
    {
        var result = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
        {
            var d = data[i];
            var x = unchecked((byte)(d ^ state.SessionKey.Span[state.EncryptionKeyIndex++]));
            var a = unchecked((byte)(x + state.LastEncryptedValue));
            result[i] = a;
            state.LastEncryptedValue = a;
            state.EncryptionKeyIndex %= state.SessionKey.Length;
        }

        return result;
    }

    public Memory<byte> Decrypt(ReadOnlySpan<byte> data, AuthState state)
    {
        var result = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
        {
            var a = data[i];
            var x = unchecked((byte)(a - state.LastDecryptedValue));
            var d = unchecked((byte)(x ^ state.SessionKey.Span[state.DecryptionKeyIndex++]));
            result[i] = d;
            state.LastDecryptedValue = a;
            state.DecryptionKeyIndex %= state.SessionKey.Length;
        }

        return result;
    }

    public ReadOnlyMemory<byte> GetLargeSafePrime() => LargeSafePrimeBytes.AsMemory();

    public ReadOnlyMemory<byte> GetGenerator() => GeneratorBytes.AsMemory();

    public Memory<byte> GenerateSalt()
    {
        var salt = new byte[32];
        Random.Shared.NextBytes(salt);
        return salt;
    }

    public string LookupIpByAccountId(int accountId) =>
        _states.FirstOrDefault(s => s.Value?.AccountId == accountId).Key;
}