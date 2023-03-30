using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PB.Application.Dto.UserDto;
using PB.Domain.Entities;

namespace PB.Application.Service.Interfaces
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task AddFollowerToUser(int followerId, int userId);
        Task DeleteUser(int Id);
        Task UpdateUser(User updatedUser);
        Task<ICollection<ReadUserDto>> GetAllUsers();
        Task AddGameToUser(int gameId, int userId);
    }
}