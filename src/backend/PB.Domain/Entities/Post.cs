using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostText { get; set; }
        public string UserName { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
