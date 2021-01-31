using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models.ViewModels
{
    public class QuotViewModels
    {
        public Quotation Quotation { get; set; }
        public IEnumerable<BusinessDetails> BusinessDetails { get; set; }
        public DateTime PrintedOn { get; set; } = DateTime.Now;
    }
}
