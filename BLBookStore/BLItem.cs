using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBookStore;
using InterfaceBookStore;
namespace BLBookStore
{
    public class BLItem : IItem
    {
        private IItem Itemobj1;
        public BLItem(IItem Itemobj)
        {
            this.Itemobj1 = Itemobj;
        }
        public void Add(Item objItem)
        {
            Itemobj1.Add(objItem);
        }
        public void Update(Item objItem)
        {
            Itemobj1.Update(objItem);
        }
        public void Delete(Item objItem)
        {
            Itemobj1.Delete(objItem);
        }

        public List<Item> Load()
        {
           return Itemobj1.Load();
        }

        public List<Item> Search(Item objItem)
        {
            return Itemobj1.Search(objItem);
        }

      
    }
}
