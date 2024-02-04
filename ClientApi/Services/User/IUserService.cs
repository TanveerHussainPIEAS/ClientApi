using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int userId);
        Task<UserDto> LoginByEmailOrUserName(LoginUserDto loginUserDto);
        Task<List<UserDto>> GetUsers();
        Task<bool> SaveUser(UserDto userDto);
        Task<bool> UpdateUser(UserDto userDto);
    }
}
