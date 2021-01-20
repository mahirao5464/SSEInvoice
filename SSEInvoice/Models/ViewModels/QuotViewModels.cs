using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models.ViewModels
{
    public class QuotViewModels
    {
        public ICollection<Product> Products { get; set; }
        public int ProductId { get; set; }
        public ICollection<Varient> Varients { get; set; }
        public int VarientId { get; set; }
    }
}
