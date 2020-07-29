using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBookStore;
using InterfaceBookStore;
namespace BLBookStore
{
    public class BLUserRole : IUserRole
    {
        private IUserRole UserRoleobj;
        public BLUserRole(IUserRole UserRoleobj)
        {
            this.UserRoleobj = UserRoleobj;
        }
      
     
        public void Add(UserRole objUserRole)
        {
            UserRoleobj.Add(objUserRole);
        }

        public void Update(UserRole objUserRole)
        {
            UserRoleobj.Update(objUserRole);
        }

        public List<Login> LoadUsers()
        {
            return UserRoleobj.LoadUsers();
        }

        public List<Role> LoadRoles()
        {
            return UserRoleobj.LoadRoles();
        }
        public List<UserDetail> LoadCustomers()
        {
            return UserRoleobj.LoadCustomers();
        }
    }
}
