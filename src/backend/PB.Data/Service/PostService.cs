using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PB.Domain.Dto.PostDto;
using PB.Domain.Entities;
using PB.Domain.Interfaces;

namespace PB.Data.Service
{
    public class PostService : IPostService
    {
        private readonly SocialMediaDbContext _context;
        private readonly IMapper _mapper;

        public PostService(SocialMediaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePostAsync(CreatPostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.CreatedAt = DateTime.UtcNow;

            await _context.Posts.AddAsync(post);
        }

        public async Task<ICollection<ReadPostDto>> GetAllPostAsync()
        {
            var posts = await _context.Posts.ToListAsync();
            var readDto = _mapper.Map<ICollection<ReadPostDto>>(posts);

            return readDto;
        }

        public Task<ReadPostDto> GetPostById(int gameId)
        {
            throw new NotImplementedException();
        }
        public Task DeletePostAsync(int postId)
        {
            throw new NotImplementedException();
        }
    }
}