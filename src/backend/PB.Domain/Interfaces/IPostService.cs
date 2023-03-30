using PB.Domain.Dto.PostDto;
using PB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int postId);
        Task<ICollection<ReadPostDto>> GetAllPopstAsync();
        Task<ReadGameDto> GetPostById(int postId);
    }
}