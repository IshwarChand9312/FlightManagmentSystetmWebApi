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
    public class IUserController : ControllerBase
    {
        private readonly ACE42023Context _context;

        public IUserController(ACE42023Context context)
        {
            _context = context;
        }

        // GET: api/IUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IUser>>> GetIUsers()
        {
            return await _context.IUsers.ToListAsync();
        }

        // GET: api/IUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IUser>> GetIUser(int id)
        {
            var iUser = await _context.IUsers.FindAsync(id);

            if (iUser == null)
            {
                return NotFound();
            }

            return iUser;
        }

        // PUT: api/IUser/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIUser(int id, IUser iUser)
        {
            if (id != iUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(iUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IUserExists(id))
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

        // POST: api/IUser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IUser>> PostIUser(IUser iUser)
        {
            _context.IUsers.Add(iUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IUserExists(iUser.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIUser", new { id = iUser.UserId }, iUser);
        }

        // DELETE: api/IUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIUser(int id)
        {
            var iUser = await _context.IUsers.FindAsync(id);
            if (iUser == null)
            {
                return NotFound();
            }

            _context.IUsers.Remove(iUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IUserExists(int id)
        {
            return _context.IUsers.Any(e => e.UserId == id);
        }
    }
}
