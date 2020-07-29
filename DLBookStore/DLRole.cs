using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceBookStore;
using ModelBookStore;
namespace DLBookStore
{
   

    public class DLRole:IRole
    {
        TwinkleStoreEntities TBSEntities;
        public DLRole()
        {
            TBSEntities = new TwinkleStoreEntities();
        }

        public void Add(ModelBookStore.Role objModelRole)
        {
            Role objRole= new Role()
            {
              
                Name = objModelRole.Name
               
           };
            
            TBSEntities.Roles.Add(objRole);
            TBSEntities.SaveChanges();
        }


        public void Update(ModelBookStore.Role objModelRole)
        {
            Role _SelectRoletoUpdateRow = TBSEntities.Roles.Where(x => x.id == objModelRole.id).Select(x => x).FirstOrDefault();
            _SelectRoletoUpdateRow.Name = objModelRole.Name;

            TBSEntities.SaveChanges();
        }
        public void Delete(ModelBookStore.Role objModelRole)
        {
            Role _SelectRoleToDeleteRow = TBSEntities.Roles.Where(x => x.id == objModelRole.id).Select(x => x).FirstOrDefault();
           
            TBSEntities.Roles.Remove(_SelectRoleToDeleteRow);
           TBSEntities.SaveChanges();
        }

      

        public List<ModelBookStore.Role> Search(ModelBookStore.Role objModelRole)
        {
           
            var Rolelist = (from objRoles in TBSEntities.Roles
                            where objRoles.id == objModelRole.id && objRoles.Name == objModelRole.Name
                            select new Role { id = objRoles.id, Name = objRoles.Name }).ToList();

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



        public List<ModelBookStore.Role> Load()
        {
            var Rolelist = (from objRoles in TBSEntities.Roles

                        select objRoles).ToList();
            ModelBookStore.Role ModleRoleObj; 
                //= new ModelBookStore.Role();
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



    }
}
