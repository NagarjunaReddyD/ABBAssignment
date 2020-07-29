using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBookStore
{
   public class UserDetail
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string city { get; set; }
        public string state { get; set; }

        public string IsMembership { get; set; }
        public virtual Login Login { get; set; }
    }
}
