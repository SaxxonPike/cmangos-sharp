using System;
using System.IO;

namespace MangosSharp.Core;

/// <summary>
/// ObjectGuid is a special kind of 64-bit value that contains identity and type information in addition
/// to being unique within the game world.
/// </summary>
public readonly struct ObjectGuid
{
    public override string ToString() => _guid.ToString();

    public bool Equals(ObjectGuid other) => _guid == other._guid;

    public override bool Equals(object obj) => obj is ObjectGuid other && Equals(other);

    public override int GetHashCode() => _guid.GetHashCode();

    private readonly long _guid;

    public ObjectGuid() : this(0)
    {
    }

    public ObjectGuid(long guid) =>
        _guid = guid;

#pragma warning disable CS0675

    public ObjectGuid(HighGuid hi, int entry, long counter)
    {
        if (counter == 0)
        {
            _guid = 0;
            return;
        }
        
        if (WillHaveEntry(hi))
        {
            _guid = (counter & 0xFFFFFFL) | ((long)(entry & 0xFFFFFF) << 24) | ((long)hi << 48);
            return;
        }
        
        _guid = (counter & 0xFFFFFFFFL) | ((long)hi << 48);
    }

    public ObjectGuid(HighGuid hi, long counter) : this(hi, 0, counter)
    {
    }

#pragma warning restore CS0675

    public static implicit operator long(ObjectGuid g) => g._guid;

    public static implicit operator ObjectGuid(long v) => new(v);

    public static bool operator +(ObjectGuid g) => !g.IsEmpty;

    public static bool operator !(ObjectGuid g) => g.IsEmpty;

    public static bool operator ==(ObjectGuid a, ObjectGuid b) => a._guid == b._guid;

    public static bool operator !=(ObjectGuid a, ObjectGuid b) => a._guid != b._guid;

    public static bool operator <(ObjectGuid a, ObjectGuid b) => a._guid < b._guid;

    public static bool operator >(ObjectGuid a, ObjectGuid b) => a._guid > b._guid;

    public long GetRawValue() => _guid;

    public HighGuid High => (HighGuid)((_guid >> 48) & 0xFFFF);

    public int Entry => HasEntry ? (int)(_guid >> 24) & 0xFFFFFF : 0;

    public int Counter => HasEntry ? (int)(_guid & 0xFFFFFF) : unchecked((int)_guid);

    public static int GetMaxCounter(HighGuid high) => WillHaveEntry(high) ? 0xFFFFFF : -1;

    public int MaxCounter => GetMaxCounter(High);

    public bool IsEmpty => _guid == 0;

    public bool IsCreature => High == HighGuid.UNIT;

    public bool IsPet => High == HighGuid.PET;

    public bool IsCreatureOrPet => IsCreature || IsPet;

    public bool IsAnyTypeCreature => IsCreature || IsPet;

    public bool IsPlayer => _guid != 0 && High == HighGuid.PLAYER;

    public bool IsUnit => IsAnyTypeCreature || IsPlayer;

    public bool IsItem => High == HighGuid.ITEM;

    public bool IsGameObject => High == HighGuid.GAMEOBJECT;

    public bool IsDynamicObject => High == HighGuid.DYNAMICOBJECT;

    public bool IsCorpse => High == HighGuid.CORPSE;

    public bool IsTransport => High == HighGuid.TRANSPORT;

    public bool IsMoTransport => High == HighGuid.MO_TRANSPORT;

    public static TypeId GetTypeId(HighGuid high) =>
        high switch
        {
            HighGuid.ITEM => TypeId.ITEM,
            HighGuid.UNIT => TypeId.UNIT,
            HighGuid.PET => TypeId.UNIT,
            HighGuid.PLAYER => TypeId.PLAYER,
            HighGuid.GAMEOBJECT => TypeId.GAMEOBJECT,
            HighGuid.DYNAMICOBJECT => TypeId.DYNAMICOBJECT,
            HighGuid.CORPSE => TypeId.CORPSE,
            HighGuid.MO_TRANSPORT => TypeId.GAMEOBJECT,
            _ => TypeId.OBJECT
        };

    public TypeId TypeId => GetTypeId(High);

    public static bool WillHaveEntry(HighGuid high) =>
        high switch
        {
            HighGuid.ITEM => false,
            HighGuid.PLAYER => false,
            HighGuid.DYNAMICOBJECT => false,
            HighGuid.CORPSE => false,
            HighGuid.MO_TRANSPORT => false,
            HighGuid.GAMEOBJECT => true,
            HighGuid.TRANSPORT => true,
            HighGuid.UNIT => true,
            HighGuid.PET => true,
            _ => true
        };

    public bool HasEntry => WillHaveEntry(High);

    public static ReadOnlySpan<byte> Pack(ObjectGuid g)
    {
        var buffer = new byte[9];
        var total = 1;
        var temp = g._guid;
        for (var i = 0; i < 8; i++)
        {
            var b = unchecked((byte)temp);
            if (b != 0)
            {
                buffer[0] |= unchecked((byte)(1 << i));
                buffer[total] = b;
                ++total;
            }

            temp >>= 8;
        }

        return buffer.AsSpan(0, total);
    }

    public static void Pack(ObjectGuid g, Stream stream) => stream.Write(g.Pack());

    public ReadOnlySpan<byte> Pack() => Pack(this);

    public void Pack(Stream stream) => Pack(this, stream);

    public static ObjectGuid Unpack(ReadOnlySpan<byte> bytes)
    {
        var bits = bytes[0];
        var result = 0L;
        var idx = 1;
        for (var i = 0; i < 7; i++)
        {
            if ((bits & 1) != 0)
                result |= (long)bytes[idx++] << i;

            bits >>= 1;
        }

        return result;
    }

    public static ObjectGuid Unpack(Stream stream)
    {
        var buffer = new byte[9];
        buffer[0] = (byte)stream.ReadByte();
        stream.Read(buffer.AsSpan(1, buffer[0]));
        return Unpack(buffer.AsSpan(0, buffer[0] + 1));
    }
}