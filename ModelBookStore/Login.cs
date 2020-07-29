using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBookStore
{
    public  class Login
    {
        public int id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string enabled { get; set; }
        public virtual List<UserDetail> UserDetails { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
