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


        [HttpPost("creategroup")]
        public async Task<IActionResult> CreateGroup(Group group)
        {
            await _groupService.CreateGroup(group);

            return CreatedAtAction(nameof(GetGroupById), new { group.Id }, group) ;
        }
        [HttpGet("getgroupbyid/{id}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var group = await _groupService.GetGroupById(id);

            return Ok(group);
        }
        [HttpPost("addusertogroup/{userId}/{groupId}")]
        public async Task<IActionResult> AddUserToGroup(int userId, int groupId)
        {
            await _groupService.AddUserToGroup(userId, groupId);

            return Ok("Success");
        }
        [HttpGet("getallgroups")]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await _groupService.GetAllGroup();

            return Ok(groups);
        }
        [HttpDelete("deletegroup/{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await _groupService.DeleteGroup(id);

            return NoContent();
        }




    }
}