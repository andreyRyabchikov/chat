using chat.Entity.Models;

namespace chat.Services.Models;

public class UserModel : BaseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Ban { get; set; }
}