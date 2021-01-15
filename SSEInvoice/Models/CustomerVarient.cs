using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models
{
    public class CustomerVarient
    {
        [Key]
        public int CustomerVarientVM_Id { get; set; }
        [Required]
        public string InvoiceNo { get; set; }
        [Required]
        public long Quantity { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Varient")]
        public int VarientId { get; set; }
        public Varient Varient { get; set; }



    }
}
