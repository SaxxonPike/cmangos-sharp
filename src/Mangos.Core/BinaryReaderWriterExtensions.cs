using System.IO;
using System.Text;

namespace Mangos.Core;

public static class BinaryReaderWriterExtensions
{
    public static string ReadNullTerminatedString(this BinaryReader reader)
    {
        using var data = new MemoryStream();
        while (true)
        {
            var b = reader.ReadByte();
            if (b == 0)
                return Encoding.UTF8.GetString(data.AsSpan());
            data.WriteByte(b);
        }
    }

    public static long ReadPackedGuid(this BinaryReader reader)
    {
        var bits = reader.ReadByte();
        var result = 0L;
        for (var i = 0; i < 7; i++)
        {
            if ((bits & 1) != 0)
                result |= (long)reader.ReadByte() << i;

            bits >>= 1;
        }

        return result;
    }

    public static void WriteNullTerminatedString(this BinaryWriter writer, string value)
    {
        writer.Write(Encoding.UTF8.GetBytes(value));
        writer.Write((byte)0);
    }

    public static void WritePackedGuid(this BinaryWriter writer, long guid)
    {
        byte bits = 0;
        var temp = guid;
        for (var i = 0; i < 7; i++)
        {
            var b = unchecked((byte)temp);
            if (b != 0)
                bits |= unchecked((byte)(1 << i));
            temp >>= 8;
        }

        temp = guid;
        writer.Write(bits);
        for (var i = 0; i < 7; i++)
        {
            var b = unchecked((byte)temp);
            if (b != 0)
                writer.Write(b);
            temp >>= 8;
        }
    }
}