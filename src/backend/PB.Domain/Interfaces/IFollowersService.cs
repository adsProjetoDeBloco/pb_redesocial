using PB.Domain.Dto.FollowersDto;
using PB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Interfaces
{
    public interface IFollowersService
    {
        Task CreateFollowersAsync(Followers followers);
        Task UpdateFollowersAsync(Followers followers);
        Task DeleteFollowersAsync(int followersId);
        Task<ICollection<ReadFollowersDto>> GetAllFollowersAsync();
        Task<ReadGameDto> GetFollowersById(int followerId);
    }
}