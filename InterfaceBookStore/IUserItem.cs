using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBookStore;
using System.Data;
namespace InterfaceBookStore
{
   public interface IUserItem
    {
        void Add(UserItem obj);
        void Update(UserItem obj);
        void Delete(UserItem obj);
       List<UserItem> Search(UserItem obj);
        List<UserItem> Load();

        bool IsMember(int CustId);
        string CustomerType(int CustId);
        DateTime DOB(int CustId);

        Decimal TotlalPurchaseAmount(int CustId);
        int NoOfPurchases(int CustId);

        Decimal ItemPrice(int ItemId);

        DateTime MemberSince(int CustId);

        bool Eligible20Discount(int CustId);

      
    }
}
