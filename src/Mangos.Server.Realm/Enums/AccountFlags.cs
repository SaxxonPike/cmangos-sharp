using System;

namespace Mangos.Server.Realm.Enums;

[Flags]
public enum AccountFlags
{
    ACCOUNT_FLAG_GM = 0x00000001,
    ACCOUNT_FLAG_TRIAL = 0x00000008,
    ACCOUNT_FLAG_PROPASS = 0x00800000
}

public struct AuthLogonChallengeC
{
    public byte cmd;
    public byte error;
    public ushort size;
    public byte[] gamename;
    public byte version1;
    public byte version2;
    public byte version3;
    public ushort build;
    public byte[] platform;
    public byte[] os;
    public byte[] country;
    public uint timezone_bias;
    public uint ip;
    public byte I_len;
    public byte[] I;
}

public struct AuthLogonPinDataC
{
    public byte[] salt;
    public byte[] hash;
}

public struct AuthLogonProofC
{
    public byte cmd;
    public byte[] A;
    public byte[] M1;
    public byte[] crc_hash;
    public byte number_of_keys;
    public byte securityFlags;
}

public struct AuthLogonProofSBuild6005
{
    public byte cmd;
    public byte error;
    public byte[] M2;
    public uint LoginFlags;
}

public struct AuthReconnectProofC
{
    public byte cmd;
    public byte[] R1;
    public byte[] R2;
    public byte[] R3;
    public byte number_of_keys;
}

public struct XferInit
{
    public byte cmd;
    public byte fileNameLen;
    public byte[] fileName;
    public ulong file_size;
    public byte[] md5;
}