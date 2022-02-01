using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("gossip_menu_option")]
public class GossipMenuOption
{
    [Column("action_menu_id", TypeName="mediumint")]
    public virtual int ActionMenuId { get; set; }

    [Column("action_poi_id", TypeName="mediumint")]
    public virtual uint ActionPoiId { get; set; }

    [Column("action_script_id", TypeName="mediumint")]
    public virtual uint ActionScriptId { get; set; }

    [Column("box_broadcast_text", TypeName="int")]
    public virtual int BoxBroadcastText { get; set; }

    [Column("box_coded", TypeName="tinyint")]
    public virtual byte BoxCoded { get; set; }

    [Column("box_money", TypeName="int")]
    public virtual uint BoxMoney { get; set; }

    [Column("box_text", TypeName="text")]
    [MaxLength(65535)]
    public virtual string BoxText { get; set; }

    [Column("condition_id", TypeName="mediumint")]
    public virtual uint ConditionId { get; set; }

    [Column("id", TypeName="smallint")]
    public virtual ushort Id { get; set; }

    [Column("menu_id", TypeName="smallint")]
    public virtual ushort MenuId { get; set; }

    [Column("npc_option_npcflag", TypeName="int")]
    public virtual uint NpcOptionNpcflag { get; set; }

    [Column("option_broadcast_text", TypeName="int")]
    public virtual int OptionBroadcastText { get; set; }

    [Column("option_icon", TypeName="mediumint")]
    public virtual uint OptionIcon { get; set; }

    [Column("option_id", TypeName="tinyint")]
    public virtual byte OptionId { get; set; }

    [Column("option_text", TypeName="text")]
    [MaxLength(65535)]
    public virtual string OptionText { get; set; }

}