using System;
using BlogApp_webapi.Models;
using BlogApp_webapi.Services.Dtos.Post;

namespace BlogApp_webapi.Services.PostService
{
    public interface IPostService
    {
        Task<ServiceResponse<CreatePostDto>> CreatePost(CreatePostDto createPost);
        Task<ServiceResponse<GetPostDto>> GetPostById(int id);
        Task<ServiceResponse<List<GetPostDto>>> GetPosts();
        Task<ServiceResponse<UpdatePostDto>> UpdatePost(int id, UpdatePostDto updatedPost);
        Task<ServiceResponse<Post>> DeletePost(int? Id);

    }

    
}
