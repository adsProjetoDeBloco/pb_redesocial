using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PB.Application.Dto.CommentDto
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}