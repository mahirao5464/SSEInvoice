using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models
{
    public class Stocks
    {
        [Key]
        public int StocksId { get; set; }
        [Required]
        public long Quantity { get; set; }

        public Product Product { get; set; }

    }
}
