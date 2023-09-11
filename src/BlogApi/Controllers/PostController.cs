global using Microsoft.AspNetCore.Mvc;
using BlogApp_webapi.Models;
using BlogApp_webapi.Services.Dtos.Post;
using BlogApp_webapi.Services.PostService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace BlogApp_webapi.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("[Controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreatePost(CreatePostDto post)
    {
        var response = await _postService.CreatePost(post);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
       var response = await _postService.GetPostById(id);
        return Ok(response);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetPosts()
    {
       var response = await _postService.GetPosts();
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, UpdatePostDto updated)
    {
       var response = await _postService.UpdatePost(id, updated);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var response = await _postService.DeletePost(id);
        return Ok(response);
    }
}

