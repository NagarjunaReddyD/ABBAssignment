using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceBookStore;
using ModelBookStore;
namespace DLBookStore
{
   

    public class DLUserRole:IUserRole
    {
        TwinkleStoreEntities TBSEntities;
        public DLUserRole()
        {
            TBSEntities = new TwinkleStoreEntities();
        }



        public void Add(ModelBookStore.UserRole objModelUserRole)
        {
            UserRole objUserRole = new UserRole()
            {
            UserId = objModelUserRole.UserId,
            RoleId=objModelUserRole.RoleId
              };

            TBSEntities.UserRoles.Add(objUserRole);
            TBSEntities.SaveChanges();
        }

        public void Update(ModelBookStore.UserRole objModelUserRole)
        {
            UserRole _SelectUserRole = TBSEntities.UserRoles.Where(x => x.UserId == objModelUserRole.UserId
            //&& x.RoleId == objModelUserRole.RoleId 
            ).Select(x => x).FirstOrDefault();

            if(_SelectUserRole==null)
            {
                Add(objModelUserRole);
            }

            else
            { 
            _SelectUserRole.RoleId = objModelUserRole.RoleId;
                _SelectUserRole.UserId = objModelUserRole.UserId;

            TBSEntities.SaveChanges();
            }
        }

        public List<ModelBookStore.Login> LoadUsers()
        {
            var UserList = (from objUsers in TBSEntities.Logins

                            select objUsers).ToList();

            ModelBookStore.Login ModleUserObj;
            List<ModelBookStore.Login> objUserlist = new List<ModelBookStore.Login>();

            foreach (var item in UserList)
            {
                ModleUserObj = new ModelBookStore.Login();
                ModleUserObj.id = item.id;
                ModleUserObj.UserId = item.UserId;
                objUserlist.Add(ModleUserObj);
            }

          return objUserlist;
        }

        public List<ModelBookStore.Role> LoadRoles()
        {
            var Rolelist = (from objRoles in TBSEntities.Roles

                            select objRoles).ToList();
            ModelBookStore.Role ModleRoleObj;
            List<ModelBookStore.Role> objlist = new List<ModelBookStore.Role>();

            foreach (var item in Rolelist)
            {
                ModleRoleObj = new ModelBookStore.Role();

                ModleRoleObj.id = item.id;
                ModleRoleObj.Name = item.Name;
                objlist.Add(ModleRoleObj);
            }
            return objlist;
        }
        public List<ModelBookStore.UserDetail> LoadCustomers()
        {
            var Customerlist = (from objCustomers in TBSEntities.UserDetails

                            select objCustomers).ToList();


            ModelBookStore.UserDetail ModleCustomerObj;
            List<ModelBookStore.UserDetail> objCustomerlist = new List<ModelBookStore.UserDetail>();

            foreach (var item in Customerlist)
            {
                ModleCustomerObj = new ModelBookStore.UserDetail();

                ModleCustomerObj.id = item.id;
                ModleCustomerObj.FirstName = item.FirstName;
                objCustomerlist.Add(ModleCustomerObj);
            }
            return objCustomerlist;
        }
    }
}
