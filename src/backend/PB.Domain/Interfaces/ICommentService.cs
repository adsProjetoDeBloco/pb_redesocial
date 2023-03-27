
using PB.Domain.Dto.CommentDto;
using PB.Domain.Entities;

namespace PB.Domain.Interfaces
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CreatCommentDto createDto);
        Task UpdateCommentAsync(UpdateCommentDto updateDto);
        Task DeleteCommentAsync(int commentId);
        Task<ReadCommentDto> GetCommentById(int gameId);
    }
}