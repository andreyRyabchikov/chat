using chat.Entity.Models;

namespace chat.Services.Models;

public class UpdateAttachmentModel
{
    public string Name { get; set; }
    public Guid Type { get; set; }

}