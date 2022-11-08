namespace chat.Entity.Models;
public class ChatMember : BaseEntity
{
    public virtual Guid IdUser { get; set; }
    public virtual User User { get; set; }
    public virtual Guid IdChat { get; set; }
    public virtual Chat Chat { get; set; }
}