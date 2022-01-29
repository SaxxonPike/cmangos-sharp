using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("realmlist")]
public class RealmList
{
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("name", TypeName="varchar")]
    [MaxLength(32)]
    public virtual string Name { get; set; }

    [Column("address", TypeName="varchar")]
    [MaxLength(32)]
    public virtual string Address { get; set; }

    [Column("port", TypeName="int")]
    public virtual int Port { get; set; }

    [Column("icon", TypeName="tinyint")]
    public virtual byte Icon { get; set; }

    /* Supported masks: 0x1 (invalid, not show in realm list), 0x2 (offline, set by mangosd), 0x4 (show version and build), 0x20 (new players), 0x40 (recommended) */
    [Column("realmflags", TypeName="tinyint")]
    public virtual byte Realmflags { get; set; }

    [Column("timezone", TypeName="tinyint")]
    public virtual byte Timezone { get; set; }

    [Column("allowedSecurityLevel", TypeName="tinyint")]
    public virtual byte AllowedSecurityLevel { get; set; }

    [Column("population", TypeName="float")]
    public virtual float Population { get; set; }

    [Column("realmbuilds", TypeName="varchar")]
    [MaxLength(64)]
    public virtual string Realmbuilds { get; set; }

}