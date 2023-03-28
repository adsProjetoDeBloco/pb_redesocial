using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PB.Domain.Entities
{
    public class UserGroup
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int GroupId { get; set; }
        public virtual Group? Group {get; set; }
    }
}