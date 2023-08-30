using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApp_webapi.Models;

    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set;}
    }
