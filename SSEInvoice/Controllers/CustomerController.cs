using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSEInvoice.Data;
using SSEInvoice.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SSEInvoice.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private ApplicationDbContext _db;

        public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer pCustomer)
        {
            _db.Customers.Add(pCustomer);
            _db.SaveChanges();
            return View(pCustomer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
