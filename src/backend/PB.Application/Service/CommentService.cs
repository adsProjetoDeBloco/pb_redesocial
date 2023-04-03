using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PB.Application.Dto.CommentDto;
using PB.Application.Service.Interfaces;
using PB.Data;
using PB.Domain.Entities;


namespace PB.Application.Service
{
    public class CommentService : ICommentService
    {
        private readonly SocialMediaDbContext _context;
        private readonly IMapper _mapper;

        public CommentService(SocialMediaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCommentAsync(CreateCommentDto createDto)
        {
            var comment = _mapper.Map<Comment>(createDto);
            comment.PostedAt = DateTime.UtcNow;
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }
        public async Task<ReadCommentDto> GetCommentById(int commentId)
        {
            var getComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
            var readDto = _mapper.Map<ReadCommentDto>(getComment);

            return readDto;
        }
        public async Task UpdateCommentAsync(UpdateCommentDto updateDto)
        {
            var oldComment = await _context.Comments.FirstOrDefaultAsync(g => g.Id == updateDto.Id);
            _mapper.Map(updateDto, oldComment);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCommentAsync(int Id)
        {
            var getComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == Id);

            if (getComment == null) throw new Exception($"{Id} não existe");

            _context.Comments.Remove(getComment);
            await _context.SaveChangesAsync();
        }
    }
}