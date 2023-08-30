using System;

namespace BlogApp_webapi.Services.Dtos.Post;

    public class UpdatePostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ModifiedAt { get; set; }
        
    }

