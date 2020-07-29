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
        private IItem Itemobj;
        public BLItem(IItem Itemobj)
        {
            this.Itemobj = Itemobj;
        }
        public void Add(Item objItem)
        {
            Itemobj.Add(objItem);
        }
        public void Update(Item objItem)
        {
            Itemobj.Update(objItem);
        }
        public void Delete(Item objItem)
        {
            Itemobj.Delete(objItem);
        }

        public List<Item> Load()
        {
           return Itemobj.Load();
        }

        public List<Item> Search(Item objItem)
        {
            return Itemobj.Search(objItem);
        }

      
    }
}
