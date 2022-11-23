using chat.Entity.Models;

namespace chat.Services.Models;

public class MessageModel : BaseModel
{ 
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime SendTime { get; set; }
    public virtual Guid IdChat { get; set; }
    public virtual Guid IdUser { get; set; }
}