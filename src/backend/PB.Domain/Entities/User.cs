using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public virtual ICollection<UserGame>? Games { get; set; }
        public virtual ICollection<UserFollowers>? Followers { get; set; }
        public virtual ICollection<UserFollowers>? Following { get; set; }
        public virtual ICollection<UserGroup>? Groups { get; set; } 
        public virtual ICollection<Post>? Posts {get; set;}
        public virtual ICollection<Comment>? Comments { get; set; } 
        public byte[]? Avatar { get; set; }
    }
}
