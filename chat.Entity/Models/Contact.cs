namespace chat.Entity.Models;
public class Contact : BaseEntity
{
    public DateTime AddTime { get; set; }
    public virtual Guid IdUser { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual User User { get; set; }
    public virtual Guid IdUserContact { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual User UserContact { get; set; }
}