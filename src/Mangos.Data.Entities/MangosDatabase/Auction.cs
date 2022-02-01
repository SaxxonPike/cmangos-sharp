using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("auction")]
public class Auction
{
    [Column("buyguid", TypeName="int")]
    public virtual uint Buyguid { get; set; }

    [Column("buyoutprice", TypeName="int")]
    public virtual int Buyoutprice { get; set; }

    [Column("deposit", TypeName="int")]
    public virtual int Deposit { get; set; }

    [Column("houseid", TypeName="int")]
    public virtual uint Houseid { get; set; }

    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("item_count", TypeName="int")]
    public virtual uint ItemCount { get; set; }

    [Column("item_randompropertyid", TypeName="int")]
    public virtual int ItemRandompropertyid { get; set; }

    /* Item Identifier */
    [Column("item_template", TypeName="int")]
    public virtual uint ItemTemplate { get; set; }

    [Column("itemguid", TypeName="int")]
    public virtual uint Itemguid { get; set; }

    [Column("itemowner", TypeName="int")]
    public virtual uint Itemowner { get; set; }

    [Column("lastbid", TypeName="int")]
    public virtual int Lastbid { get; set; }

    [Column("startbid", TypeName="int")]
    public virtual int Startbid { get; set; }

    [Column("time", TypeName="bigint")]
    public virtual ulong Time { get; set; }

}