using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBookStore
{
  public  class UserItem
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }

        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int NoOfItems { get; set; }

        public decimal DiscAmmount { get; set; }
        public decimal NetAmount { get; set; }


    }
}
