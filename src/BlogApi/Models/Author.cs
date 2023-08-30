namespace BlogApp_webapi.Models;

public class Author : User
{
    public Author(int id, string emailAddress, string username, string firstname, string lastName, string? password) :
    base(id, emailAddress, username, firstname, lastName, password)
    {
    }
    // public Photo ProfilePic {get; set;}
    public List<Post>? Posts { get; set; }
}

