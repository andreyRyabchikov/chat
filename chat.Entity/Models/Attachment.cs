namespace chat.Entity.Models;
public class Attachment : BaseEntity
{
    public string Name { get; set; }
    public Guid Type { get; set; }

    public virtual Guid IdMessage { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Message Message { get; set; }
}