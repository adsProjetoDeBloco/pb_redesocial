using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PB.Domain.Entities;

namespace PB.Application.Dto.PostDto
{
    public class CreatPostDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PostText { get; set; }
        public int UserId { get; set; }
    }
}