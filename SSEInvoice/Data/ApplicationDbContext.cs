using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSEInvoice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEInvoice.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Varient> Varients { get; set; }


    }
}
