using BlogApp_webapi.Models;
using BlogApp_webapi.Services.Dtos.Post;

namespace BlogApp_webapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreatePostDto, Post>();  // Mapping from CreatePostDto to Post
            CreateMap<Post, CreatePostDto>();
            CreateMap<GetPostDto, Post>();  // Mapping from GetPostDto to Post
            CreateMap<Post, GetPostDto>();
            CreateMap<UpdatePostDto, Post>();  // Mapping from UpdatePostDto to Post
            CreateMap<Post, UpdatePostDto>();
        }
    }
}
