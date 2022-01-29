using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("broadcast_text")]
public class BroadcastText
{
    /* Identifier */
    [Column("Id", TypeName="int")]
    public virtual int Id { get; set; }

    /* Male text */
    [Column("Text", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Text { get; set; }

    /* Female text */
    [Column("Text1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Text1 { get; set; }

    [Column("ChatTypeID", TypeName="int")]
    public virtual int ChatTypeId { get; set; }

    /* Language of text */
    [Column("LanguageID", TypeName="int")]
    public virtual int LanguageId { get; set; }

    /* Unk */
    [Column("ConditionID", TypeName="int")]
    public virtual int ConditionId { get; set; }

    /* Unk */
    [Column("EmotesID", TypeName="int")]
    public virtual int EmotesId { get; set; }

    /* Unk */
    [Column("Flags", TypeName="int")]
    public virtual int Flags { get; set; }

    /* Sound on broadcast */
    [Column("SoundEntriesID1", TypeName="int")]
    public virtual int SoundEntriesId1 { get; set; }

    /* Sound on broadcast */
    [Column("SoundEntriesID2", TypeName="int")]
    public virtual int SoundEntriesId2 { get; set; }

    /* Emote on gossip */
    [Column("EmoteID1", TypeName="int")]
    public virtual int EmoteId1 { get; set; }

    /* Emote on gossip */
    [Column("EmoteID2", TypeName="int")]
    public virtual int EmoteId2 { get; set; }

    /* Emote on gossip */
    [Column("EmoteID3", TypeName="int")]
    public virtual int EmoteId3 { get; set; }

    /* Emote delay on gossip */
    [Column("EmoteDelay1", TypeName="int")]
    public virtual int EmoteDelay1 { get; set; }

    /* Emote delay on gossip */
    [Column("EmoteDelay2", TypeName="int")]
    public virtual int EmoteDelay2 { get; set; }

    /* Emote delay on gossip */
    [Column("EmoteDelay3", TypeName="int")]
    public virtual int EmoteDelay3 { get; set; }

    /* Build of bruteforce */
    [Column("VerifiedBuild", TypeName="int")]
    public virtual int VerifiedBuild { get; set; }

}