using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceBookStore;
using ModelBookStore;
using System.Data;
namespace DLBookStore
{
   

    public class DLUserItem: IUserItem
    {
        TwinkleStoreEntities TBSEntities;
        public DLUserItem()
        {
            TBSEntities = new TwinkleStoreEntities();
        }

        public void Add(ModelBookStore.UserItem objModelUserItem)
        {
            UserItem objUserItem= new UserItem()
            {
              UserId=objModelUserItem.UserId,
              DateOfPurchase=objModelUserItem.DateOfPurchase,
              ItemId=objModelUserItem.ItemId,
              NoOfItems=objModelUserItem.NoOfItems,
              DiscAmmount=objModelUserItem.DiscAmmount,
              NetAmount=objModelUserItem.NetAmount
              
               
               
           };
            
            TBSEntities.UserItems.Add(objUserItem);
            TBSEntities.SaveChanges();
        }


        public void Update(ModelBookStore.UserItem objModelUserItem)
        {
            UserItem _SelectUserItemrow = TBSEntities.UserItems.Where(x => x.id == objModelUserItem.id).Select(x => x).FirstOrDefault();

            if (_SelectUserItemrow == null)
            {
                Add(objModelUserItem);
            }

            else
            {
                _SelectUserItemrow.ItemId = objModelUserItem.ItemId;
                _SelectUserItemrow.UserId = objModelUserItem.UserId;
                _SelectUserItemrow.DateOfPurchase = objModelUserItem.DateOfPurchase;
                _SelectUserItemrow.DiscAmmount = objModelUserItem.DiscAmmount;
                _SelectUserItemrow.NetAmount = objModelUserItem.NetAmount;
                _SelectUserItemrow.NoOfItems = objModelUserItem.NoOfItems;

            TBSEntities.SaveChanges();
            }
        }
        public void Delete(ModelBookStore.UserItem objModelUserItem)
        {
            UserItem _SelectUserItemToDeleteRow = TBSEntities.UserItems.Where(x => x.id == objModelUserItem.id).Select(x => x).FirstOrDefault();
           
            TBSEntities.UserItems.Remove(_SelectUserItemToDeleteRow);
           TBSEntities.SaveChanges();
        }

      

        public List<ModelBookStore.UserItem> Search(ModelBookStore.UserItem objModelUserItem)
        {
           
            var UserItemlist = (from objItems in TBSEntities.UserItems
                            where objItems.id == objModelUserItem.id && objItems.UserId == objModelUserItem.UserId
                            select objItems
                            //select new Role { id = objItems.id, UserId = objItems.Name }
                            ).ToList();

            ModelBookStore.UserItem ModlelUsertemObj; 
            List<ModelBookStore.UserItem> objlist = new List<ModelBookStore.UserItem>();
            foreach (var Useritem in UserItemlist)
            {
                ModlelUsertemObj = new ModelBookStore.UserItem();
                ModlelUsertemObj.id = Useritem.id;
                ModlelUsertemObj.UserId = Convert.ToInt32(Useritem.UserId);
                ModlelUsertemObj.ItemId = Convert.ToInt32(Useritem.ItemId);
                ModlelUsertemObj.DateOfPurchase = Convert.ToDateTime( Useritem.DateOfPurchase);
                ModlelUsertemObj.NoOfItems = Convert.ToInt32(Useritem.NoOfItems);



                objlist.Add(ModlelUsertemObj);
            }

        return objlist;
        }



        public List<ModelBookStore.UserItem> Load()
        {
            var UserItemlist = (from objUserItems in TBSEntities.UserItems
                                join objCustomer in TBSEntities.UserDetails on objUserItems.UserId equals objCustomer.id
                                join objItem in TBSEntities.Items on objUserItems.ItemId equals objItem.id

                               // select objUserItems
                         select new
                         {
                             id= objUserItems.id,
                             UserId= objUserItems.UserId,
                             ItemId=objUserItems.ItemId,
                             CustomerName = objCustomer.FirstName,
                             ItemName = objItem.Name,
                             DateOfPurchase= objUserItems.DateOfPurchase,
                             
                             NoOfItems=objUserItems.NoOfItems,
                             DiscAmmount= objUserItems.DiscAmmount,
                             NetAmount= objUserItems.NetAmount


                         }
                         ).ToList();

            ModelBookStore.UserItem ModlelUsertemObj;
            List<ModelBookStore.UserItem> objlist = new List<ModelBookStore.UserItem>();
            foreach (var UseritemLst in UserItemlist)
            {
                ModlelUsertemObj = new ModelBookStore.UserItem();
                ModlelUsertemObj.id = UseritemLst.id;
                ModlelUsertemObj.UserId = Convert.ToInt32(UseritemLst.UserId);
                ModlelUsertemObj.ItemId = Convert.ToInt32(UseritemLst.ItemId);
                ModlelUsertemObj.CustomerName = UseritemLst.CustomerName;
                ModlelUsertemObj.ItemName = UseritemLst.ItemName;
                ModlelUsertemObj.DateOfPurchase = Convert.ToDateTime(UseritemLst.DateOfPurchase);
                ModlelUsertemObj.NoOfItems = Convert.ToInt32(UseritemLst.NoOfItems);
                ModlelUsertemObj.DiscAmmount = Convert.ToDecimal( UseritemLst.DiscAmmount);
                ModlelUsertemObj.NetAmount = Convert.ToDecimal(UseritemLst.NetAmount);


                objlist.Add(ModlelUsertemObj);
            }

            return objlist;
        }

        public bool IsMember(int CustID)
        {

            var UserItemlist = (from objItems in TBSEntities.UserDetails
                                where objItems.id == CustID && objItems.IsMembership=="Y"
                                select objItems
                            //select new Role { id = objItems.id, UserId = objItems.Name }
                            ).ToList();

            if (UserItemlist.Count != 0 || UserItemlist != null)
            {
                return true;
            }

            return false;
        }
        public string CustomerType(int CustID)
        {

            var UserItemlist = (from objItems in TBSEntities.UserItems
                                where objItems.UserId == CustID
                                select objItems
                            //select new Role { id = objItems.id, UserId = objItems.Name }
                            ).ToList();

            if ( UserItemlist.Count != 0 || UserItemlist!=null)
            {
                return "Old";
            }

            return "New";
        }
        public DateTime DOB(int CustID)
        {

            var UserItemlist = (from objItems in TBSEntities.UserDetails
                                where objItems.id == CustID
                                select objItems
                            //select new Role { id = objItems.id, UserId = objItems.Name }
                            ).ToList();


            return Convert.ToDateTime(UserItemlist[0].DOB);
           
           // return "New";
        }
        public Decimal TotlalPurchaseAmount(int CustID)
        {

            var UserItemlist = (from objItems in TBSEntities.UserItems
                                where objItems.UserId == CustID
                                select objItems
                            //select new Role { id = objItems.id, UserId = objItems.Name }
                            ).ToList();

            var SumPurchaseAmount = UserItemlist.Sum(s => s.NetAmount);
            return Convert.ToDecimal(SumPurchaseAmount);

            // return "New";
        }

        public int NoOfPurchases(int CustID)
        {

            var UserItemlist = (from objItems in TBSEntities.UserItems
                                where objItems.UserId == CustID
                                select objItems
                            //select new Role { id = objItems.id, UserId = objItems.Name }
                            ).ToList();

           
            return UserItemlist.Count;
        }
        public Decimal ItemPrice(int ItemId)
        {

            var UserItemlist = (from objItems in TBSEntities.Items
                                where objItems.id == ItemId
                                select objItems
                            //select new Role { id = objItems.id, UserId = objItems.Name }
                            ).ToList();

            //var SumPurchaseAmount = UserItemlist.Sum(s => s.NoOfItems);
            return Convert.ToDecimal(UserItemlist[0].Price);

            // return "New";
        }
        public DateTime MemberSince(int CustID)
        {

            var UserItemlist = (from objItems in TBSEntities.UserItems
                                where objItems.UserId == CustID
                                select objItems.DateOfPurchase
                            //select new Role { id = objItems.id, UserId = objItems.Name }
                            ).Min();
           

            return Convert.ToDateTime(UserItemlist);

            // return "New";
        }
        public bool Eligible20Discount( int CustId)
        {

            var Eligigble = TBSEntities.usp_Qualified20Discount(CustId);
            

            foreach (var item in Eligigble)
            {
                if (item.ToString() == "Yes")
                {
                    return true;
                }
            }

            return false;

        }
     
    }
}
