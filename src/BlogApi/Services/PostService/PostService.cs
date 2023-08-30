using BlogApp_webapi.Data;
using BlogApp_webapi.Models;
using BlogApp_webapi.Services.Dtos.Post;
using Microsoft.EntityFrameworkCore;

namespace BlogApp_webapi.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly BlogContext _dbContext;
        private readonly IMapper _mapper;
        public PostService(BlogContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CreatePostDto>> CreatePost(CreatePostDto post)
        {
            var serviceResponse = new ServiceResponse<CreatePostDto>();
            var postDto = _mapper.Map<Post>(post);
            _dbContext.Posts.Add(postDto);
            await _dbContext.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<CreatePostDto>(postDto);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPostDto>> GetPostById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPostDto>();
            var post = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
            serviceResponse.Data = _mapper.Map<GetPostDto>(post);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetPostDto>>> GetPosts()
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            var posts = await _dbContext.Posts.ToListAsync();
            serviceResponse.Data = _mapper.Map<List<GetPostDto>>(posts);
            return serviceResponse;
        }

        public async Task<ServiceResponse<UpdatePostDto>> UpdatePost(int id, UpdatePostDto updatedPost)
        {
            var serviceResponse = new ServiceResponse<UpdatePostDto>();
            var post = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
            
            if (post == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Post not found.";
                return serviceResponse;
            }
            
            // Update post properties from updatedPost DTO
            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;
            post.ModifiedAt = DateTime.UtcNow;;
            
            _dbContext.Posts.Update(post);
            await _dbContext.SaveChangesAsync();
            
            serviceResponse.Data = _mapper.Map<UpdatePostDto>(post);
            return serviceResponse;
        }

        public async Task<ServiceResponse<Post>> DeletePost(int? id)
        {
            var serviceResponse = new ServiceResponse<Post>();
            var post = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
            
            if (post == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Post not found.";
            }

            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
            return serviceResponse;
        }


    }
}
