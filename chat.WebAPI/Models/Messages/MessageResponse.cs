namespace chat.WebAPI.Models;

public class MessageResponse
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime SendTime { get; set; }
    public virtual Guid IdChat { get; set; }
    public virtual Guid IdUser { get; set; }
}