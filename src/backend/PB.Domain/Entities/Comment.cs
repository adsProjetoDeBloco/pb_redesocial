using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Message { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        public DateTime PostedAt { get; set; }
        public int PostId { get; set; }
        [JsonIgnore]
        public virtual Post? Post { get; set; }
    }
}
