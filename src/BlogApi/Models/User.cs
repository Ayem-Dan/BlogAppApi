using System.ComponentModel.DataAnnotations;

namespace BlogApp_webapi.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }
    public string Username { get; set; }
    // public Photo ProfilePic {get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsAuthor { get; set; }
    public DateTime CreatedAt { get; set; }

    [Required]
    [MinLength(6)]
    public string? PasswordHash { get; set; }

    private User()
    {

    }

    public User(int id, string emailAddress, string username, string firstname, string lastName, string? password)
    {
        Id = id;
        EmailAddress = emailAddress;
        Username = username;
        FirstName = firstname;
        LastName = lastName;

        if (!string.IsNullOrEmpty(password))
            PasswordHash = HashPlainText(password);


    }
    public bool DoesPasswordMatch(string password) => BCrypt.Net.BCrypt.Verify(password, PasswordHash);
    private static string HashPlainText(string value) => BCrypt.Net.BCrypt.HashPassword(value);
}

