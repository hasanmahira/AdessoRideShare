using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Models
{
    public class RidePlan
    {
        public long Id { get; set; }
        public string From { get; set; }
        public string Where { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int NumberOfSeats { get; set; }
        public bool IsPublished{ get; set; }
    }
}
