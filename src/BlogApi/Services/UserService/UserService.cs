using BlogApp_webapi.Data;
using BlogApp_webapi.Dtos.User;
using BlogApp_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp_webapi.Services.UserService;

    public class UserService : IUserService
    {
        private readonly BlogContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(BlogContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CreateUserDto>> Register(CreateUserDto user)
        {
            var serviceResponse = new ServiceResponse<CreateUserDto>();
            var userDto = _mapper.Map<User>(user);

            _dbContext.Users.Add(userDto);
            await _dbContext.SaveChangesAsync();
            serviceResponse.Data = user;

            return serviceResponse;

        }
        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == id);

            if (user != null){
                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<UpdateUserDto>> UpdateUserInformation(int id, UpdateUserDto userDto){
            var serviceResponse = new ServiceResponse<UpdateUserDto>();
            var user = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == id);
            
            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Post not found.";
                return serviceResponse;
            }
            
            // Update user properties from updatedUser DTO
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Username = userDto.Username;
            user.EmailAddress = userDto.EmailAddress;
            
            
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            
            serviceResponse.Data = _mapper.Map<UpdateUserDto>(user);
            return serviceResponse;

        }

}
