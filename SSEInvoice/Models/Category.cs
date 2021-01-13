using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Column("Name")]
        [Required]
        public string CategoryName { get; set; }
       [Required]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
