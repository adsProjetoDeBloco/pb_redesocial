using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class UserFollowers
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int FollowerId { get; set; }
        public virtual Follower? Follower { get; set; }
    }
}