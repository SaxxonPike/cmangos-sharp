using System;

namespace MangosSharp.Core.Security;

public interface IAuthService
{
    AuthChallengeClient CreateChallenge(string endpoint, long id, ReadOnlyMemory<char> username, ReadOnlyMemory<byte> passwordVerifier, ReadOnlyMemory<byte> salt);
    AuthChallengeServer VerifyChallenge(string endpoint, ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> clientProof);
    AuthState CreateState(string endpoint, long id, ReadOnlyMemory<char> username, ReadOnlyMemory<byte> sessionKey);
    AuthState RefreshState(string endpoint);
    AuthState GetState(string endpoint);
    void DeleteState(string endpoint);
    void ResetState(string endpoint);
    ReadOnlyMemory<byte> CalculatePasswordVerifier(ReadOnlySpan<char> username, ReadOnlySpan<char> password, ReadOnlySpan<byte> salt);
    ReadOnlyMemory<byte> CalculateX(ReadOnlySpan<char> username, ReadOnlySpan<char> password, ReadOnlySpan<byte> salt);
    ReadOnlyMemory<byte> CalculateServerPublicKey(ReadOnlySpan<byte> passwordVerifier, ReadOnlySpan<byte> serverPrivateKey);
    ReadOnlyMemory<byte> CalculateServerSKey(ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> passwordVerifier, ReadOnlySpan<byte> u, ReadOnlySpan<byte> serverPrivateKey);
    ReadOnlyMemory<byte> CalculateU(ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> serverPublicKey);
    ReadOnlyMemory<byte> CalculateSessionKey(ReadOnlySpan<byte> sKey);
    ReadOnlyMemory<byte> CalculateServerProof(ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> clientProof, ReadOnlySpan<byte> sessionKey);
    ReadOnlyMemory<byte> CalculateXorHash();
    ReadOnlyMemory<byte> CalculateReconnectProof(ReadOnlySpan<char> username, ReadOnlySpan<byte> clientData, ReadOnlySpan<byte> serverData, ReadOnlySpan<byte> sessionKey);
    Memory<byte> Encrypt(ReadOnlySpan<byte> data, AuthState state);
    void EncryptInPlace(Span<byte> data, AuthState state);
    Memory<byte> Decrypt(ReadOnlySpan<byte> data, AuthState state);
    void DecryptInPlace(Span<byte> data, AuthState state);
    ReadOnlyMemory<byte> GetLargeSafePrime();
    ReadOnlyMemory<byte> GetGenerator();
    Memory<byte> GenerateSalt();
    string LookupIpByAccountId(int accountId);
}