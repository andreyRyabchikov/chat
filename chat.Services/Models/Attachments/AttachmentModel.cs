using chat.Entity.Models;

namespace chat.Services.Models;

public class AttachmentModel : BaseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid Type { get; set; }
    public virtual Guid IdMessage { get; set; }
}