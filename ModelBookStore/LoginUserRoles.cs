﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBookStore
{
   public class LoginUserRoles
    {
        public int LogId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int RoleId { get; set; }

        public string RoleName { get; set; }

    }
}
