using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fmsapi.Models;

namespace fmsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IBookingController : ControllerBase
    {
        private readonly ACE42023Context _context;

        public IBookingController(ACE42023Context context)
        {
            _context = context;
        }

        // GET: api/IBooking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IBooking>>> GetIBookings()
        {
            return await _context.IBookings.ToListAsync();
        }

        // GET: api/IBooking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IBooking>> GetIBooking(int id)
        {
            var iBooking = await _context.IBookings.FindAsync(id);

            if (iBooking == null)
            {
                return NotFound();
            }

            return iBooking;
        }

        // PUT: api/IBooking/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIBooking(int id, IBooking iBooking)
        {
            if (id != iBooking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(iBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IBookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IBooking
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IBooking>> PostIBooking(IBooking iBooking)
        {
            _context.IBookings.Add(iBooking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IBookingExists(iBooking.BookingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIBooking", new { id = iBooking.BookingId }, iBooking);
        }

        // DELETE: api/IBooking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIBooking(int id)
        {
            var iBooking = await _context.IBookings.FindAsync(id);
            if (iBooking == null)
            {
                return NotFound();
            }

            _context.IBookings.Remove(iBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IBookingExists(int id)
        {
            return _context.IBookings.Any(e => e.BookingId == id);
        }
    }
}
