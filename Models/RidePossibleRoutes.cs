using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Models
{
    public class RidePossibleRoutes
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public long RidePlanId { get; set; }

        [Required]
        public int PassingCityId { get; set; }

        [ForeignKey("RidePlanId")]
        public RidePlan RidePlan { get; set; }

        [ForeignKey("PassingCityId")]
        public Cities PassingCity { get; set; }
    }
}
