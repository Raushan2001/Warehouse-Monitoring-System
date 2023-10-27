using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WarehouseMonitoring.Context;
using WarehouseMonitoring.Models;

namespace WarehouseMonitoring.Controllers
{
    public class CroupTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CroupTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CroupTypes
        public async Task<IActionResult> Index()
        {
              return _context.CroupTypes != null ? 
                          View(await _context.CroupTypes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CroupTypes'  is null.");
        }

        // GET: CroupTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CroupTypes == null)
            {
                return NotFound();
            }

            var croupType = await _context.CroupTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (croupType == null)
            {
                return NotFound();
            }

            return View(croupType);
        }

        // GET: CroupTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CroupTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,MinStorageLife,MaxStorageLife,FreezingPoint,MinTemperature,MaxTemperature,MinHumidity,MaxHumidity")] CroupType croupType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(croupType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(croupType);
        }

        // GET: CroupTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CroupTypes == null)
            {
                return NotFound();
            }

            var croupType = await _context.CroupTypes.FindAsync(id);
            if (croupType == null)
            {
                return NotFound();
            }
            return View(croupType);
        }

        // POST: CroupTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MinStorageLife,MaxStorageLife,FreezingPoint,MinTemperature,MaxTemperature,MinHumidity,MaxHumidity")] CroupType croupType)
        {
            if (id != croupType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(croupType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CroupTypeExists(croupType.Id))
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
            return View(croupType);
        }

        // GET: CroupTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CroupTypes == null)
            {
                return NotFound();
            }

            var croupType = await _context.CroupTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (croupType == null)
            {
                return NotFound();
            }

            return View(croupType);
        }

        // POST: CroupTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CroupTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CroupTypes'  is null.");
            }
            var croupType = await _context.CroupTypes.FindAsync(id);
            if (croupType != null)
            {
                _context.CroupTypes.Remove(croupType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CroupTypeExists(int id)
        {
          return (_context.CroupTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
