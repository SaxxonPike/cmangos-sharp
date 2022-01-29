using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace Mangos.Tool.ExtractSchema;

public sealed class App
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public App(IConfiguration configuration, ILogger logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public void Run(string[] args)
    {
        _logger.LogInformation("* DBContext code generator *");
        _logger.LogInformation("");
        _logger.LogInformation("This will auto-generate a code block that can be used");
        _logger.LogInformation("for DBContext in an effort to get Entity Framework going.");
        _logger.LogInformation("");
        _logger.LogInformation("This is NOT necessary to get your server running and is");
        _logger.LogInformation("only a code developer tool.");
        _logger.LogInformation("");

        if (args.Length < 4)
        {
            _logger.LogInformation("To begin, on the command line, specify the MySQL server.");
            _logger.LogInformation("");
            _logger.LogInformation("Mangos.Tool.ExtractSchema <host> <port> <user> <pass> [dbname] [dbname]");
            return;
        }

        var host = args[0];
        var port = int.Parse(args[1]);
        var user = args[2];
        var pass = args[3];

        _logger.LogInformation("Importing MySQL database from {}:{}", host, port);

        var connectionString = new MySqlConnectionStringBuilder
        {
            Server = host,
            Port = (uint)port,
            UserID = user,
            Password = pass
        }.ToString();

        var schemas = GetColumns(connectionString, args.Skip(4).ToArray())
            .GroupBy(ci => ci.TableSchema)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (var (schemaName, schemaInfos) in schemas)
        {
            using var output = File.Open($"{schemaName}.cs", FileMode.Create, FileAccess.Write);
            using var writer = new StreamWriter(output);
        
            writer.WriteLine("using System;");
            writer.WriteLine("using System.ComponentModel.DataAnnotations;");
            writer.WriteLine("using System.ComponentModel.DataAnnotations.Schema;");
            writer.WriteLine();
            writer.WriteLine("namespace Mangos.Entities;");
            writer.WriteLine();
            
            var tables = schemaInfos
                .GroupBy(ci => ci.TableName)
                .ToDictionary(g => g.Key, g => g.ToList());

            var pkeys = new Dictionary<string, List<string>>();

            foreach (var (tableName, tableInfos) in tables)
            {
                writer.WriteLine($"[Table(\"{tableName}\")]");
                writer.WriteLine($"public class {tableName}");
                writer.WriteLine('{');

                var forceKey = !tableInfos
                    .Where(ci => ci.ColumnName.Equals("id", StringComparison.OrdinalIgnoreCase))
                    .Any(ci => ci.ColumnKey.ToLowerInvariant().Split(' ').Contains("pri"));
                
                foreach (var column in tableInfos)
                {
                    var columnTypes = column.ColumnType.ToLowerInvariant().Split(' ');
                    var columnKeys = column.ColumnKey.ToLowerInvariant().Split(' ');
                    var unsigned = columnTypes.Contains("unsigned");

                    var type = column.DataType switch
                    {
                        "tinyint" => unsigned ? "uint" : "int",
                        "smallint" => unsigned ? "uint" : "int",
                        "mediumint" => unsigned ? "uint" : "int",
                        "int" => unsigned ? "uint" : "int",
                        "bigint" => unsigned ? "ulong" : "long",
                        "varchar" => "string",
                        "longtext" => "string",
                        "text" => "string",
                        "tinytext" => "string",
                        "timestamp" => "DateTimeOffset",
                        "bit" => "boolean",
                        "float" => "float",
                        "double" => "double",
                        "char" => "string",
                        "datetime" => "DateTimeOffset",
                        _ => throw new Exception($"Unsupported type {column.DataType}")
                    };

                    var name = column.ColumnName switch
                    {
                        "class" => "Class",
                        "event" => "Event",
                        _ => column.ColumnName
                    };
                    
                    if (!string.IsNullOrEmpty(column.ColumnComment))
                        writer.WriteLine($"    /* {column.ColumnComment} */");
                    if (forceKey || columnKeys.Contains("pri"))
                    {
                        if (!pkeys.ContainsKey(tableName))
                            pkeys[tableName] = new List<string>();
                        pkeys[tableName].Add(name);
                    }
                    writer.WriteLine($"    [Column(\"{column.ColumnName}\", TypeName=\"{column.DataType}\")]");
                    if (column.CharacterMaximumLength is > 0 and < int.MaxValue)
                        writer.WriteLine($"    [MaxLength({column.CharacterMaximumLength})]");
                    writer.Write($"    public virtual {type} {name} ");
                    writer.Write('{');
                    writer.Write(" get; set; ");
                    writer.Write('}');

                    writer.WriteLine();
                    writer.WriteLine();

                    forceKey = false;
                }
                
                writer.WriteLine('}');
            }
            
            writer.WriteLine($"public class {schemaName}_DbContext : DbContext");
            writer.WriteLine('{');
            writer.WriteLine($"    public {schemaName}_DbContext() {{}}");
            writer.WriteLine($"    public {schemaName}_DbContext(DbContextOptions options) : base(options) {{}}");
            writer.WriteLine($"    protected override void OnModelCreating(ModelBuilder builder)");
            writer.WriteLine("    {");

            foreach (var tableName in pkeys.Keys)
            {
                writer.Write($"        builder.Entity<{tableName}>().HasKey(e => new {{ ");
                writer.Write(string.Join(", ", pkeys[tableName].Select(pk => $"e.{pk}")));
                writer.WriteLine($" }});");
            }
            
            writer.WriteLine("    }");
            writer.WriteLine();

            foreach (var (tableName, _) in tables)
            {
                writer.WriteLine($"    public DbSet<{tableName}> {tableName}s {{ get; set; }}");
            }

            writer.WriteLine('}');
            
            writer.Flush();
            output.Flush();
        }
    }

    private static IEnumerable<ColumnInfo> GetColumns(string connectionString, string[] schemas)
    {
        using var connection = new MySqlConnection(connectionString);
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = "SELECT * FROM information_schema.COLUMNS;";
        using var adapter = new MySqlDataAdapter(command);
        var data = new DataSet();
        adapter.Fill(data);

        var result = new List<ColumnInfo>();
        foreach (var dt in data.Tables.Cast<DataTable>())
        {
            foreach (var row in dt.Rows.Cast<DataRow>())
            {
                var info = new ColumnInfo();
                
                foreach (var column in dt.Columns.Cast<DataColumn>())
                {
                    var cell = row[column];
                    
                    switch (column.ColumnName.ToLowerInvariant())
                    {
                        case "table_schema":
                            info.TableSchema = (string)cell;
                            if (info.TableSchema is "information_schema" or "sys")
                                info = null;
                            else if (!schemas.Contains(info.TableSchema.ToLowerInvariant()))
                                info = null;
                            break;
                        case "table_name":
                            info.TableName = (string)cell;
                            break;
                        case "column_name":
                            info.ColumnName = (string)cell;
                            break;
                        case "ordinal_position":
                            info.OrdinalPosition = long.Parse(cell.ToString());
                            break;
                        case "column_default":
                            info.ColumnDefault = cell == DBNull.Value ? null : (string)cell;
                            break;
                        case "is_nullable":
                            info.IsNullable = ((string)cell).Equals("yes", StringComparison.OrdinalIgnoreCase);
                            break;
                        case "data_type":
                            info.DataType = (string)cell;
                            break;
                        case "character_maximum_length":
                            info.CharacterMaximumLength = cell == DBNull.Value ? null : long.Parse(cell.ToString());
                            break;
                        case "column_type":
                            info.ColumnType = (string)cell;
                            break;
                        case "column_key":
                            info.ColumnKey = (string)cell;
                            break;
                        case "extra":
                            info.Extra = (string)cell;
                            break;
                        case "column_comment":
                            info.ColumnComment = (string)cell;
                            break;
                    }

                    if (info == null)
                        break;
                }

                if (info != null)
                    result.Add(info);
            }
        }

        return result;
    }
}