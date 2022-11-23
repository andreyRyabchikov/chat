using chat.Entity.Models;

namespace chat.Services.Models;

public class ContactModel : BaseModel
{
     public DateTime AddTime { get; set; }
    public virtual Guid IdUser { get; set; }
    public virtual Guid IdUserContact { get; set; }
}