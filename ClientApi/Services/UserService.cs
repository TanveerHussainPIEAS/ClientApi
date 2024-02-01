using AutoMapper;
using ClientApi.DBContext;
using ClientApi.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClientApi.Services
{
    public class UserService : IUserService
    {
        private readonly ClientDbContext _context;
        private readonly IMapper mapper;

        public UserService(ClientDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public async Task<UserDto> GetUser(int userId)
        {
            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var user = await _context.Users.ToListAsync();
            var usersDto = mapper.Map<List<UserDto>>(user);
            return usersDto;
        }

        public async Task<bool> SaveUser(UserDto userDto)
        {
            var isSaved = false;
            var user=new User();
            user.TypeId = userDto.TypeId;
            user.PermissionId = userDto.PermissionId;
            user.Name = userDto.Name;
            user.UserName = userDto.UserName;
            user.Password = userDto.Password;
            user.Email = userDto.Email;
            user.Address = userDto.Address;
            user.PhoneNumber = userDto.PhoneNumber;
            user.MobileNumber = userDto.MobileNumber;
            user.City = userDto.City;
            user.Country = userDto.Country;
            user.State = userDto.State;
            user.ZipCode = userDto.ZipCode;
            user.CreatedDate = DateTime.Now;
            user.Deleted = false;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            isSaved= true;
            return isSaved;
        }

        public async Task<bool> UpdateUser(UserDto userDto)
        {
            var isUpdated = false;
            var user = await _context.Users.Where(u => u.Id == userDto.Id).FirstOrDefaultAsync();            
            user.TypeId = userDto.TypeId;
            user.PermissionId = userDto.PermissionId;
            user.Name = userDto.Name;
            user.UserName = userDto.UserName;
            user.Password = userDto.Password;
            user.Email = userDto.Email;
            user.Address = userDto.Address;
            user.PhoneNumber = userDto.PhoneNumber;
            user.MobileNumber = userDto.MobileNumber;
            user.City = userDto.City;
            user.Country = userDto.Country;
            user.State = userDto.State;
            user.ZipCode = userDto.ZipCode;
            user.ModifiedDate = DateTime.Now;
            user.Deleted = false;
            await _context.SaveChangesAsync();
            isUpdated = true;
            return isUpdated;
        }
    }
}
