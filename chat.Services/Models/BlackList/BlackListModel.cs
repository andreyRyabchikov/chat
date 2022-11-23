using chat.Entity.Models;

namespace chat.Services.Models;

public class BlackListModel : BaseModel
{
     public DateTime AddTime { get; set; }
    public virtual Guid IdUser { get; set; }
    public virtual Guid IdUserBlocked { get; set; }
}