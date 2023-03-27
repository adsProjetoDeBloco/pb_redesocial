using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PB.Domain.Dto.CommentDto;
using PB.Domain.Entities;
using PB.Domain.Interfaces;

namespace PB.Data.Service
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

        public async Task CreateCommentAsync(CreatCommentDto createDto)
        {
            var comment = _mapper.Map<Comment>(createDto);
            comment.PostedAt = DateTime.UtcNow;
            
            await _context.Comments.AddAsync(comment);
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
         public async Task DeleteCommentAsync(int commentId)
        {
            var getComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);

            if(getComment == null ) throw new Exception($"{commentId} não existe");

            _context.Comments.Remove(getComment);
            await _context.SaveChangesAsync();
        }
    }
}