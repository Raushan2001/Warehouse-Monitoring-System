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
    public class HarvestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HarvestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Harvests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Harvests.Include(h => h.CroupType).Include(h => h.Room);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Harvests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Harvests == null)
            {
                return NotFound();
            }

            var harvest = await _context.Harvests
                .Include(h => h.CroupType)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harvest == null)
            {
                return NotFound();
            }

            return View(harvest);
        }

        // GET: Harvests/Create
        public IActionResult Create()
        {
            ViewData["CroupTypeId"] = new SelectList(_context.CroupTypes, "Id", "Name");
            ViewData["RoomId"] = new SelectList(_context.Rooms.Where(x=>x.IsRoomUse != true).ToList(), "Id", "Name");
            return View();
        }

        // POST: Harvests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CroupTypeId,RoomId,DateOfStorage,Quantity")] Harvest harvest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(harvest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CroupTypeId"] = new SelectList(_context.CroupTypes, "Id", "Name", harvest.CroupTypeId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", harvest.RoomId);
            return View(harvest);
        }

        // GET: Harvests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Harvests == null)
            {
                return NotFound();
            }

            var harvest = await _context.Harvests.FindAsync(id);
            if (harvest == null)
            {
                return NotFound();
            }
            ViewData["CroupTypeId"] = new SelectList(_context.CroupTypes, "Id", "Name", harvest.CroupTypeId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", harvest.RoomId);
            return View(harvest);
        }

        // POST: Harvests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CroupTypeId,RoomId,DateOfStorage,Quantity")] Harvest harvest)
        {
            if (id != harvest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(harvest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HarvestExists(harvest.Id))
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
            ViewData["CroupTypeId"] = new SelectList(_context.CroupTypes, "Id", "Name", harvest.CroupTypeId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", harvest.RoomId);
            return View(harvest);
        }

        // GET: Harvests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Harvests == null)
            {
                return NotFound();
            }

            var harvest = await _context.Harvests
                .Include(h => h.CroupType)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harvest == null)
            {
                return NotFound();
            }

            return View(harvest);
        }

        // POST: Harvests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Harvests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Harvests'  is null.");
            }
            var harvest = await _context.Harvests.FindAsync(id);
            if (harvest != null)
            {
                _context.Harvests.Remove(harvest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HarvestExists(int id)
        {
          return (_context.Harvests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
