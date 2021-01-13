using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
