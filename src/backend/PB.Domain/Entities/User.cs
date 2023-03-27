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
        public string Email { get; set; }
        public string Bio { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<Follower> Followers { get; set; } //1 usuario tem N seguidores
        public ICollection<Group> Grupos { get; set; } //1 Usuario possui N grupos
        public ICollection<Post> Posts {get; set;}
        public ICollection<Comment> Comments { get; set; }
    }
}
