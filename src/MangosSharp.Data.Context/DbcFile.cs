using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using MangosSharp.Data.Entities;

namespace MangosSharp.Data.Context;

/// <summary>
/// Reads and deserializes DBC tables.
/// </summary>
public sealed class DbcFile
{
    /// <summary>
    /// Read all records from a DBC table.
    /// </summary>
    /// <param name="stream">Stream containing the DBC table data.</param>
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

    /// <summary>
    /// Holds the raw strings block of a DBC file.
    /// </summary>
    private ReadOnlyMemory<byte> Strings { get; }
    
    /// <summary>
    /// Holds the raw data field block of a DBC file.
    /// </summary>
    private ReadOnlyMemory<byte> Data { get; }
    
    /// <summary>
    /// Number of bytes per record, as reported by the DBC header.
    /// </summary>
    private int RecordSize { get; }
    
    /// <summary>
    /// Number of records in the DBC table, as reported by the header.
    /// </summary>
    private int RecordCount { get; }
    
    /// <summary>
    /// Number of fields per record, as reported by the DBC header.
    /// </summary>
    public int FieldCount { get; }
    
    /// <summary>
    /// All records that were read from the table.
    /// </summary>
    public IReadOnlyList<Record> Records { get; }

    /// <summary>
    /// Encapsulates a single record within a DBC table.
    /// </summary>
    public sealed class Record
    {
        private readonly ReadOnlyMemory<byte> _record;
        private readonly ReadOnlyMemory<byte> _strings;

        internal Record(ReadOnlyMemory<byte> record, ReadOnlyMemory<byte> strings)
        {
            _record = record;
            _strings = strings;
        }

        /// <summary>
        /// Get a float value from the record.
        /// </summary>
        /// <param name="field">Index of the field to deserialize.</param>
        public float GetFloat(int field) => 
            field < _record.Span.Length / 4 ? MemoryMarshal.Cast<byte, float>(_record.Span)[field] : default;

        /// <summary>
        /// Get an unsigned 32-bit value from the record.
        /// </summary>
        /// <param name="field">Index of the field to deserialize.</param>
        public uint GetUInt(int field) => 
            field < _record.Span.Length / 4 ? MemoryMarshal.Cast<byte, uint>(_record.Span)[field] : default;

        /// <summary>
        /// Get a signed 32-bit value from the record.
        /// </summary>
        /// <param name="field">Index of the field to deserialize.</param>
        public int GetInt(int field) => 
            field < _record.Span.Length / 4 ? MemoryMarshal.Cast<byte, int>(_record.Span)[field] : default;

        /// <summary>
        /// Get an unsigned 8-bit value from the record.
        /// </summary>
        /// <param name="field">Index of the field to deserialize.</param>
        public byte GetByte(int field, int offset) => 
            field < _record.Span.Length + offset ? _record.Span[field * 4 + offset] : default;

        /// <summary>
        /// Get a sequential segment of unsigned 8-bit values from the record.
        /// </summary>
        /// <param name="field">Index of the field to deserialize.</param>
        public byte[] GetBytes(int field, int offset, int length) => 
            field < _record.Span.Length + offset + length 
                ? _record.Span.Slice(field * 4 + offset, length).ToArray() 
                : default;

        /// <summary>
        /// Get a UTF8 string from the record. The string data comes from the string block at the end of the DBC file.
        /// </summary>
        /// <param name="field">Index of the field to deserialize.</param>
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

    /// <summary>
    /// Converts the table to a strongly typed list of objects.
    /// </summary>
    /// <param name="excludeClientOnlyFields">If true, values will not be read for fields marked client-only.</param>
    /// <typeparam name="TEntity">Type representing a deserialized record in this TBC table.</typeparam>
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

    /// <summary>
    /// Converts the table to a strongly typed dictionary. Field index 0 is used as the primary key.
    /// </summary>
    /// <param name="excludeClientOnlyFields">If true, values will not be read for fields marked client-only.</param>
    /// <typeparam name="TEntity">Type representing a deserialized record in this TBC table.</typeparam>
    public Dictionary<int, TEntity> ToDictionary<TEntity>(bool excludeClientOnlyFields = false) =>
        ToEntities<TEntity>(excludeClientOnlyFields).ToDictionary(kv => kv.Key, kv => kv.Value);

    /// <summary>
    /// Converts the table to a strongly typed list.
    /// </summary>
    /// <param name="excludeClientOnlyFields">If true, values will not be read for fields marked client-only.</param>
    /// <typeparam name="TEntity">Type representing a deserialized record in this TBC table.</typeparam>
    public List<TEntity> ToList<TEntity>(bool excludeClientOnlyFields = false) =>
        ToEntities<TEntity>(excludeClientOnlyFields).Select(kv => kv.Value).ToList();
}