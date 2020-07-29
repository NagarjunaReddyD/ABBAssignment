using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceBookStore;
using ModelBookStore;
namespace DLBookStore
{
   

    public class DLItem: IItem
    {
        TwinkleStoreEntities TBSEntities;
        public DLItem()
        {
            TBSEntities = new TwinkleStoreEntities();
        }

        public void Add(ModelBookStore.Item objModelItem)
        {
            Item objItem= new Item()
            {
              
                Name = objModelItem.Name,
                Price=objModelItem.Price
               
           };
            
            TBSEntities.Items.Add(objItem);
            TBSEntities.SaveChanges();
        }


        public void Update(ModelBookStore.Item objModelItem)
        {
            Item _SelectItemrow = TBSEntities.Items.Where(x => x.id == objModelItem.id).Select(x => x).FirstOrDefault();

            if (_SelectItemrow == null)
            {
                Add(objModelItem);
            }

            else
            { 
            _SelectItemrow.Name = objModelItem.Name;
            _SelectItemrow.Price = objModelItem.Price;

            TBSEntities.SaveChanges();
            }
        }
        public void Delete(ModelBookStore.Item objModelItem)
        {
            Item _SelectRoleToDeleteRow = TBSEntities.Items.Where(x => x.id == objModelItem.id).Select(x => x).FirstOrDefault();
           
            TBSEntities.Items.Remove(_SelectRoleToDeleteRow);
           TBSEntities.SaveChanges();
        }

      

        public List<ModelBookStore.Item> Search(ModelBookStore.Item objModelItem)
        {
           
            var Rolelist = (from objItems in TBSEntities.Items
                            where objItems.id == objModelItem.id && objItems.Name == objModelItem.Name
                            select new Role { id = objItems.id, Name = objItems.Name }).ToList();

            ModelBookStore.Item ModleItemObj; 
            List<ModelBookStore.Item> objlist = new List<ModelBookStore.Item>();
            foreach (var item in Rolelist)
            {
                ModleItemObj = new ModelBookStore.Item();
                ModleItemObj.id = item.id;
                ModleItemObj.Name = item.Name;
                objlist.Add(ModleItemObj);
            }

        return objlist;
        }



        public List<ModelBookStore.Item> Load()
        {
            var Itemlist = (from objItems in TBSEntities.Items

                        select objItems).ToList();
            ModelBookStore.Item ModleItemObj; 
                //= new ModelBookStore.Role();
            List<ModelBookStore.Item> objlist = new List<ModelBookStore.Item>();
            
            foreach (var item in Itemlist)
            {
                ModleItemObj = new ModelBookStore.Item();
                ModleItemObj.id = item.id;
                ModleItemObj.Name = item.Name;
                ModleItemObj.Price = Convert.ToDecimal(item.Price);
               
                
                objlist.Add(ModleItemObj);
               
            }

          return objlist;
        }



    }
}
