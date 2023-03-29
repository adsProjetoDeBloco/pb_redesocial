using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PB.Domain.Entities;
using PB.Domain.Interfaces;

namespace PB.Data.Service
{
    public class UserService : IUserService
    {
        private readonly SocialMediaDbContext _context;

        public UserService(SocialMediaDbContext context)
        {
            _context = context;
        }
         public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task AddFollowerToUser(int followerId, int userId)
        {
            var follower = new UserFollowers() { UserId = userId, FollowerId = followerId};
            await _context.UserFollowers.AddAsync(follower);
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            _context.Users.Remove(user);
            _context.SaveChangesAsync();
        }
        public Task UpdateUser(User updatedUser)
        {
            throw new NotImplementedException();
        }

       
    }
}