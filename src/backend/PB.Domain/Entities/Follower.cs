using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class Follower
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<UserFollowers>? Users { get; set; } //Seguidores possui uma lista de usuarios

    }
}
