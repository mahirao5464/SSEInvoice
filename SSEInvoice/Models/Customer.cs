using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models
{
    public class Customer
    {
        public string  CustomerName { get; set; }
        public Address PermanentAddress { get; set; }
        public IList<Address> ShipingAddress { get; set; }
        public string  Phone { get; set; }//
        public string GSTNumber { get; set; }// length 15
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;



    }
    public class Address
    {
        public string StateCode { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PINCode { get; set; }
    }
}
