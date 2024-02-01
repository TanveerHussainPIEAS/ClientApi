using ClientApi.DTO;

namespace ClientApi.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int userId);
        Task<List<UserDto>> GetUsers();
        Task<bool> SaveUser(UserDto userDto);
        Task<bool> UpdateUser(UserDto userDto);
    }
}
