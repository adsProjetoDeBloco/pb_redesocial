using PB.Domain.Dto.GroupDto;
using PB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Interfaces
{
    public interface IGroupService
    {
        Task CreateGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(int groupId);
        Task<ICollection<ReadGroupDto>> GetAllGroupAsync();
        Task<ReadGameDto> GetGroupById(int groupId);
    }
}