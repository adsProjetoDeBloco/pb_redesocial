using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PB.Domain.Entities;

namespace PB.Domain.Interfaces
{
    public interface IFollowerService
    {
        Task AddFollowerToUser(User follower);
        Task RemoveFollowerOfUser(int Id);
        Task<ICollection<Follower>> GetAllFollowersFromUser(int Id);
        
    }
}