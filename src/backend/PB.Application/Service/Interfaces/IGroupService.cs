using PB.Application.Dto.PostDto;
using PB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Application.Service.Interfaces
{
    public interface IGroupService
    {
        Task CreateGroup(Group group);
        Task DeleteGroup(int groupId);
        Task<ICollection<Group>> GetAllGroup();
        Task<Group> GetGroupById(int groupId);
        Task AddUserToGroup(int userId, int groupId);
    }
}
