using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
<<<<<<< HEAD
        public virtual ICollection<UserGame>? Users { get; set; }
        
=======
>>>>>>> 84967c0292841f7a32aa1931cf1a789a6dd05642
    }
}
