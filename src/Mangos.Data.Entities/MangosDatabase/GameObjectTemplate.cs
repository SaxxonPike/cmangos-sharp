using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("gameobject_template")]
public class GameObjectTemplate
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("type", TypeName="tinyint")]
    public virtual byte Type { get; set; }

    [Column("displayId", TypeName="mediumint")]
    public virtual uint DisplayId { get; set; }

    [Column("name")]
    [MaxLength(100)]
    public virtual string Name { get; set; }

    [Column("faction", TypeName="smallint")]
    public virtual uint Faction { get; set; }

    [Column("flags", TypeName="int")]
    public virtual uint Flags { get; set; }

    [Column("ExtraFlags", TypeName="int")]
    public virtual uint ExtraFlags { get; set; }

    [Column("size", TypeName="float")]
    public virtual float Size { get; set; }

    [Column("data0", TypeName="int")]
    public virtual uint Data0 { get; set; }

    [Column("data1", TypeName="int")]
    public virtual int Data1 { get; set; }

    [Column("data2", TypeName="int")]
    public virtual uint Data2 { get; set; }

    [Column("data3", TypeName="int")]
    public virtual uint Data3 { get; set; }

    [Column("data4", TypeName="int")]
    public virtual uint Data4 { get; set; }

    [Column("data5", TypeName="int")]
    public virtual uint Data5 { get; set; }

    [Column("data6", TypeName="int")]
    public virtual int Data6 { get; set; }

    [Column("data7", TypeName="int")]
    public virtual uint Data7 { get; set; }

    [Column("data8", TypeName="int")]
    public virtual uint Data8 { get; set; }

    [Column("data9", TypeName="int")]
    public virtual uint Data9 { get; set; }

    [Column("data10", TypeName="int")]
    public virtual uint Data10 { get; set; }

    [Column("data11", TypeName="int")]
    public virtual uint Data11 { get; set; }

    [Column("data12", TypeName="int")]
    public virtual uint Data12 { get; set; }

    [Column("data13", TypeName="int")]
    public virtual uint Data13 { get; set; }

    [Column("data14", TypeName="int")]
    public virtual uint Data14 { get; set; }

    [Column("data15", TypeName="int")]
    public virtual uint Data15 { get; set; }

    [Column("data16", TypeName="int")]
    public virtual uint Data16 { get; set; }

    [Column("data17", TypeName="int")]
    public virtual uint Data17 { get; set; }

    [Column("data18", TypeName="int")]
    public virtual uint Data18 { get; set; }

    [Column("data19", TypeName="int")]
    public virtual uint Data19 { get; set; }

    [Column("data20", TypeName="int")]
    public virtual uint Data20 { get; set; }

    [Column("data21", TypeName="int")]
    public virtual uint Data21 { get; set; }

    [Column("data22", TypeName="int")]
    public virtual uint Data22 { get; set; }

    [Column("data23", TypeName="int")]
    public virtual uint Data23 { get; set; }

    [Column("CustomData1", TypeName="int")]
    public virtual uint CustomData1 { get; set; }

    [Column("mingold", TypeName="mediumint")]
    public virtual uint Mingold { get; set; }

    [Column("maxgold", TypeName="mediumint")]
    public virtual uint Maxgold { get; set; }

    [Column("ScriptName")]
    [MaxLength(64)]
    public virtual string ScriptName { get; set; }

}