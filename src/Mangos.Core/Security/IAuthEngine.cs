using System;

namespace Mangos.Core.Security;

public interface IAuthEngine
{
    AuthChallengeClient CreateChallenge(string ip, int id, string username, ReadOnlyMemory<byte> passwordVerifier, ReadOnlyMemory<byte> salt);
    AuthChallengeServer VerifyChallenge(string ip, ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> clientProof);
    AuthState CreateState(string endpoint, int id, string username, ReadOnlyMemory<byte> sessionKey);
    AuthState RefreshState(string ip);
    AuthState GetState(string ip);
    void DeleteState(string ip);
    void ResetState(string endpoint);
    ReadOnlyMemory<byte> CalculatePasswordVerifier(string username, string password, ReadOnlySpan<byte> salt);
    ReadOnlyMemory<byte> CalculateX(string username, string password, ReadOnlySpan<byte> salt);
    ReadOnlyMemory<byte> CalculateServerPublicKey(ReadOnlySpan<byte> passwordVerifier, ReadOnlySpan<byte> serverPrivateKey);
    ReadOnlyMemory<byte> CalculateClientSKey(ReadOnlySpan<byte> clientPrivateKey, ReadOnlySpan<byte> serverPublicKey, ReadOnlySpan<byte> x, ReadOnlySpan<byte> u);
    ReadOnlyMemory<byte> CalculateServerSKey(ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> passwordVerifier, ReadOnlySpan<byte> u, ReadOnlySpan<byte> serverPrivateKey);
    ReadOnlyMemory<byte> CalculateU(ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> serverPublicKey);
    ReadOnlyMemory<byte> CalculateSessionKey(ReadOnlySpan<byte> sKey);
    ReadOnlyMemory<byte> CalculateServerProof(ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> clientProof, ReadOnlySpan<byte> sessionKey);
    ReadOnlyMemory<byte> CalculateClientProof(ReadOnlySpan<byte> xorHash, string username, ReadOnlySpan<byte> sessionKey, ReadOnlySpan<byte> clientPublicKey, ReadOnlySpan<byte> serverPublicKey, ReadOnlySpan<byte> salt);
    ReadOnlyMemory<byte> CalculateXorHash();
    ReadOnlyMemory<byte> CalculateClientPublicKey(ReadOnlySpan<byte> clientPrivateKey, ReadOnlySpan<byte> generator, ReadOnlySpan<byte> largeSafePrime);
    ReadOnlyMemory<byte> CalculateReconnectProof(string username, ReadOnlySpan<byte> clientData, ReadOnlySpan<byte> serverData, ReadOnlySpan<byte> sessionKey);
    Memory<byte> Encrypt(ReadOnlySpan<byte> data, AuthState state);
    Memory<byte> Decrypt(ReadOnlySpan<byte> data, AuthState state);
    ReadOnlyMemory<byte> GetLargeSafePrime();
    ReadOnlyMemory<byte> GetGenerator();
    Memory<byte> GenerateSalt();
    string LookupIpByAccountId(int accountId);
}