using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
