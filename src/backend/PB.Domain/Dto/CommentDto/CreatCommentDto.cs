using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PB.Domain.Dto.CommentDto
{
    public class CreatCommentDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
    }
}