using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("locales_gossip_menu_option")]
public class LocalesGossipMenuOption
{
    [Column("box_text_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string BoxTextLoc1 { get; set; }

    [Column("box_text_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string BoxTextLoc2 { get; set; }

    [Column("box_text_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string BoxTextLoc3 { get; set; }

    [Column("box_text_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string BoxTextLoc4 { get; set; }

    [Column("box_text_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string BoxTextLoc5 { get; set; }

    [Column("box_text_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string BoxTextLoc6 { get; set; }

    [Column("box_text_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string BoxTextLoc7 { get; set; }

    [Column("box_text_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string BoxTextLoc8 { get; set; }

    [Column("id", TypeName="smallint")]
    public virtual ushort Id { get; set; }

    [Column("menu_id", TypeName="smallint")]
    public virtual ushort MenuId { get; set; }

    [Column("option_text_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OptionTextLoc1 { get; set; }

    [Column("option_text_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OptionTextLoc2 { get; set; }

    [Column("option_text_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OptionTextLoc3 { get; set; }

    [Column("option_text_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OptionTextLoc4 { get; set; }

    [Column("option_text_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OptionTextLoc5 { get; set; }

    [Column("option_text_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OptionTextLoc6 { get; set; }

    [Column("option_text_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OptionTextLoc7 { get; set; }

    [Column("option_text_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OptionTextLoc8 { get; set; }

}