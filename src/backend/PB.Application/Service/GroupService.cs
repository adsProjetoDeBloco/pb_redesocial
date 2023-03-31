using Microsoft.EntityFrameworkCore;
using PB.Application.Dto.PostDto;
using PB.Application.Service.Interfaces;
using PB.Data;
using PB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Application.Service
{
    public class GroupService : IGroupService
    {
        private readonly SocialMediaDbContext _context;

        public GroupService(SocialMediaDbContext context)
        {
            _context = context;
        }
        public async Task CreateGroup(Group group)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
        }
        public async Task AddUserToGroup(int userId, int groupId)
        {
            var userGroup = new UserGroup()
            {
                UserId= userId,
                GroupId= groupId
            };
            await _context.UserGroups.AddAsync(userGroup);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Group>> GetAllGroup()
        {
            var listGroup = await _context.Groups.ToListAsync();

            return listGroup;
        }

        public async Task<Group> GetGroupById(int groupId)
        {
            var group = await _context.Groups.FirstOrDefaultAsync(g => g.Id == groupId);

            return group;
        }
        public async Task DeleteGroup(int groupId)
        {
            var group = await _context.Groups.FirstOrDefaultAsync(g => g.Id == groupId);

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }
    }
}
