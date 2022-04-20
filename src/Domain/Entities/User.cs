using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public bool IsAuthorised { get; set; }

        public int ProfileId { get; set; }
     //   public virtual Profile Profile { get; set; }
    }
}
