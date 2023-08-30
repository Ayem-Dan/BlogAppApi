using System;

namespace BlogApp_webapi.Dtos.User
{
    public class GetUserDto
    {
    public string EmailAddress { get; set; }
    public string Username { get; set; }
    // public Photo ProfilePic {get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsAuthor { get; set; }
    }
}
