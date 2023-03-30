using PB.Application.Dto.CommentDto;
using PB.Domain.Entities;

namespace PB.Application.Service.Interfaces
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CreateCommentDto createDto);
        Task UpdateCommentAsync(UpdateCommentDto updateDto);
        Task DeleteCommentAsync(int commentId);
        Task<ReadCommentDto> GetCommentById(int gameId);
    }
}