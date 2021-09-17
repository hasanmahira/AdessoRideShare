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
        private async Task<ActionResult<IEnumerable<RidePlan>>> GetRidePlans()
        {
            return await _context.RidePlans.ToListAsync();
        }

        [HttpGet("{from},{where}")]
        public async Task<ActionResult<IEnumerable<RidePlan>>> GetAllPublishedRidePlans(string from, string where)
        {
            return await _context.RidePlans.Where(x => x.From.Name.ToLower() == from.ToLower() && x.Where.Name.ToLower() == where.ToLower()).ToListAsync();
        }

        [HttpGet("{id}")]
        private async Task<ActionResult<RidePlan>> GetRidePlan(long id)
        {
            var ridePlan = await _context.RidePlans.FindAsync(id);

            if (ridePlan == null)
            {
                return NotFound();
            }

            return ridePlan;
        }

        [HttpPut("{id}")]
        private async Task<IActionResult> PutRidePlan(long id, RidePlan ridePlan)
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


        [HttpPut("{publishRideId}")]
        public async Task<IActionResult> PublishRidePlan(long publishRideId)
        {
            RidePlan ridePlan = _context.RidePlans.Find(publishRideId);

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
                if (!RidePlanExists(publishRideId))
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

            List<Cities> possibleRoute = await GetTravelRoute(ridePlan.FromId, ridePlan.WhereId);

            foreach (var item in possibleRoute)
            {
                RidePossibleRoutes ridePossibleRoutes = new RidePossibleRoutes();
                ridePossibleRoutes.RidePlanId = ridePlan.Id;
                ridePossibleRoutes.PassingCityId = item.Id;
                _context.RidePossibleRoutes.Add(ridePossibleRoutes);
                await _context.SaveChangesAsync();

            }

            return CreatedAtAction(nameof(GetRidePlan), new { id = ridePlan.Id }, ridePlan);

        }


        [HttpDelete("{id}")]
        private async Task<IActionResult> DeleteRidePlan(long id)
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




        [HttpGet("{fromId}, {whereId}")]
        private async Task<List<Cities>> GetTravelRoute(int fromId, int whereId)
        {
            List<Cities> citiesList = await _context.Cities.ToListAsync();
            List<Cities> route = new List<Cities>();

            Cities startLocation = _context.Cities.Find(fromId);
            Cities destination = _context.Cities.Find(whereId);

            int difLat = 0;
            int difLong = 0;

            if (startLocation.Latitude > 0 && destination.Latitude > 0)
            {
                difLat = Math.Abs(startLocation.Latitude - destination.Latitude);
            }
            else if (startLocation.Latitude < 0 && destination.Latitude < 0)
            {
                difLat = Math.Abs(startLocation.Latitude - destination.Latitude);
            }
            else
            {
                difLat = Math.Abs(startLocation.Latitude - 0) + Math.Abs(destination.Latitude - 0);
            }

            if (startLocation.Longitude > 0 && destination.Longitude > 0)
            {
                difLong = Math.Abs(startLocation.Longitude - destination.Longitude);
            }
            else if (startLocation.Longitude < 0 && destination.Longitude < 0)
            {
                difLong = Math.Abs(startLocation.Longitude - destination.Longitude);
            }
            else
            {
                difLong = Math.Abs(startLocation.Longitude - 0) + Math.Abs(destination.Longitude - 0);
            }


            route.Add(startLocation);

            int startLatitude = startLocation.Latitude;
            int startLongitude = startLocation.Longitude;
            int destinationtLatitude = destination.Latitude;
            int destinationLongitude = destination.Longitude;


            for (int i = 0; i < difLat; i++)
            {
                if (destinationtLatitude > startLatitude)
                {
                    startLatitude += 1;
                    if (startLatitude == 0) { startLatitude += 1; }
                }
                else
                {
                    startLatitude -= 1;
                    if (startLatitude == 0) { startLatitude -= 1; }
                }

                Cities routedCity = citiesList.FirstOrDefault(x => x.Longitude == startLongitude && x.Latitude == startLatitude);
                route.Add(routedCity);

            }

            for (int i = 0; i < difLong; i++)
            {
                if (destinationLongitude > startLongitude)
                {
                    startLongitude += 1;
                    if (startLongitude == 0) { startLongitude += 1; }
                }
                else
                {
                    startLongitude -= 1;
                    if (startLongitude == 0) { startLongitude -= 1; }
                }

                Cities routedCity = citiesList.FirstOrDefault(x => x.Longitude == startLongitude && x.Latitude == startLatitude);
                route.Add(routedCity);

            }


            return route;


        }
    }
}
