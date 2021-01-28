using SSEInvoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Utilies
{
    public static class Utility
    {
        public static void CalculateAmountAndTax(Quotation quotation)
        {
            if (quotation != null)
            {
                quotation.SubTotal = quotation.CustomVarient.Sum(el=>el.CustomePrice);
                quotation.TotalTax = quotation.CustomVarient.Sum(el=>el.Cgst+el.Sgst);
                quotation.TotalAmount = quotation.SubTotal + quotation.TotalTax + quotation.ShippingCharges;
            }
        }
    }
}
