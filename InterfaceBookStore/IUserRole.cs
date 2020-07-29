using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBookStore;
namespace InterfaceBookStore
{
  public  interface IUserRole
    {
        void Add(UserRole obj);
        void Update(UserRole obj);

       List< Login> LoadUsers();
        List<Role> LoadRoles();
        List<UserDetail> LoadCustomers();
    }
}
