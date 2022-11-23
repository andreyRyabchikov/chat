namespace chat.Services.Models;

public class MessagePreviewModel
{  
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime SendTime { get; set; }
}