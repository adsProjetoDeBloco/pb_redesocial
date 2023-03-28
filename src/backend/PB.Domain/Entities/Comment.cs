using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Message { get; set; }
<<<<<<< HEAD
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime PostedAt { get; set; }
        public int PostId { get; set; }
        public virtual Post? Post { get; set; }

=======
        public User? User { get; set; }
        public DateTime PostedAt { get; set; }
        public Post? Post { get; set; }
>>>>>>> 84967c0292841f7a32aa1931cf1a789a6dd05642
    }
}
