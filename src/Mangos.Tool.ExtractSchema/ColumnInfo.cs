namespace Mangos.Tool.ExtractSchema;

public sealed class ColumnInfo
{
    public string TableSchema;
    public string TableName;
    public string ColumnName;
    public long OrdinalPosition;
    public string ColumnDefault;
    public bool IsNullable;
    public string DataType;
    public long? CharacterMaximumLength;
    public string ColumnType;
    public string ColumnKey;
    public string Extra;
    public string ColumnComment;
}