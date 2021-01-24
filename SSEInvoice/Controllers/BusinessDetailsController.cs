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
    public class BusinessDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusinessDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.BusinessDetails.ToListAsync());
        }

        // GET: BusinessDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessDetails = await _context.BusinessDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessDetails == null)
            {
                return NotFound();
            }

            return View(businessDetails);
        }

        // GET: BusinessDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BusinessAddress,GSTNumber,Address,BankDetail")] BusinessDetails businessDetails)
        {
            if (ModelState.IsValid)
            {
                businessDetails.CreatedOn = DateTime.Now;
                _context.Add(businessDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessDetails);
        }

        // GET: BusinessDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessDetails = await _context.BusinessDetails.Include(el=>el.Address).Include(el=>el.BankDetail).FirstOrDefaultAsync(el=>el.Id == id);
            if (businessDetails == null)
            {
                return NotFound();
            }
            return View(businessDetails);
        }

        // POST: BusinessDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusinessAddress,GSTNumber,Address,BankDetail")] BusinessDetails businessDetails)
        {
            if (id != businessDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessDetailsExists(businessDetails.Id))
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
            return View(businessDetails);
        }

        // GET: BusinessDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessDetails = await _context.BusinessDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessDetails == null)
            {
                return NotFound();
            }

            return View(businessDetails);
        }

        // POST: BusinessDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessDetails = await _context.BusinessDetails.FindAsync(id);
            _context.BusinessDetails.Remove(businessDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessDetailsExists(int id)
        {
            return _context.BusinessDetails.Any(e => e.Id == id);
        }
    }
}
