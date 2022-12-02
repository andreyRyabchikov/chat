namespace chat.Entity.Models;
public class Contact : BaseEntity
{
    public DateTime AddTime { get; set; }
    public virtual Guid IdUser { get; set; }

    public virtual User User { get; set; }
    public virtual Guid IdUserContact { get; set; }

    public virtual User UserContact { get; set; }
}