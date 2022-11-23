using chat.Entity.Models;

namespace chat.Services.Models;

public class ChatModel : BaseModel
{
    public Guid Id { get; set; }
    public string Name {get;set;}
    public Guid Avatar{get;set;}
}