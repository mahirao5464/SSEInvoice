using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSEInvoice.Data;
using SSEInvoice.Models;
using SSEInvoice.Models.ViewModels;
using SSEInvoice.Utilies;

namespace SSEInvoice.Controllers
{
    [Authorize]

    public class QuotationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuotationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Quotations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Quotations.Include(q => q.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult FindBillingAddress(int? CustomerId)
        {
            if (CustomerId == null)
            {
                return BadRequest();
            }
            var BusinessStateCode = _context.BusinessDetails.Include(el => el.Address).FirstOrDefault().Address.StateCode;
            var customerAdd = _context.Customers.Include(el => el.PermanentAddress).FirstOrDefault(el => el.CustomerId == CustomerId).PermanentAddress;

            return Json( new { BillingAddress = customerAdd, IsOnlyCGST = BusinessStateCode!= customerAdd.StateCode });
        }

        // GET: Quotations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotations
                .Include(q => q.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quotation == null)
            {
                return NotFound();
            }

            return View(quotation);
        }

        // GET: Quotations/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            var selectListGroup = _context.Product.Select(el => new SelectListGroup() { Name = el.ProductName });
            var selectlist = _context.Varients.Include(el => el.Product).Select(el => new SelectListItem()
            {
                Text = el.VarientName,
                Value = el.VarientId.ToString(),
                Group = selectListGroup.FirstOrDefault(elg=>elg.Name == el.Product.ProductName)
            });
            ViewData["ProductList"] = selectlist;
            return View();
        }
        public IActionResult GetUnit(int? VarientId)
        {
            if (VarientId == null)
            {
                return BadRequest();
            }
           var varient = _context.Varients.Include(el => el.Unit).Include(el =>el.Product).FirstOrDefault(el=>el.VarientId == VarientId);
            return Json(new { VarientDetail = varient});
        }

        // POST: Quotations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId", "CustomVarient", "BillingTo", "BillingAddressString", "ShippingCharges")]   Quotation quotation)
        {
            
            if (ModelState.IsValid)
            {
                Utility.CalculateAmountAndTax(quotation);
                quotation.CreatedOn = DateTime.Now;
                _context.Add(quotation);
                int id = await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", quotation.CustomerId);
            return View(quotation);
        }

        // GET: Quotations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var quotation = await _context.Quotations.Include(el=>el.CustomVarient).ThenInclude(el=>el.Varient).ThenInclude(el=>el.Product).FirstOrDefaultAsync(el=>el.Id == id);
            if (quotation == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", quotation.CustomerId);
            var selectListGroup = _context.Product.Select(el => new SelectListGroup() { Name = el.ProductName });
            var selectlist = _context.Varients.Include(el => el.Product).Select(el => new SelectListItem()
            {
                Text = el.VarientName,
                Value = el.VarientId.ToString(),
                Group = selectListGroup.FirstOrDefault(elg => elg.Name == el.Product.ProductName)
            });
            ViewData["ProductList"] = selectlist;
            return View(quotation);
        }
        public async Task<IActionResult> Print(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            var quotation = await _context.Quotations.Include(el=>el.Customer).ThenInclude(el=>el.PermanentAddress).Include(el => el.CustomVarient).ThenInclude(el => el.Varient).ThenInclude(el => el.Product).FirstOrDefaultAsync(el => el.Id == id);
            if (quotation == null)
            {
                return NotFound();
            }
            var QuoteViewModel = new QuotViewModels()
            {
                Quotation = quotation,
                BusinessDetails = _context.BusinessDetails.Include(el => el.Address).Include(el => el.BankDetail),
                PrintedOn = DateTime.Now
            };
            
            
            return View(QuoteViewModel);
        }
        [Route("~/Invoice/Print/{id}")]
        public async Task<IActionResult> PrintInvoice(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var quotation = await _context.Quotations.Include(el => el.Customer).ThenInclude(el => el.PermanentAddress).Include(el => el.CustomVarient).ThenInclude(el => el.Varient).ThenInclude(el => el.Product).FirstOrDefaultAsync(el => el.Id == id);
            if (quotation == null)
            {
                return NotFound();
            }
            var QuoteViewModel = new QuotViewModels()
            {
                Quotation = quotation,
                BusinessDetails = _context.BusinessDetails.Include(el => el.Address).Include(el => el.BankDetail),
                PrintedOn = DateTime.Now
            };


            return View("PrintInvoice", QuoteViewModel);
        }

        public ActionResult LoadCustomVarient(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // logic
            // Edit you don't need to serialize it just return the object
            Quotation quotation = _context.Quotations.Include(el => el.CustomVarient).ThenInclude(el => el.Varient).ThenInclude(el => el.Product).FirstOrDefault(el => el.Id == id);
            //push({
            //    "VarientId": VarientId,
            //        "Count": Count,
            //        "CustomPrice": CustomPrice,
            //        "Cgst": CgstAmount,
            //        "Sgst": SgstAmount,
            //        "IsOnlyCgst": true
            //    });

            IList<CustomVarient> varients = new List<CustomVarient>();
            foreach(var cVarient in quotation.CustomVarient)
            {
                var tempVarient = new CustomVarient()
                {
                    Id = cVarient.Id,
                    Cgst = cVarient.Cgst,
                    Count = cVarient.Count,
                    CustomePrice = cVarient.CustomePrice,
                    IsCgstOnly = cVarient.IsCgstOnly,
                    Sgst = cVarient.Sgst,
                    VarientId = cVarient.VarientId
                };
                varients.Add(tempVarient);
                tempVarient = null;

            }
            return Json(varients);
        }


        // POST: Quotations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Quotation quotation)
        {
            if (id != quotation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var qcust = quotation.CustomVarient.Select(el => el.Id);
                    var toRemove = _context.Quotations.AsNoTracking().Include(el => el.CustomVarient).FirstOrDefault(el => el.Id == quotation.Id).CustomVarient?.Where(el => !qcust.Contains(el.Id)).Select(el=>el.Id); 
                   _context.Update(quotation);
                   
                    if (toRemove != null)
                    {
                        var toRemoveAgain = _context.CustomVarients.Where(el=> toRemove.Contains(el.Id));
                        _context.RemoveRange(toRemoveAgain);
                    }
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuotationExists(quotation.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", quotation.CustomerId);
            return View(quotation);
        }

        // GET: Quotations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotations
                .Include(q => q.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quotation == null)
            {
                return NotFound();
            }

            return View(quotation);
        }

        // POST: Quotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quotation = await _context.Quotations.FindAsync(id);
            _context.Quotations.Remove(quotation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuotationExists(int id)
        {
            return _context.Quotations.Any(e => e.Id == id);
        }
    }
}
