namespace chat.Entity.Models;
public class ChatMember : BaseEntity
{
    public virtual Guid IdUser { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual User User { get; set; }
    public virtual Guid IdChat { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Chat Chat { get; set; }
}