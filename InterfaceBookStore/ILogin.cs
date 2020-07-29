using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBookStore;

namespace InterfaceBookStore
{
    public interface ILogin
    {
        bool LoginUser(string UserName, string Password);
        void Register(Login log);
        void Add(UserDetail log);

        void Update(UserDetail log);
        void Delete(UserDetail obj);
        List<LoginUserRoles> Search(string UserName, string Password);

        List<UserDetail> Load();

        List<UserDetail> SearchCustomer();
        List<UserDetail> LoadCustBDay();
        List<UserDetail> LoadAnnualBilling();
    }
}
