using chat.Entity.Models;

namespace chat.Services.Models;

public class UpdateMessageModel
{
    public string Text { get; set; }
    public DateTime SendTime { get; set; }

}