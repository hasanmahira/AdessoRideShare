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
    public class CitiesController : ControllerBase
    {
        private readonly RideShareContext _context;

        public CitiesController(RideShareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cities>>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cities>> GetCities(int id)
        {
            var cities = await _context.Cities.FindAsync(id);

            if (cities == null)
            {
                return NotFound();
            }

            return cities;
        }

        [HttpGet("{fromId}, {whereId}")]
        public async Task<ActionResult<IEnumerable<Cities>>> GetTravelRoute(int fromId, int whereId)
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
                    if (startLatitude == 0){startLatitude += 1;}
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
                    if (startLongitude == 0){startLongitude += 1;}
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
