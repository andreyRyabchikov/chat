namespace chat.Entity.Models;

public class Chat : BaseEntity
{
    public string Name {get;set;}
    public Guid Avatar{get;set;}
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<ChatMember> ChatMembers { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Message> Messages { get; set; }
}
