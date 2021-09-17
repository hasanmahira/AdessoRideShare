using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdessoRideShare.Models;

namespace AdessoRideShare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedRidesController : ControllerBase
    {
        private readonly RideShareContext _context;

        public SharedRidesController(RideShareContext context)
        {
            _context = context;
        }

        // GET: api/SharedRides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SharedRides>>> GetSharedRides()
        {
            return await _context.SharedRides.ToListAsync();
        }

        // GET: api/SharedRides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SharedRides>> GetSharedRides(long id)
        {
            var sharedRides = await _context.SharedRides.FindAsync(id);

            if (sharedRides == null)
            {
                return NotFound();
            }

            return sharedRides;
        }

        // PUT: api/SharedRides/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSharedRides(long id, SharedRides sharedRides)
        {
            if (id != sharedRides.Id)
            {
                return BadRequest();
            }

            _context.Entry(sharedRides).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SharedRidesExists(id))
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

        // POST: api/SharedRides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SharedRides>> PostSharedRides(SharedRides sharedRides)
        {
            var count = _context.SharedRides.Where(x => x.RidePlanId == sharedRides.RidePlanId).Count();
            var limit = _context.RidePlans.Find(sharedRides.RidePlanId).NumberOfSeats;

            if (count <= limit)
            {
                _context.SharedRides.Add(sharedRides);
                await _context.SaveChangesAsync();

                //return CreatedAtAction("GetSharedRides", new { id = sharedRides.Id }, sharedRides);
                return CreatedAtAction(nameof(GetSharedRides), new { id = sharedRides.Id }, sharedRides);
            }

            return sharedRides;

        }

        // DELETE: api/SharedRides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSharedRides(long id)
        {
            var sharedRides = await _context.SharedRides.FindAsync(id);
            if (sharedRides == null)
            {
                return NotFound();
            }

            _context.SharedRides.Remove(sharedRides);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SharedRidesExists(long id)
        {
            return _context.SharedRides.Any(e => e.Id == id);
        }
    }
}
