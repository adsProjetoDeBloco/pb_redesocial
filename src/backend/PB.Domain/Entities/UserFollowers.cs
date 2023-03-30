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
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        public int FollowerId { get; set; }
        public virtual User? Follower { get; set; }
    }
}