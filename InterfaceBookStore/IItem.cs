using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBookStore;
namespace InterfaceBookStore
{
   public interface IItem
    {
        void Add(Item obj);
        void Update(Item obj);
        void Delete(Item obj);
       List<Item> Search(Item obj);
        List<Item> Load();
    }
}
