using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WarehouseMonitoring.Context;
using WarehouseMonitoring.Models;

namespace WarehouseMonitoring.Controllers
{
    public class RoomDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RoomDetails
        public async Task<IActionResult> Index()
        {
            //var responseMessage = new List<String>();
            //responseMessage.Add("Please Increase temperature with ");
            //responseMessage.Add("Please Increase temperature with ");

            //TempData["MessageList"] = responseMessage;


            var applicationDbContext = _context.RoomDetails.Include(r => r.Room);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RoomDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomDetails == null)
            {
                return NotFound();
            }

            var roomDetail = await _context.RoomDetails
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomDetail == null)
            {
                return NotFound();
            }

            return View(roomDetail);
        }

        // GET: RoomDetails/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");
            return View();
        }

        // POST: RoomDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomId,Tempreature,Humidity,CreateDateTime")] RoomDetail roomDetail)
        {
            if (ModelState.IsValid)
            {
                roomDetail.CreateDateTime = DateTime.Now;
                _context.Add(roomDetail);
                await _context.SaveChangesAsync();


                var messages = CheckRoomItemStatus(roomDetail);

                //TempData["Test"] = "aaaaa";

                if (messages.Count > 0)
                {
                    TempData["Message"] = String.Join(" </br> ",messages);
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", roomDetail.RoomId);
            return View(roomDetail);
        }

        // GET: RoomDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomDetails == null)
            {
                return NotFound();
            }

            var roomDetail = await _context.RoomDetails.FindAsync(id);
            if (roomDetail == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", roomDetail.RoomId);
            return View(roomDetail);
        }

        // POST: RoomDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomId,Tempreature,Humidity,CreateDateTime")] RoomDetail roomDetail)
        {
            if (id != roomDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomDetailExists(roomDetail.Id))
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
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", roomDetail.RoomId);
            return View(roomDetail);
        }

        // GET: RoomDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomDetails == null)
            {
                return NotFound();
            }

            var roomDetail = await _context.RoomDetails
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomDetail == null)
            {
                return NotFound();
            }

            return View(roomDetail);
        }

        // POST: RoomDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RoomDetails'  is null.");
            }
            var roomDetail = await _context.RoomDetails.FindAsync(id);
            if (roomDetail != null)
            {
                _context.RoomDetails.Remove(roomDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomDetailExists(int id)
        {
          return (_context.RoomDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        private List<string> CheckRoomItemStatus(RoomDetail roomDetail)
        {
            var responseMessage = new List<String>();

            var roomItems =  _context.Harvests.Where(x=>x.RoomId ==  roomDetail.RoomId).ToList();
            
            foreach (var roomItem in roomItems)
            {
                var cropDetails = _context.CroupTypes.Find(roomItem.CroupTypeId);
                var havest = _context.Harvests.FirstOrDefault(x=>x.CroupTypeId == cropDetails.Id);

                TempData["room"] = _context.Rooms.FirstOrDefault(f=>f.Id == roomDetail.RoomId)?.Name;

                TempData["crop"] = cropDetails.Name;

                TempData["MinTempreature"] = cropDetails.MinTemperature.ToString();
                TempData["MaxTempreature"] = cropDetails.MaxTemperature.ToString();

                TempData["MinHumidity"] = cropDetails.MinHumidity.ToString();
                TempData["MaxHumidity"] = cropDetails.MaxHumidity.ToString();

                
                TempData["Storage"] = cropDetails.MaxStorageLife.ToString();

                TempData["Tempreature"] = roomDetail.Tempreature.ToString();
                TempData["Humidity"] = roomDetail.Humidity.ToString();
                TempData["Date"] = havest.DateOfStorage.AddDays((cropDetails.MaxStorageLife)-1).ToShortDateString();



                if (cropDetails != null)
                {
                    responseMessage.Add("Your Current Tempreature is <span class=\"change-value\">" + roomDetail.Tempreature + "</span>");
                    responseMessage.Add("Your Current Humidity is <span class=\"change-value\">" + roomDetail.Humidity + "</span>");
                    if (roomDetail.Tempreature < cropDetails.MinTemperature)
                    {
                        responseMessage.Add("Please Increase temperature with <span class=\"change-value\">" + (cropDetails.MinTemperature - roomDetail.Tempreature) + "</span> digits");
                    }

                    if (roomDetail.Tempreature > cropDetails.MaxTemperature)
                    {
                        responseMessage.Add("Please decrease temperature with <span class=\"change-value\">" + (cropDetails.MinTemperature - roomDetail.Tempreature) + "</span> digits");
                    }

                    if (roomDetail.Humidity < cropDetails.MinHumidity)
                    {
                        responseMessage.Add("Please Increase Humidity with <span class=\"change-value\">" + (cropDetails.MinHumidity - roomDetail.Humidity) + "</span> digits");
                    }

                    if (roomDetail.Humidity > cropDetails.MaxHumidity)
                    {
                        responseMessage.Add("Please decrease Humidity with <span class=\"change-value\">" + (cropDetails.MinHumidity - roomDetail.Humidity) + "</span> digits");
                    }

                    if(roomDetail.Tempreature <= cropDetails.FreezingPoint)
                    {
                        responseMessage.Add("<span class=\"change-danger\">Stock should be release. because Freezing Point reached</span>");
                    }
                }
            }


            return responseMessage;
        }

        public IActionResult FromHomeCreate()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");
            return PartialView("_RoomDetailsFromHome");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FromHomeCreate([Bind("Id,RoomId,Tempreature,Humidity,CreateDateTime")] RoomDetail roomDetail)
        {
            if (ModelState.IsValid)
            {
                roomDetail.CreateDateTime = DateTime.Now;
                _context.Add(roomDetail);
                await _context.SaveChangesAsync();


                var messages = CheckRoomItemStatus(roomDetail);

                //TempData["Test"] = "aaaaa";

                if (messages.Count > 0)
                {
                    TempData["Message"] = String.Join(" </br> ", messages);
                }

                
            }
            return RedirectToAction("Index","Home");

        }
    }
}
