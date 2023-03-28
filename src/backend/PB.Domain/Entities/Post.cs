using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PostText { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
