using System;

namespace BlogApp_webapi.Dtos.Auth;

public class RegisterDto
{
    public string EmailAddress { get; set; }
    public string Username { get; set; }
    // public Photo ProfilePic {get; set;}
    public string Password { get; set; }
}


