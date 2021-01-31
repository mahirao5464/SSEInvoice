using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Models
{
    public class BusinessDetails
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Address")]
        public int BusinessAddress { get; set; }
        public virtual Address Address { get; set; }
        [Required]
        public string GSTNumber { get; set; }
        public BankDetail BankDetail { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        

    }
    public class BankDetail 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string IFSC { get; set; }
        [Required]
        public string AccountNumber { get; set; }


    }
}
