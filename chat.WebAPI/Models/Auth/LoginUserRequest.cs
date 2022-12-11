namespace chat.WebAPI.Models;

public class LoginUserRequest : AuthUserRequest
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}