using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenThanhSang505;
using NguyenThanhSang505.Data;

namespace NguyenThanhSang505.Controllers
{
    public class CompanyNTS505Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyNTS505Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyNTS505
        public async Task<IActionResult> Index()
        {
              return _context.CompanyNTS505s != null ? 
                          View(await _context.CompanyNTS505s.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CompanyNTS505s'  is null.");
        }

        // GET: CompanyNTS505/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CompanyNTS505s == null)
            {
                return NotFound();
            }

            var companyNTS505 = await _context.CompanyNTS505s
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (companyNTS505 == null)
            {
                return NotFound();
            }

            return View(companyNTS505);
        }

        // GET: CompanyNTS505/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyNTS505/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,CompanyName")] CompanyNTS505 companyNTS505)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyNTS505);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyNTS505);
        }

        // GET: CompanyNTS505/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CompanyNTS505s == null)
            {
                return NotFound();
            }

            var companyNTS505 = await _context.CompanyNTS505s.FindAsync(id);
            if (companyNTS505 == null)
            {
                return NotFound();
            }
            return View(companyNTS505);
        }

        // POST: CompanyNTS505/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CompanyId,CompanyName")] CompanyNTS505 companyNTS505)
        {
            if (id != companyNTS505.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyNTS505);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyNTS505Exists(companyNTS505.CompanyId))
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
            return View(companyNTS505);
        }

        // GET: CompanyNTS505/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CompanyNTS505s == null)
            {
                return NotFound();
            }

            var companyNTS505 = await _context.CompanyNTS505s
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (companyNTS505 == null)
            {
                return NotFound();
            }

            return View(companyNTS505);
        }

        // POST: CompanyNTS505/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CompanyNTS505s == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CompanyNTS505s'  is null.");
            }
            var companyNTS505 = await _context.CompanyNTS505s.FindAsync(id);
            if (companyNTS505 != null)
            {
                _context.CompanyNTS505s.Remove(companyNTS505);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyNTS505Exists(string id)
        {
          return (_context.CompanyNTS505s?.Any(e => e.CompanyId == id)).GetValueOrDefault();
        }
    }
}
