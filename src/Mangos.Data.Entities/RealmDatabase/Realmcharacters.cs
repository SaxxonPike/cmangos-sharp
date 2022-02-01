using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("realmcharacters")]
public class Realmcharacters
{
    [Column("acctid", TypeName="bigint")]
    public virtual ulong Acctid { get; set; }

    [Column("numchars", TypeName="tinyint")]
    public virtual byte Numchars { get; set; }

    [Column("realmid", TypeName="int")]
    public virtual uint Realmid { get; set; }

}