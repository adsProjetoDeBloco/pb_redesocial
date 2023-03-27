using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public string? Description { get; set; }
        public ICollection<User> Members { get; set; } //Um grupo possui N usuarios
        public DateTime CreatedAt { get; set; }

    }
}
