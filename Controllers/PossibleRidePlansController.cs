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
    public class PossibleRidePlansController : ControllerBase
    {
        private readonly RideShareContext _context;

        public PossibleRidePlansController(RideShareContext context)
        {
            _context = context;
        }



        [HttpGet("{beginCityId}, {destinationCityId}")]
        public async Task<List<RidePlan>> GetAllPublishedPossibleRidePlans(int beginCityId, int destinationCityId)
        {
            var publishedRides = await _context.RidePossibleRoutes.ToListAsync();

            var possibleRides = publishedRides.Where(x => x.PassingCityId == beginCityId || x.PassingCityId == destinationCityId);

            List<long> ridePlanList = new List<long>();

            List<RidePlan> possiblities = new List<RidePlan>();

            foreach (var item in publishedRides)
            {
                ridePlanList.Add(item.RidePlanId);  
            }

            foreach (var item in ridePlanList)
            {
                RidePlan ridePlan = _context.RidePlans.Find(item);
                possiblities.Add(ridePlan);
            }


            return possiblities;
        }

    }
}
