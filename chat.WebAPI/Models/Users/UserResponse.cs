namespace chat.WebAPI.Models;

public class UserResponse
{
    public Guid id {get;set;}   
    public string Name { get; set; }
    public bool ban{get;set;}
    
    public DateTime RegistrationDate { get; set; }
    public DateTime BirthDate { get; set; }
}