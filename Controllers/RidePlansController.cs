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
    public class RidePlansController : ControllerBase
    {
        private readonly RideShareContext _context;

        public RidePlansController(RideShareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RidePlan>>> GetRidePlans()
        {
            return await _context.RidePlans.ToListAsync();
        }

        [HttpGet("{from},{where}")]
        public async Task<ActionResult<IEnumerable<RidePlan>>> GetAllPublishedRidePlans(string from, string where)
        {
            return await _context.RidePlans.Where(x => x.From.Name.ToLower() == from.ToLower() && x.Where.Name.ToLower() == where.ToLower()).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RidePlan>> GetRidePlan(long id)
        {
            var ridePlan = await _context.RidePlans.FindAsync(id);

            if (ridePlan == null)
            {
                return NotFound();
            }

            return ridePlan;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRidePlan(long id, RidePlan ridePlan)
        {
            if (id != ridePlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(ridePlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RidePlanExists(id))
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


        [HttpPut("{rideId}")]
        public async Task<IActionResult> PublishRidePlan(long id)
        {
            RidePlan ridePlan = _context.RidePlans.Find(id);

            if (ridePlan.IsPublished != true)
            {
                ridePlan.IsPublished = true;
            }
            else
            {
                ridePlan.IsPublished = false;
            }

            _context.Entry(ridePlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RidePlanExists(id))
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


        [HttpPost]
        public async Task<ActionResult<RidePlan>> PostRidePlan(RidePlan ridePlan)
        {
            _context.RidePlans.Add(ridePlan);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetRidePlan", new { id = ridePlan.Id }, ridePlan);
            return CreatedAtAction(nameof(GetRidePlan), new { id = ridePlan.Id }, ridePlan);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRidePlan(long id)
        {
            var ridePlan = await _context.RidePlans.FindAsync(id);
            if (ridePlan == null)
            {
                return NotFound();
            }

            _context.RidePlans.Remove(ridePlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RidePlanExists(long id)
        {
            return _context.RidePlans.Any(e => e.Id == id);
        }
    }
}
