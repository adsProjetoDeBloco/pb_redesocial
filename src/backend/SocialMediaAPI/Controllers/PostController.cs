using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PB.Domain.Dto.PostDto;
using PB.Domain.Interfaces;

namespace SocialMediaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("creat-post")]
        public async Task<IActionResult> CreatPost(CreatPostDto creatDto)
        {

            await _postService.CreatePostAsync(creatDto);

            return CreatedAtAction(nameof(GetPostById), new { creatDto.Id }, creatDto);
        }
        [HttpGet("get-post-by-id/{id}")]
        public async Task<IActionResult> GetPostById(int postId)
        {

            var post = await _postService.GetPostById(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
        [HttpGet("get-all-posts")]
        public async Task<IActionResult> GetAllPosts()
        {

            var posts = await _postService.GetAllPostAsync();
            if (posts.Count <= 0 || posts == null)
            {
                return NotFound();
            }
            return Ok(posts);
        }

        [HttpPost("delete-post/{id}")]
        public async Task<IActionResult> DeletePost(int Id)
        {

            await _postService.DeletePostAsync(Id);

            return NoContent();
        }
    }
}