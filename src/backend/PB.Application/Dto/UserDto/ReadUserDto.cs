using PB.Application.Dto.GameDto;
using PB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PB.Application.Dto.UserDto
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public virtual ICollection<UserGame>? Games { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserFollowers>? Followers { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserGroup>? Groups { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
        [JsonIgnore]
        public byte[]? Avatar { get; set; }
    }
}
