using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBookStore;
using InterfaceBookStore;
namespace BLBookStore
{
    public class BLLogin : ILogin
    {
        private ILogin lgobj;
        public BLLogin(ILogin lgobj)
        {
            this.lgobj = lgobj;
        }
      

        public bool LoginUser(string UserName, string Password)
        {
          return  lgobj.LoginUser(UserName,Password);
        }

      

        public void Register(Login log)
        {
            lgobj.Register(log);
        }
        public void Add(UserDetail objUserDetail)
        {
            lgobj.Add(objUserDetail);
        }
        public void Update(UserDetail objUserDetail)
        {
            lgobj.Update(objUserDetail);
        }
        public void Delete(UserDetail objUserDetail)
        {
            lgobj.Delete(objUserDetail);
        }
        public List<LoginUserRoles> Search(string UserName, string Password)
        {
            return lgobj.Search(UserName, Password);
        }
        public List<UserDetail> Load()
        {
            return lgobj.Load();
        }
        public List<UserDetail> SearchCustomer()
        {
            return lgobj.SearchCustomer();
        }
        public List<UserDetail> LoadCustBDay()
        {

            return lgobj.LoadCustBDay();
        }
        public List<UserDetail> LoadAnnualBilling()
        {

            return lgobj.LoadAnnualBilling();
        }
    }
}
