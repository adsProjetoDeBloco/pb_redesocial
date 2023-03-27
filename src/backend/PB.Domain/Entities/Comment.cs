using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public User? User { get; set; }
        public DateTime PostedAt { get; set; }
        public Post? Post { get; set; }
    }
}
