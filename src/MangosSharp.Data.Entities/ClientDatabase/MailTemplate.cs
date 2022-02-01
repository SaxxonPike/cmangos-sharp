namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("MailTemplate")]
public sealed class MailTemplate
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1, 8)]
    public string[] Subjects { get; set; }
    
    [DbcField(9)]
    public int Unknown9 { get; set; }
}