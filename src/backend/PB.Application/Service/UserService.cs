using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PB.Application.Dto.UserDto;
using PB.Application.Service.Interfaces;
using PB.Data;
using PB.Domain.Entities;

namespace PB.Application.Service
{
    public class UserService : IUserService
    {
        private readonly SocialMediaDbContext _context;
        private readonly IMapper _mapper;

        public UserService(SocialMediaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task AddFollowerToUser(int followerId, int userId)
        {
            var follower = new UserFollowers() { FollowedUserId = userId, FollowerId = followerId };
            await _context.UserFollowers.AddAsync(follower);
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<ReadUserDto>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            var readDto = _mapper.Map<ICollection<ReadUserDto>>(users);

            return readDto;
        }
        public async Task AddGameToUser(int gameId, int userId)
        {
            
            var userGame = new UserGame()
            {
                GameId = gameId,
                UserId = userId
            };

            await _context.UserGames.AddAsync(userGame);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public Task UpdateUser(User updatedUser)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadUserDto> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            var mapUser = _mapper.Map<ReadUserDto>(user);

            return mapUser;
        }
    }
}

