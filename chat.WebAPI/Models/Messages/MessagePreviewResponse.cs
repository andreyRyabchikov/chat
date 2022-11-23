namespace chat.WebAPI.Models;

public class MessagePreviewResponse
{
  public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime SendTime { get; set; }
}