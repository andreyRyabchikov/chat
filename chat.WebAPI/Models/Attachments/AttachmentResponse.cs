namespace chat.WebAPI.Models;

public class AttachmentResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid Type { get; set; }
    public virtual Guid IdMessage { get; set; }
}