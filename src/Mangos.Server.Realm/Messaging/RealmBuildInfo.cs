using System;

namespace Mangos.Server.Realm.Messaging;

public sealed class RealmBuildInfo
{
    public RealmBuildInfo(int build, int major, int minor, int revision, char sub, ReadOnlyMemory<byte> winHash,
        ReadOnlyMemory<byte> macHash)
    {
        Build = build;
        Major = major;
        Minor = minor;
        Revision = revision;
        Sub = sub;
        WindowsHash = winHash;
        MacHash = macHash;
    }

    public int Build { get; }
    public int Revision { get; }
    public int Minor { get; }
    public int Major { get; }
    public char Sub { get; }
    public ReadOnlyMemory<byte> WindowsHash { get; }
    public ReadOnlyMemory<byte> MacHash { get; }
}