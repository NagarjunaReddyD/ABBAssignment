using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBookStore;
using InterfaceBookStore;
using System.Data;
namespace BLBookStore
{
    public class BLUserItem : IUserItem
    {
        private IUserItem UserItemobj;
        public BLUserItem(IUserItem UserItemobj)
        {
            this.UserItemobj = UserItemobj;
        }
        public void Add(UserItem objUserItem)
        {
            UserItemobj.Add(objUserItem);
        }
        public void Update(UserItem objUserItem)
        {
            UserItemobj.Update(objUserItem);
        }
        public void Delete(UserItem objUserItem)
        {
            UserItemobj.Delete(objUserItem);
        }

        public List<UserItem> Load()
        {
           return UserItemobj.Load();
        }

        public List<UserItem> Search(UserItem objUserItem)
        {
            return UserItemobj.Search(objUserItem);
        }
        public bool IsMember(int CustId)
        {
            return UserItemobj.IsMember(CustId);
        }
        public string CustomerType(int CustId)
        {
            return UserItemobj.CustomerType(CustId);
        }
        public DateTime DOB(int CustId)
        {
            return UserItemobj.DOB(CustId);
        }
        public int NoOfPurchases(int CustId)
        {
            return UserItemobj.NoOfPurchases(CustId);
        }
        public Decimal TotlalPurchaseAmount(int CustId)
        {
            return UserItemobj.TotlalPurchaseAmount(CustId);
        }
        public DateTime MemberSince(int CustId)
        {
            return UserItemobj.MemberSince(CustId);
        }
        public Decimal ItemPrice(int CustId)
        {
            return UserItemobj.ItemPrice(CustId);
        }

        public Decimal Discount(bool IsMember, string TypeOfCust, decimal BillAmount, DateTime BillDate, DateTime DOB, int NoOfPurchases, Decimal TotalPurAmt, DateTime SinceFrom)
        {
            Decimal DiscAmount = 0;

            if (IsMember)
            {
                //Discount 5%
                DiscAmount = BillAmount * Convert.ToDecimal(0.05);

            }
            if (TypeOfCust == "New")
            {
                if (TypeOfCust == "New" && BillAmount <= 5000)
                {
                    //Discount 2%
                    DiscAmount = BillAmount * Convert.ToDecimal(0.02);
                }

                if (TypeOfCust == "New" && BillAmount > 5000)
                {
                    //Discount 3%
                    DiscAmount = BillAmount * Convert.ToDecimal(0.03);
                }


            }

            if (TypeOfCust == "Old")
            {
                if (TypeOfCust == "Old" && BillDate.Month == DOB.Month)
                {
                    // Discount  20%
                    DiscAmount = BillAmount * 2;
                }


                if (TypeOfCust == "Old" && NoOfPurchases > 5)
                {
                    // Discount  3%
                    DiscAmount = BillAmount * (Convert.ToDecimal(0.03));
                }
                if (TypeOfCust == "Old" && TotalPurAmt > 6000)
                {
                    // Discount  5%
                    DiscAmount = BillAmount * Convert.ToDecimal(0.05);
                }
                if (TypeOfCust == "Old" && SinceFrom.AddYears(5).Year == DateTime.Now.Year)
                {
                    // Discount  20%
                    DiscAmount = BillAmount * 2;
                }

            }

            return DiscAmount;
        }

        public bool Eligible20Discount(int CustId)
        {
            return UserItemobj.Eligible20Discount(CustId);
        }
       
        }
}
