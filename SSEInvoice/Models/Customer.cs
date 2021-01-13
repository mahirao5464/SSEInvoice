using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Customer Name is required")]
        public string  CustomerName { get; set; }
        [Required]
        public virtual Address PermanentAddress { get; set; }
        [Required]
        public IList<Address> ShipingAddress { get; set; }
        [Required]
        public string  Phone { get; set; }//
        [Required]
        public string GSTNumber { get; set; }// length 15
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;


    }
    public class Address
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string StateCode { get; set; }
        [Required]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int PINCode { get; set; }
    }
}
