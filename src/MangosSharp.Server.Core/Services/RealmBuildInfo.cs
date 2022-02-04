using System;

namespace MangosSharp.Server.Core.Services;

public sealed class RealmBuildInfo
{
    public RealmBuildInfo(int build, int major, int minor, int revision, char bugfix, ReadOnlyMemory<byte> winHash,
        ReadOnlyMemory<byte> macHash)
    {
        Build = build;
        Major = major;
        Minor = minor;
        Revision = revision;
        Bugfix = bugfix;
        WindowsHash = winHash;
        MacHash = macHash;
    }

    public int Build { get; }
    public int Revision { get; }
    public int Minor { get; }
    public int Major { get; }
    public char Bugfix { get; }
    public ReadOnlyMemory<byte> WindowsHash { get; }
    public ReadOnlyMemory<byte> MacHash { get; }
}