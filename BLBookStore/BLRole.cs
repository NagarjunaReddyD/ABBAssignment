using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBookStore;
using InterfaceBookStore;
namespace BLBookStore
{
    public class BLRole : IRole
    {
        private IRole Roleobj;
        public BLRole(IRole Roleobj)
        {
            this.Roleobj = Roleobj;
        }
        public void Add(Role objRole)
        {
            Roleobj.Add(objRole);
        }
        public void Update(Role objRole)
        {
            Roleobj.Update(objRole);
        }
        public void Delete(Role objRole)
        {
            Roleobj.Delete(objRole);
        }

        public List<Role> Load()
        {
           return Roleobj.Load();
        }

        public List<Role> Search(Role objRole)
        {
            return Roleobj.Search(objRole);
        }

      
    }
}
