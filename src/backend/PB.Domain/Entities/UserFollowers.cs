using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class UserFollowers
    {
        public int FollowerId { get; set; }
        [JsonIgnore]
        public virtual User? Follower { get; set; }
        public int FollowedUserId { get; set; }
        [JsonIgnore]
        public virtual User? FollowedUser { get; set; }
    }
}