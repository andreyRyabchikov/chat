namespace chat.Entity.Models;

public class Chat : BaseEntity
{
    public string Name {get;set;}
    public Guid Avatar{get;set;}
    public virtual ICollection<ChatMember> ChatMembers { get; set; }
    public virtual ICollection<Message> Messages { get; set; }
}
