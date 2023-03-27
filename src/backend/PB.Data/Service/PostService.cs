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

        public async Task<ReadPostDto> GetPostById(int postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            var readDto = _mapper.Map<ReadPostDto>(post);

            return readDto;
        }
        public async Task DeletePostAsync(int postId)
        {
            var deletedPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            if (deletedPost == null)
            {
                throw new Exception($"{postId} não existe");
            }
            _context.Posts.Remove(deletedPost);
            await _context.SaveChangesAsync();
        }
    }
}