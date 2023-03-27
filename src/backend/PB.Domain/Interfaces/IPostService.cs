using PB.Domain.Dto.PostDto;
using PB.Domain.Entities;

namespace PB.Domain.Interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(CreatPostDto post);
        Task DeletePostAsync(int postId);
        Task<ICollection<ReadPostDto>> GetAllPostAsync();
        Task<ReadPostDto> GetPostById(int gameId);
    }
}