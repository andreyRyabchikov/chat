namespace chat.Entity.Models;
public class BlackList : BaseEntity
{
    public DateTime AddTime { get; set; }
    public virtual Guid IdUser { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual User User { get; set; }
    public virtual Guid IdUserBlocked { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual User UserBlocked { get; set; }
}