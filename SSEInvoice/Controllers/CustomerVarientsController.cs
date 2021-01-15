using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSEInvoice.Data;
using SSEInvoice.Models;

namespace SSEInvoice.Controllers
{
    public class CustomerVarientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerVarientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerVarients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CustomerVarients.Include(c => c.Customer).Include(c => c.Varient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CustomerVarients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerVarient = await _context.CustomerVarients
                .Include(c => c.Customer)
                .Include(c => c.Varient)
                .FirstOrDefaultAsync(m => m.CustomerVarientVM_Id == id);
            if (customerVarient == null)
            {
                return NotFound();
            }

            return View(customerVarient);
        }

        // GET: CustomerVarients/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewData["VarientId"] = new SelectList(_context.Varients, "VarientId", "Size");
            return View();
        }

        // POST: CustomerVarients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerVarientVM_Id,InvoiceNo,Quantity,Description,CustomerId,VarientId")] CustomerVarient customerVarient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerVarient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", customerVarient.CustomerId);
            ViewData["VarientId"] = new SelectList(_context.Varients, "VarientId", "Size", customerVarient.VarientId);
            return View(customerVarient);
        }

        // GET: CustomerVarients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerVarient = await _context.CustomerVarients.FindAsync(id);
            if (customerVarient == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", customerVarient.CustomerId);
            ViewData["VarientId"] = new SelectList(_context.Varients, "VarientId", "Size", customerVarient.VarientId);
            return View(customerVarient);
        }

        // POST: CustomerVarients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerVarientVM_Id,InvoiceNo,Quantity,Description,CustomerId,VarientId")] CustomerVarient customerVarient)
        {
            if (id != customerVarient.CustomerVarientVM_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerVarient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerVarientExists(customerVarient.CustomerVarientVM_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", customerVarient.CustomerId);
            ViewData["VarientId"] = new SelectList(_context.Varients, "VarientId", "Size", customerVarient.VarientId);
            return View(customerVarient);
        }

        // GET: CustomerVarients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerVarient = await _context.CustomerVarients
                .Include(c => c.Customer)
                .Include(c => c.Varient)
                .FirstOrDefaultAsync(m => m.CustomerVarientVM_Id == id);
            if (customerVarient == null)
            {
                return NotFound();
            }

            return View(customerVarient);
        }

        // POST: CustomerVarients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerVarient = await _context.CustomerVarients.FindAsync(id);
            _context.CustomerVarients.Remove(customerVarient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerVarientExists(int id)
        {
            return _context.CustomerVarients.Any(e => e.CustomerVarientVM_Id == id);
        }
    }
}
