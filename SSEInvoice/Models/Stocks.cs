using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models
{
    public class Stocks
    {
        [Key]
        public int StocksId { get; set; }
        [Required]
        public double Quantity { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Varient")]
        public int VarientId{ get; set; }
        public virtual Varient Varient { get; set; }
    }
}
