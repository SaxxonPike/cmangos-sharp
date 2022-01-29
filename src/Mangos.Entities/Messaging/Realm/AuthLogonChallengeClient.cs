namespace Mangos.Entities.Messaging.Realm;

public class AuthLogonChallengeClient
{
    public byte cmd;
    public byte error;
    public ushort size;
    public byte[] gamename = new byte[4];
    public byte version1;
    public byte version2;
    public byte version3;
    public ushort build;
    public byte[] platform = new byte[4];
    public byte[] os = new byte[4];
    public byte[] country = new byte[4];
    public uint timezone_bias;
    public uint ip;
    public byte I_len;
    public byte[] I = new byte[1];
}