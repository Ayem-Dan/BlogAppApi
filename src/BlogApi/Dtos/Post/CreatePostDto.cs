using System;

namespace BlogApp_webapi.Services.Dtos.Post;

    public class CreatePostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AuthorId { get; set; }

    }
