using Microsoft.AspNetCore.Mvc;
using PB.Application.Dto.PostDto;
using PB.Application.Service.Interfaces;

namespace SocialMediaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("creatpost")]
        public async Task<IActionResult> CreatPost(CreatPostDto createDto)
        {

            await _postService.CreatePostAsync(createDto);

            return Ok(createDto);
        }
        [HttpGet("getpostbyid/{postId}")]
        public async Task<IActionResult> GetPostById(int postId)
        {

            var post = await _postService.GetPostById(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
        [HttpGet("getallposts")]
        public async Task<IActionResult> GetAllPosts()
        {

            var posts = await _postService.GetAllPostAsync();
            if (posts.Count <= 0 || posts == null)
            {
                return NotFound();
            }
            return Ok(posts);
        }

        [HttpDelete("deletepost/{postId}/{userId}")]
        public async Task<IActionResult> DeletePost(int postId, int userId)
        {

            await _postService.DeletePostAsync(postId, userId);

            return NoContent();
        }
    }
}

