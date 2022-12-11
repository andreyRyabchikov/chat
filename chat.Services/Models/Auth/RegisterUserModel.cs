using chat.Entity.Models;

namespace chat.Services.Models;

public class RegisterUserModel
{
    public string Password { get; set; }
    public string Name { get; set; }
    public string Login{get;set;}
}