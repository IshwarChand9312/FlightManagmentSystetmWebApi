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
    public class IFlightController : ControllerBase
    {
        private readonly ACE42023Context _context;

        public IFlightController(ACE42023Context context)
        {
            _context = context;
        }

        // GET: api/IFlight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IFlight>>> GetIFlights()
        {
            return await _context.IFlights.ToListAsync();
        }

        // GET: api/IFlight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IFlight>> GetIFlight(int id)
        {
            var iFlight = await _context.IFlights.FindAsync(id);

            if (iFlight == null)
            {
                return NotFound();
            }

            return iFlight;
        }

        // PUT: api/IFlight/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIFlight(int id, IFlight iFlight)
        {
            if (id != iFlight.FlightId)
            {
                return BadRequest();
            }

            _context.Entry(iFlight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IFlightExists(id))
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

        // POST: api/IFlight
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IFlight>> PostIFlight(IFlight iFlight)
        {
            _context.IFlights.Add(iFlight);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IFlightExists(iFlight.FlightId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIFlight", new { id = iFlight.FlightId }, iFlight);
        }

        // DELETE: api/IFlight/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIFlight(int id)
        {
            var iFlight = await _context.IFlights.FindAsync(id);
            if (iFlight == null)
            {
                return NotFound();
            }

            _context.IFlights.Remove(iFlight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IFlightExists(int id)
        {
            return _context.IFlights.Any(e => e.FlightId == id);
        }
    }
}
