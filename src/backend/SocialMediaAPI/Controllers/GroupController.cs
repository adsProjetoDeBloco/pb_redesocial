using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Application.Dto.CommentDto;
using PB.Application.Service.Interfaces;
using PB.Domain.Entities;

namespace SocialMediaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateGroup(Group group)
        {
            await _groupService.CreateGroup(group);

            return CreatedAtAction(nameof(GetGroupById), new { group.Id }, group) ;
        }
        [HttpGet("get-group-by-id/{id}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var group = await _groupService.GetGroupById(id);

            return Ok(group);
        }
        [HttpPost("add-user-to-group/{userId}/{groupId}")]
        public async Task<IActionResult> AddUserToGroup(int userId, int groupId)
        {
            await _groupService.AddUserToGroup(userId, groupId);

            return Ok("Success");
        }
        [HttpGet("get-all-groups")]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await _groupService.GetAllGroup();

            return Ok(groups);
        }
        [HttpDelete("delete-group/{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await _groupService.DeleteGroup(id);

            return NoContent();
        }




    }
}