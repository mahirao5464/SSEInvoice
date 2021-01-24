using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSEInvoice.Data;
using SSEInvoice.Models;

namespace SSEInvoice.Controllers
{
    [Authorize]
    public class VarientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VarientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Varients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Varients.Include(v => v.Product).Include(v => v.Unit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Varients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varient = await _context.Varients
                .Include(v => v.Product)
                .Include(v => v.Unit)
                .FirstOrDefaultAsync(m => m.VarientId == id);
            if (varient == null)
            {
                return NotFound();
            }

            return View(varient);
        }

        // GET: Varients/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName");
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName");
            return View();
        }

        // POST: Varients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VarientId,VarientName,Price,Size,SGST,CGST,UnitId,ProductId")] Varient varient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(varient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", varient.ProductId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName", varient.UnitId);
            return View(varient);
        }

        // GET: Varients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varient = await _context.Varients.FindAsync(id);
            if (varient == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", varient.ProductId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName", varient.UnitId);
            return View(varient);
        }

        // POST: Varients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VarientId,VarientName,Price,Size,SGST,CGST,UnitId,ProductId")] Varient varient)
        {
            if (id != varient.VarientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(varient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VarientExists(varient.VarientId))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", varient.ProductId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName", varient.UnitId);
            return View(varient);
        }

        // GET: Varients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varient = await _context.Varients
                .Include(v => v.Product)
                .Include(v => v.Unit)
                .FirstOrDefaultAsync(m => m.VarientId == id);
            if (varient == null)
            {
                return NotFound();
            }

            return View(varient);
        }

        // POST: Varients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var varient = await _context.Varients.FindAsync(id);
            _context.Varients.Remove(varient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VarientExists(int id)
        {
            return _context.Varients.Any(e => e.VarientId == id);
        }
    }
}
