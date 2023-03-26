using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class Follower
    {
        public int Id { get; set; }
        public ICollection<User> Followers { get; set; } //Seguidores possui uma lista de usuarios

    }
}
