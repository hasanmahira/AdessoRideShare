using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Models
{
    public class SharedRides
    {
        public long Id { get; set; }
        public long RidePlanId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerSurName { get; set; }

        public RidePlan RidePlan { get; set; }
    }
}
