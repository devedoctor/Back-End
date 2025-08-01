using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers

{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly HotelDbContext _context;

        public BookingController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: Booking
        public async Task<IActionResult> Index(string searchString)
        {
            var bookings = _context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                bookings = bookings.Where(b =>
                    b.Guest.FirstName.Contains(searchString) ||
                    b.Guest.LastName.Contains(searchString) ||
                    b.Room.RoomNumber.Contains(searchString));
            }

            return View(await bookings.ToListAsync());
        }

        // GET: Booking/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Guests = await _context.Guests.ToListAsync();
            ViewBag.Rooms = await _context.Rooms.Where(r => r.IsAvailable).ToListAsync();
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,GuestId,RoomId,CheckInDate,CheckOutDate,TotalAmount,BookingStatus,PaymentStatus,SpecialRequests")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                // Calculate total amount based on room price and duration
                var room = await _context.Rooms.FindAsync(booking.RoomId);
                var duration = (booking.CheckOutDate - booking.CheckInDate).Days;
                booking.TotalAmount = room.PricePerNight * duration;

                _context.Add(booking);
                await _context.SaveChangesAsync();

                // Update room availability
                room.IsAvailable = false;
                _context.Update(room);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Guests = await _context.Guests.ToListAsync();
            ViewBag.Rooms = await _context.Rooms.Where(r => r.IsAvailable).ToListAsync();
            return View(booking);
        }

        // GET: Booking/CheckOut/5
        public async Task<IActionResult> CheckOut(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Booking/CheckOut/5
        [HttpPost, ActionName("CheckOut")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOutConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            booking.BookingStatus = "Completed";
            booking.PaymentStatus = "Paid";
            _context.Update(booking);

            // Make room available again
            var room = await _context.Rooms.FindAsync(booking.RoomId);
            room.IsAvailable = true;
            _context.Update(room);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Booking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Booking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);

            // Make room available again if booking is deleted
            var room = await _context.Rooms.FindAsync(booking.RoomId);
            room.IsAvailable = true;
            _context.Update(room);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}