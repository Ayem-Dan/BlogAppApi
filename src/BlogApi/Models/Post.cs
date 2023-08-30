using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApp_webapi.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int AuthorId { get; set; }
        // public Photo Photo {get; set;}
        // public List<Category> Category {get; set;}
        public List<Comment> Comments { get; set; } = new List<Comment>();

        private Post()
        {

        }
        public Post(int id, string title, string content, DateTime createdAt, DateTime modifiedAt, int authorId)
        {
            Id = id;
            Title = title;
            Content = content;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            AuthorId = authorId;
            Comments = new List<Comment>();
        }
    }
}
