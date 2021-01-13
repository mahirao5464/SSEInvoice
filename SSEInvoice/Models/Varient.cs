using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models
{
    public class Varient
    {
        [Key]
        public int VarientId { get; set; }
        [Required]
        public string VarientName { get; set; }
        [Required]
        public long Price { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public int SGST { get; set; }
        [Required]
        public int CGST { get; set; }

        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
       
    }
}
