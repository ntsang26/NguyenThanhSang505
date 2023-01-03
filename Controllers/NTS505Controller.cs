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
    public class NTS505Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public NTS505Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NTS505
        public async Task<IActionResult> Index()
        {
              return _context.NTS505s != null ? 
                          View(await _context.NTS505s.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NTS505s'  is null.");
        }

        // GET: NTS505/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NTS505s == null)
            {
                return NotFound();
            }

            var nTS505 = await _context.NTS505s
                .FirstOrDefaultAsync(m => m.NTSId == id);
            if (nTS505 == null)
            {
                return NotFound();
            }

            return View(nTS505);
        }

        // GET: NTS505/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NTS505/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NTSId,NTSName,NTSGender")] NTS505 nTS505)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nTS505);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nTS505);
        }

        // GET: NTS505/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NTS505s == null)
            {
                return NotFound();
            }

            var nTS505 = await _context.NTS505s.FindAsync(id);
            if (nTS505 == null)
            {
                return NotFound();
            }
            return View(nTS505);
        }

        // POST: NTS505/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NTSId,NTSName,NTSGender")] NTS505 nTS505)
        {
            if (id != nTS505.NTSId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nTS505);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NTS505Exists(nTS505.NTSId))
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
            return View(nTS505);
        }

        // GET: NTS505/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NTS505s == null)
            {
                return NotFound();
            }

            var nTS505 = await _context.NTS505s
                .FirstOrDefaultAsync(m => m.NTSId == id);
            if (nTS505 == null)
            {
                return NotFound();
            }

            return View(nTS505);
        }

        // POST: NTS505/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NTS505s == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NTS505s'  is null.");
            }
            var nTS505 = await _context.NTS505s.FindAsync(id);
            if (nTS505 != null)
            {
                _context.NTS505s.Remove(nTS505);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NTS505Exists(string id)
        {
          return (_context.NTS505s?.Any(e => e.NTSId == id)).GetValueOrDefault();
        }
    }
}
