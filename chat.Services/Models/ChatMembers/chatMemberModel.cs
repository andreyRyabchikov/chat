using chat.Entity.Models;

namespace chat.Services.Models;

public class ChatMemberModel : BaseModel
{
    public virtual Guid IdUser { get; set; }
    public virtual Guid IdChat { get; set; }
}
