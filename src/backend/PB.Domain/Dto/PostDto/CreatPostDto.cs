using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PB.Domain.Entities;

namespace PB.Domain.Dto.PostDto
{
    public class CreatPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostText { get; set; }
        public string UserName { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}