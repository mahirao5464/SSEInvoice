using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }
        [Required]
        public string UnitName { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
