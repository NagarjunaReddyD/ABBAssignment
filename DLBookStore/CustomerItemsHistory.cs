//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DLBookStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerItemsHistory
    {
        public int id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string IsMembership { get; set; }
        public string ItemsName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public Nullable<int> NoOfItems { get; set; }
        public Nullable<decimal> Total { get; set; }
    }
}