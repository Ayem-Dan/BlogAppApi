using System;
using BlogApp_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp_webapi.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
