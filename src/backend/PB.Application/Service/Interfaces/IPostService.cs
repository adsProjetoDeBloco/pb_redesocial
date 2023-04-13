using PB.Application.Dto.PostDto;
using PB.Domain.Entities;

namespace PB.Application.Service.Interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(CreatPostDto post);
        Task DeletePostAsync(int postId, int userId);
        Task<ICollection<ReadPostDto>> GetAllPostAsync();
        Task<ReadPostDto> GetPostById(int gameId);
    }
}