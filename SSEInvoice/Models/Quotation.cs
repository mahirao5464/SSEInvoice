using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models
{
    public class Quotation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer {get; set;}
        public ICollection<CustomVarient> CustomVarient { get; set; }
        [Display(Name ="Billing To ")]
        [ForeignKey("Address")]
        public int BillingTo { get; set; }
        public string BillingAddressString { get; set; }
        public string QuotNumber { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double SubTotal { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double TotalTax { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double ShippingCharges { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double TotalAmount { get; set; }// Total Amount including all the charges subtotal + tax +shippingcharges + other charges if available
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

    }
    public class CustomVarient
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Varient")]
        public int VarientId { get; set; }
        public virtual Varient Varient { get; set; }
        public double Count { get; set; }
        public double CustomePrice { get; set; }
        [DataType(DataType.Currency)]
        public double Cgst { get; set; }
        [DataType(DataType.Currency)]
        public double Sgst { get; set; }
        public bool IsCgstOnly { get; set; }

        public DateTime UpdatedOn { get; set; } = DateTime.Now;

    }
}
