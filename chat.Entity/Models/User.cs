namespace chat.Entity.Models;
public class User : BaseEntity
{
    public string PasswordHash { get; set; }
    public string Login{get;set;}
    public string Name { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Ban { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<BlackList> ThatBanned { get; set; } // этот заблокирован
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<BlackList> ThemBanned { get; set; } // заблокированные этим
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Contact> ThatContacts { get; set; } // эти контакты
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Contact> ThemContacts { get; set; } // он контакт
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<ChatMember> ChatMembers { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Message> Messages { get; set; }
}