namespace chat.Entity.Models;
public class Message : BaseEntity
{
    public string Text { get; set; }
    public DateTime SendTime { get; set; }
    public virtual ICollection<Attachment> Attachments { get; set; }
    public virtual Guid IdChat { get; set; }
       [System.Text.Json.Serialization.JsonIgnore]
    public virtual Chat Chat { get; set; }
    public virtual Guid IdUser { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual User User { get; set; }
}