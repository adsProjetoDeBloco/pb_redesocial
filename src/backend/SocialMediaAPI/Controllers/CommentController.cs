using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Domain.Dto.CommentDto;
using PB.Domain.Interfaces;

namespace SocialMediaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("creat-comment")]
        public async Task<IActionResult> CreatComment(CreatCommentDto creatDto)
        {

            await _commentService.CreateCommentAsync(creatDto);

            return CreatedAtAction(nameof(GetCommentById), new { creatDto.Id }, creatDto);
        }
        [HttpGet("get-comment-by-id/{id}")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {

            var comment = await _commentService.GetCommentById(commentId);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }
         [HttpPatch("updateComment/{id}")]
        public async Task<IActionResult> UpdateGameAsync(UpdateCommentDto updateDto)
        {
            await _commentService.UpdateCommentAsync(updateDto);
            
            return Ok(updateDto);
        }
        

        [HttpPost("delete-post/{id}")]
        public async Task<IActionResult> DeletePost(int Id)
        {
            await _commentService.DeleteCommentAsync(Id);

            return NoContent();
        }
    }
}