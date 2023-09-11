using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlogApp_webapi.Dtos.Auth;
using BlogApp_webapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BlogApp_webapi.Controllers;

[ApiController]
[Route("[Controller]")]
public class AuthController : ControllerBase
{
    // public static User user = new User();
private readonly UserManager<IdentityUser> _userManager;
private readonly IConfiguration _configuration; 

public AuthController( UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        // _jwtConfig = jwtConfig;
        _configuration = configuration;
    }



[HttpPost("register")]
public async Task<IActionResult> Register([FromBody] RegisterDto req)
{   
    if(ModelState.IsValid)
    {
        var user_exists = await _userManager.FindByEmailAsync(req.EmailAddress);

        if(user_exists != null)
            return Conflict(new ServiceResponse<string>()
            {
                Success = false,
                Message = "User already exists"
            });
    }

    var user = new IdentityUser()
    {
        Email = req.EmailAddress,
        UserName = req.Username
    };

    var is_created =  await _userManager.CreateAsync(user, req.Password);

    if(is_created.Succeeded)
    {
        var token = GenerateJwtToken(user);

        return Ok(new ServiceResponse<string>()
        {
            Success = true,
            Data = token,
            Message = "User successfully Created"
        });
    }

    return BadRequest(new ServiceResponse<string>()
        {
            Success = false,
            Message = "Registeration Failed"
        });
}

[HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginDto req)
{   
    if(ModelState.IsValid)
    {
        var existing_user = await _userManager.FindByEmailAsync(req.EmailAddress);
        if(existing_user == null)
        {
            return BadRequest(new ServiceResponse<string>
            {
                Success = false,
                Message = "Invalid Credentials"
            });
        }
        var isCorrect = await _userManager.CheckPasswordAsync(existing_user, req.Password);
        
        if(!isCorrect)
        {
            return BadRequest(new ServiceResponse<string>
            {   
                Success = false,
                Message = "Invalid Credentials"
            });
        }
        var jwtToken = GenerateJwtToken(existing_user);
        return Ok(new ServiceResponse<string>
        {   Data = jwtToken,
            Success = true,
            Message = "Login Successful"
        });
    }

 
    return BadRequest( new ServiceResponse<string>
    {
        Success = false,
        Message = "Invalid input"
    }
        );
}

private string GenerateJwtToken(IdentityUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_configuration.GetSection(key: "JwtConfig:Secret").Value);

        // Token Descriptor
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
            }),
            Expires = DateTime.Now.AddHours(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);

        return jwtToken;

    }
}

