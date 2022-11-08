namespace chat.Entity.Models;
public class BlackList : BaseEntity
{
    public DateTime AddTime { get; set; }
    public virtual Guid IdUser { get; set; }
    public virtual User User { get; set; }
    public virtual Guid IdUserBlocked { get; set; }
    public virtual User UserBlocked { get; set; }
}