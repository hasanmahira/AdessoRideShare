using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdessoRideShare.Models
{
    public class SharedRides
    {

        [Required]
        public long Id { get; set; }

        [Required]
        public long RidePlanId { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public string PassengerSurName { get; set; }

        [ForeignKey("RidePlanId")]
        public RidePlan RidePlan { get; set; }
    }
}
