using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class UserGame
    {
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        [JsonIgnore]
        public int GameId { get; set; }
        public virtual Game? Game { get; set; }
    }
}