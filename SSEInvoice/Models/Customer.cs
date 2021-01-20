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
        [Display(Name ="Enter Contact Person Name")]
        public string ContactPersonName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Permanent Address ")]
        public virtual Address PermanentAddress { get; set; }
        [Required(ErrorMessage = "Shipping Address is required")]
        public virtual IList<Address> ShipingAddress { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
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
        [DataType(DataType.PostalCode)]
        public int PINCode { get; set; }
    }
}
