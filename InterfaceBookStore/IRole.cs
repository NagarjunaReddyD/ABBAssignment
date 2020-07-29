using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBookStore;
namespace InterfaceBookStore
{
   public interface IRole
    {
        void Add(Role obj);
        void Update(Role obj);
        void Delete(Role obj);
       List<Role> Search(Role obj);
        List<Role> Load();
    }
}
