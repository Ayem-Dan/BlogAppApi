using System;
using BlogApp_webapi.Dtos.User;
using BlogApp_webapi.Models;

namespace BlogApp_webapi.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<CreateUserDto>> Register(CreateUserDto userDto);
        Task<ServiceResponse<GetUserDto>> GetUserById(int id);
        Task<ServiceResponse<UpdateUserDto>> UpdateUserInformation(int id, UpdateUserDto user);
    }
}
