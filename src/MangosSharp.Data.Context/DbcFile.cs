using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using MangosSharp.Data.Entities;

namespace MangosSharp.Data.Context;

public sealed class DbcFile
{
    public DbcFile(Stream stream)
    {
        var reader = new BinaryReader(stream);

        if (reader.ReadInt32() != 0x43424457)
        {
            throw new Exception("Could not read header in DBCFile.");
        }

        RecordCount = reader.ReadInt32();
        FieldCount = reader.ReadInt32();
        RecordSize = reader.ReadInt32();
        var stringSize = reader.ReadInt32();

        // if (FieldCount * 4 != RecordSize)
        // {
        //     throw new Exception("Field count and record size in DBCFile do not match.");
        // }

        Data = reader.ReadBytes(RecordSize * RecordCount);
        Strings = reader.ReadBytes(stringSize);
        Records = Enumerable.Range(0, RecordCount)
            .Where(i => Data.Length - (i * RecordSize) >= RecordSize)  // make sure only whole records are processed
            .Select(i => new Record(Data.Slice(i * RecordSize, RecordSize), Strings))
            .ToList();
    }

    private ReadOnlyMemory<byte> Strings { get; }
    private ReadOnlyMemory<byte> Data { get; }
    private int RecordSize { get; }
    private int RecordCount { get; }
    public int FieldCount { get; }
    public IReadOnlyList<Record> Records { get; }

    public sealed class Record
    {
        private readonly ReadOnlyMemory<byte> _record;
        private readonly ReadOnlyMemory<byte> _strings;

        public Record(ReadOnlyMemory<byte> record, ReadOnlyMemory<byte> strings)
        {
            _record = record;
            _strings = strings;
        }

        public float GetFloat(int field) => 
            field < _record.Span.Length / 4 ? MemoryMarshal.Cast<byte, float>(_record.Span)[field] : default;

        public uint GetUInt(int field) => 
            field < _record.Span.Length / 4 ? MemoryMarshal.Cast<byte, uint>(_record.Span)[field] : default;

        public int GetInt(int field) => 
            field < _record.Span.Length / 4 ? MemoryMarshal.Cast<byte, int>(_record.Span)[field] : default;

        public byte GetByte(int field, int offset) => 
            field < _record.Span.Length + offset ? _record.Span[field * 4 + offset] : default;

        public byte[] GetBytes(int field, int offset, int length) => 
            field < _record.Span.Length + offset + length 
                ? _record.Span.Slice(field * 4 + offset, length).ToArray() 
                : default;

        public string GetString(int field)
        {
            if (field >= _record.Length / 4)
                return null;
            var recSpan = _record.Span;
            var stringOffs = MemoryMarshal.Cast<byte, int>(recSpan)[field];
            if (stringOffs >= _strings.Length)
                return null;
            
            var str = _strings.Span[stringOffs..];
            var len = 0;
            while (str[len] != 0)
            {
                len++;
            }

            return Encoding.ASCII.GetString(str[..len]);
        }
    }

    private List<KeyValuePair<int, TEntity>> ToEntities<TEntity>(bool excludeClientOnlyFields)
    {
        var constructor = typeof(TEntity).GetConstructor(Array.Empty<Type>());
        if (constructor == default)
            throw new Exception($"No parameterless constructor found. type={typeof(TEntity)}");

        var getters = new Dictionary<MemberInfo, Func<Record, object>>();
        var setters = new Dictionary<MemberInfo, Action<object, object>>();
        var members = new List<MemberInfo>();

        foreach (var member in typeof(TEntity).GetMembers(BindingFlags.Public | BindingFlags.Instance |
                                                          BindingFlags.NonPublic))
        {
            var fieldAttr = member.GetCustomAttribute<DbcFieldAttribute>(true);
            if (fieldAttr == default)
                continue;
            var index = fieldAttr.Index;
            if (index >= FieldCount || index < 0)
                continue;
            if (fieldAttr.ClientOnly && excludeClientOnlyFields)
                continue;
            
            Action<object, object> setter;

            Type memberType;
            switch (member)
            {
                case PropertyInfo property:
                    setter = property.SetValue;
                    memberType = property.PropertyType;
                    break;
                case FieldInfo field:
                    setter = field.SetValue;
                    memberType = field.FieldType;
                    break;
                default:
                    // unsupported
                    continue;
            }

            if (memberType == typeof(int))
                getters.Add(member, r => r.GetInt(index));
            else if (memberType == typeof(string))
                getters.Add(member, r => r.GetString(index));
            else if (memberType == typeof(float))
                getters.Add(member, r => r.GetFloat(index));
            else if (memberType == typeof(uint))
                getters.Add(member, r => r.GetUInt(index));
            else if (memberType == typeof(byte))
                getters.Add(member, r => r.GetByte(index, fieldAttr.Offset));
            else if (memberType == typeof(bool))
                getters.Add(member, r => r.GetInt(index) != 0);
            else if (memberType == typeof(int[]))
                getters.Add(member, r => Enumerable.Range(index, fieldAttr.Length).Select(r.GetInt).ToArray());
            else if (memberType == typeof(byte[]))
                getters.Add(member, r => r.GetBytes(index, fieldAttr.Offset, fieldAttr.Length));
            else if (memberType == typeof(string[]))
                getters.Add(member, r => Enumerable.Range(index, fieldAttr.Length).Select(r.GetString).ToArray());
            else
                continue;

            setters.Add(member, setter);
            members.Add(member);
        }

        var result = new List<KeyValuePair<int, TEntity>>();
        foreach (var record in Records)
        {
            var entity = (TEntity)constructor.Invoke(Array.Empty<object>());
            foreach (var member in members)
                setters[member](entity, getters[member](record));
            result.Add(new KeyValuePair<int, TEntity>(record.GetInt(0), entity));
        }

        return result;
    }

    public Dictionary<int, TEntity> ToDictionary<TEntity>(bool excludeClientOnlyFields = false) =>
        ToEntities<TEntity>(excludeClientOnlyFields).ToDictionary(kv => kv.Key, kv => kv.Value);

    public List<TEntity> ToList<TEntity>(bool excludeClientOnlyFields = false) =>
        ToEntities<TEntity>(excludeClientOnlyFields).Select(kv => kv.Value).ToList();
}