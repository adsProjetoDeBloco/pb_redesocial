using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public string? Description { get; set; }
<<<<<<< HEAD
        public virtual ICollection<UserGroup> Users { get; set; } //Um grupo possui N usuarios
=======
        public ICollection<User> Members { get; set; } //Um grupo possui N usuarios
>>>>>>> 84967c0292841f7a32aa1931cf1a789a6dd05642
        public DateTime CreatedAt { get; set; }

    }
}
