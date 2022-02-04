using System;
using System.Collections.Generic;

namespace MangosSharp.Server.Core.Services;

public class BuildInfoService : IBuildInfoService
{
    public IReadOnlyDictionary<int, RealmBuildInfo> Builds { get; } =
        new Dictionary<int, RealmBuildInfo>
        {
            {
                13930,
                new RealmBuildInfo(13930, 3, 3, 5, 'a',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                12340,
                new RealmBuildInfo(12340, 3, 3, 5, 'a',
                    new byte[]
                    {
                        0xCD, 0xCB, 0xBD, 0x51, 0x88, 0x31, 0x5E, 0x6B, 0x4D, 0x19,
                        0x44, 0x9D, 0x49, 0x2D, 0xBC, 0xFA, 0xF1, 0x56, 0xA3, 0x47
                    },
                    new byte[]
                    {
                        0xB7, 0x06, 0xD1, 0x3F, 0xF2, 0xF4, 0x01, 0x88, 0x39, 0x72,
                        0x94, 0x61, 0xE3, 0xF8, 0xA0, 0xE2, 0xB5, 0xFD, 0xC0, 0x34
                    }
                )
            },
            {
                11723,
                new RealmBuildInfo(11723, 3, 3, 3, 'a',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                11403,
                new RealmBuildInfo(11403, 3, 3, 2, ' ',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                11159,
                new RealmBuildInfo(11159, 3, 3, 0, 'a',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                10505,
                new RealmBuildInfo(10505, 3, 2, 2, 'a',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                9947,
                new RealmBuildInfo(9947, 3, 1, 3, ' ',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                8606,
                new RealmBuildInfo(8606, 2, 4, 3, ' ',
                    new byte[]
                    {
                        0x31, 0x9A, 0xFA, 0xA3, 0xF2, 0x55, 0x96, 0x82, 0xF9, 0xFF,
                        0x65, 0x8B, 0xE0, 0x14, 0x56, 0x25, 0x5F, 0x45, 0x6F, 0xB1
                    },
                    new byte[]
                    {
                        0xD8, 0xB0, 0xEC, 0xFE, 0x53, 0x4B, 0xC1, 0x13, 0x1E, 0x19,
                        0xBA, 0xD1, 0xD4, 0xC0, 0xE8, 0x13, 0xEE, 0xE4, 0x99, 0x4F
                    }
                )
            },
            {
                6141,
                new RealmBuildInfo(6141, 1, 12, 3, ' ',
                    new byte[]
                    {
                        0xEB, 0x88, 0x24, 0x3E, 0x94, 0x26, 0xC9, 0xD6, 0x8C, 0x81,
                        0x87, 0xF7, 0xDA, 0xE2, 0x25, 0xEA, 0xF3, 0x88, 0xD8, 0xAF
                    },
                    Array.Empty<byte>()
                )
            },
            {
                6005,
                new RealmBuildInfo(6005, 1, 12, 2, ' ',
                    new byte[]
                    {
                        0x06, 0x97, 0x32, 0x38, 0x76, 0x56, 0x96, 0x41, 0x48, 0x79,
                        0x28, 0xFD, 0xC7, 0xC9, 0xE3, 0x3B, 0x44, 0x70, 0xC8, 0x80
                    },
                    Array.Empty<byte>()
                )
            },
            {
                5875,
                new RealmBuildInfo(5875, 1, 12, 1, ' ',
                    new byte[]
                    {
                        0x95, 0xED, 0xB2, 0x7C, 0x78, 0x23, 0xB3, 0x63, 0xCB, 0xDD,
                        0xAB, 0x56, 0xA3, 0x92, 0xE7, 0xCB, 0x73, 0xFC, 0xCA, 0x20
                    },
                    new byte[]
                    {
                        0x8D, 0x17, 0x3C, 0xC3, 0x81, 0x96, 0x1E, 0xEB, 0xAB, 0xF3,
                        0x36, 0xF5, 0xE6, 0x67, 0x5B, 0x10, 0x1B, 0xB5, 0x13, 0xE5
                    }
                )
            },
        };
}