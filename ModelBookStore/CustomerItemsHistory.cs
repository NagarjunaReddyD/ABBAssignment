using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBookStore
{
    
    public  class CustomerItemsHistory
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string IsMembership { get; set; }
        public string ItemsName { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int NoOfItems { get; set; }
    }
}
