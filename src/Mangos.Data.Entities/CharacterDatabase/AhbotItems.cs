using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("ahbot_items")]
public class AhbotItems
{
    /* Chance item is added to AH upon bot visit, 0 for normal loot sources */
    [Column("add_chance", TypeName="int")]
    public virtual uint AddChance { get; set; }

    /* Item Identifier */
    [Column("item", TypeName="int")]
    public virtual uint Item { get; set; }

    /* Max amount added, not used when add_chance is 0 */
    [Column("max_amount", TypeName="int")]
    public virtual uint MaxAmount { get; set; }

    /* Min amount added, not used when add_chance is 0 */
    [Column("min_amount", TypeName="int")]
    public virtual uint MinAmount { get; set; }

    /* Item value, a value of 0 bans item from being sold/bought by AHBot */
    [Column("value", TypeName="int")]
    public virtual uint Value { get; set; }

}