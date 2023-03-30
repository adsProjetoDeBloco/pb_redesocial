using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string? GameName { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public byte[]? Images { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserGame>? Users { get; set; }
    }
}
