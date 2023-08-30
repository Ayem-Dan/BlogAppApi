using System;

namespace BlogApp_webapi.Services.Dtos.Post;

    public class GetPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
