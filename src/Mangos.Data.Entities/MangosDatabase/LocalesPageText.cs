using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("locales_page_text")]
public class LocalesPageText
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("Text_loc1", TypeName="longtext")]
    public virtual string TextLoc1 { get; set; }

    [Column("Text_loc2", TypeName="longtext")]
    public virtual string TextLoc2 { get; set; }

    [Column("Text_loc3", TypeName="longtext")]
    public virtual string TextLoc3 { get; set; }

    [Column("Text_loc4", TypeName="longtext")]
    public virtual string TextLoc4 { get; set; }

    [Column("Text_loc5", TypeName="longtext")]
    public virtual string TextLoc5 { get; set; }

    [Column("Text_loc6", TypeName="longtext")]
    public virtual string TextLoc6 { get; set; }

    [Column("Text_loc7", TypeName="longtext")]
    public virtual string TextLoc7 { get; set; }

    [Column("Text_loc8", TypeName="longtext")]
    public virtual string TextLoc8 { get; set; }

}