using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Application.Dto.CommentDto;
using PB.Application.Service.Interfaces;

namespace SocialMediaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("creat-comment")]
        public async Task<IActionResult> CreatComment(CreateCommentDto creatDto)
        {
            await _commentService.CreateCommentAsync(creatDto);

            return CreatedAtAction(nameof(GetCommentById), new { commentId = creatDto.Id }, creatDto);
        }

        [HttpGet("get-comment-by-id/{commentId}")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
            var comment = await _commentService.GetCommentById(commentId);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpPatch("updateComment")]
        public async Task<IActionResult> UpdateGameAsync(UpdateCommentDto updateDto)
        {
            await _commentService.UpdateCommentAsync(updateDto);

            return Ok(updateDto);
        }

        [HttpDelete("delete-post/{commentId}")]
        public async Task<IActionResult> DeletePost(int commentId)
        {
            await _commentService.DeleteCommentAsync(commentId);

            return NoContent();
        }
    }
}