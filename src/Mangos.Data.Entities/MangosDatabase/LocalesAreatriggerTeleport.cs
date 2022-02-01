using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("locales_areatrigger_teleport")]
public class LocalesAreatriggerTeleport
{
    /* Entry of Areatrigger Teleport */
    [Column("Entry", TypeName="int")]
    public virtual uint Entry { get; set; }

    /* Text of the status_failed locale 1 */
    [Column("Text_loc1", TypeName="longtext")]
    public virtual string TextLoc1 { get; set; }

    /* Text of the status_failed locale 2 */
    [Column("Text_loc2", TypeName="longtext")]
    public virtual string TextLoc2 { get; set; }

    /* Text of the status_failed locale 3 */
    [Column("Text_loc3", TypeName="longtext")]
    public virtual string TextLoc3 { get; set; }

    /* Text of the status_failed locale 4 */
    [Column("Text_loc4", TypeName="longtext")]
    public virtual string TextLoc4 { get; set; }

    /* Text of the status_failed locale 5 */
    [Column("Text_loc5", TypeName="longtext")]
    public virtual string TextLoc5 { get; set; }

    /* Text of the status_failed locale 6 */
    [Column("Text_loc6", TypeName="longtext")]
    public virtual string TextLoc6 { get; set; }

    /* Text of the status_failed locale 7 */
    [Column("Text_loc7", TypeName="longtext")]
    public virtual string TextLoc7 { get; set; }

    /* Text of the status_failed locale 8 */
    [Column("Text_loc8", TypeName="longtext")]
    public virtual string TextLoc8 { get; set; }

}